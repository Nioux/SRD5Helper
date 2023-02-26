using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SRD5Helper.Data;
using SRD5Helper.ViewModels;
using System.Collections;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using static SRD5Helper.Tools.Helpers;


namespace SRD5Helper.Views;

public struct ClassLevel
{
    public int Level;
    public string ClassID;
    public int SlotCount;
    public int MaxSlotCount;
}

public class SpellbookView : ContentView
{
    public static readonly BindableProperty SpellsProperty =
        BindableProperty.Create(nameof(Spells), typeof(IList), typeof(SpellbookView), null);

    public IReadOnlyList<Spell> Spells
    {
        get => (IReadOnlyList<Spell>)GetValue(SpellsProperty);
        set => SetValue(SpellsProperty, value);
    }

    public static readonly BindableProperty SpellsByLevelProperty =
        BindableProperty.Create(nameof(SpellsByLevel), typeof(IEnumerable), typeof(SpellbookView), null);

    public IEnumerable<IGrouping<ClassLevel, Spell>> SpellsByLevel
    {
        get => (IEnumerable<IGrouping<ClassLevel, Spell>>)GetValue(SpellsByLevelProperty);
        set => SetValue(SpellsByLevelProperty, value);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(Spells))
        {
            SpellsByLevel = Spells.GroupBy(spell => new ClassLevel 
            { 
                Level = spell.Level, 
                ClassID = spell.ClassID,
                SlotCount = 0,
                MaxSlotCount = spell.Class.SpellSlotsByLevel[spell.Level],
            });
            //SpellsByLevel = Spells.GroupBy(spell => spell.Level);
        }
        if (propertyName == nameof(SpellsByLevel))
        {
            BindableLayout.SetItemsSource(Content, SpellsByLevel);
        }
    }


    public SpellbookView()
    {
        Content = new FlexLayout 
        { 
            JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly, 
            AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start, 
            AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start, 
            Direction = Microsoft.Maui.Layouts.FlexDirection.Row, 
            Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap, 
        };
        BindableLayout.SetItemTemplate(Content, 
            new DataTemplate(() => 
            new GroupedSpellsView { }
            .Bind(GroupedSpellsView.GroupedSpellsProperty)));
            //.Bind(GroupedSpellsView.GroupedSpellsProperty, convert: (IGrouping<int, Spell> group) => group)));
    }
}

public class GroupedSpellsDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate EvenTemplate { get; set; }
    public DataTemplate UnevenTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var spells = (BindableLayout.GetItemsSource(container) as IGrouping<ClassLevel, Spell>).ToList();
        return spells.IndexOf(item as Spell) % 2 == 0 ? EvenTemplate : UnevenTemplate;
    }
}

public class GroupedSpellsView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    public DataService Library => Ioc.Default.GetRequiredService<DataService>();

    public static readonly BindableProperty GroupedSpellsProperty =
        BindableProperty.Create(nameof(GroupedSpells), typeof(IGrouping<ClassLevel, Spell>), typeof(GroupedSpellsView), null);

    public IGrouping<ClassLevel, Spell> GroupedSpells
    {
        get => (IGrouping<ClassLevel, Spell>)GetValue(GroupedSpellsProperty);
        set => SetValue(GroupedSpellsProperty, value);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(GroupedSpells))
        {
            BindableLayout.SetItemsSource(SpellsView, GroupedSpells);
        }
    }

    private View _header = null;
    public View Header => _header ??= 
        new Grid {
            Style = Styles.SpellsHeaderView,
            Children =
            { 
                new Label { /*WidthRequest = 300, */Style = Styles.SpellsHeaderLabel, Margin = 15 }
                //.Bind(Label.TextProperty, source: this, path: nameof(GroupedSpells), convert: (IGrouping<int, Spell> group) => group?.Key == 0 ? "TOURS DE MAGIE" : $"NIVEAU {group?.Key}")
                .Bind(Label.TextProperty, source: this, path: NameOf(() => GroupedSpells.Key), 
                    convert: (ClassLevel key) => key.Level == 0 ? $"TOURS DE MAGIE ({Library.ClassesData[key.ClassID].GenderedName})" : $"{Library.ClassesData[key.ClassID].GenderedName} NIVEAU {key.Level} {key.SlotCount} / {key.MaxSlotCount}")
            }
        };
    
    private View _spellsView = null;
    public View SpellsView => _spellsView ??= new VerticalStackLayout { /*WidthRequest = 300, */BackgroundColor = Styles.TableTitleBackgroundColor, };

    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();
    public GroupedSpellsView()
    {
        Content = new Grid
        {
            WidthRequest = Settings.MainColumnWidth,
            RowDefinitions =
            {
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto),
            },
            Children =
            {
                Header,
                SpellsView.Row(1),
            },
        };
        BindableLayout.SetItemTemplateSelector(SpellsView, new GroupedSpellsDataTemplateSelector { EvenTemplate = GetItemTemplate(Styles.AlternateEven), UnevenTemplate = GetItemTemplate(Styles.AlternateUneven) });
    }

    DataTemplate GetItemTemplate(Style style) => new DataTemplate(
    () => new SpellView
    { Style = style }.Bind(SpellView.SpellProperty));
    //new Grid
    //{
    //    Style = style,
    //    Children = {
    //        new Label { Style = Styles.DefaultListBasicLabel, Margin = 15, }
    //            .Bind(Label.TextProperty, convert: (Spell spellRef) => spellRef?.Datum.Name )
    //    }
    //});
}

public class SpellView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();

    public static readonly BindableProperty SpellProperty =
    BindableProperty.Create(nameof(Spell), typeof(Spell), typeof(SpellView), null);

    public Spell Spell
    {
        get => (Spell)GetValue(SpellProperty);
        set => SetValue(SpellProperty, value);
    }

    //public string JoinPath(params string[] parts)
    //{
    //    return string.Join(".", parts);
    //}

    //private static string NameOf<TRoot>(System.Linq.Expressions.Expression<Func<TRoot, object>> pathExpression)
    //{
    //    var members = new Stack<string>();
    //    for (
    //      var memberExpression = pathExpression.Body as System.Linq.Expressions.MemberExpression;
    //      memberExpression != null;
    //      memberExpression = memberExpression.Expression as System.Linq.Expressions.MemberExpression
    //    )
    //    {
    //        members.Push(memberExpression.Member.Name);
    //    }
    //    members.Push(typeof(TRoot).Name);
    //    return string.Join(".", members);
    //}

    public SpellView()
    {
        Content = new Grid
        {
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition(new GridLength(1, GridUnitType.Star)),
                new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
                new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
                new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
            },
            //Style = style,
            Children = 
            {
                new Label { Style = Styles.DefaultListBasicLabel, Margin = 15, }
                    .Column(0)
                    //.Bind(Label.TextProperty, source: this, path: nameof(Spell), convert: (Spell spellRef) => spellRef?.Name ),
                    .Bind(Label.TextProperty, source: this, path: NameOf(() => Spell.Name)),
                new SheetCheckbox { WidthRequest = 20, HeightRequest = 20, }
                    .Column(1)
                    .Bind(SheetCheckbox.IsCheckedProperty, source: this, path: NameOf(() => Spell.IsKnown))
                    //.BindCommand(source: this, path: NameOf(() => PlayerCharacterCommands.ToggleSpellIsKnownCommand), parameterPath: NameOf(() => Spell), parameterSource: this)
                    .Bind(SheetCheckbox.CommandProperty, source: this, path: NameOf(() => PlayerCharacterCommands.ToggleSpellIsKnownCommand))
                    .Bind(SheetCheckbox.CommandParameterProperty, source: this, path: NameOf(() => Spell))
                    ,
                    //.Bind(SheetCheckbox.IsCheckedProperty, source: this, path: JoinPath(nameof(Spell), nameof(Spell.IsKnown)), convert: (bool isKnown) => isKnown),
                new SheetCheckbox { WidthRequest = 20, HeightRequest = 20, }
                    .Column(2)
                    .Bind(SheetCheckbox.IsCheckedProperty, source: this, path: NameOf(() => Spell.IsPrepared))
                    .Bind(SheetCheckbox.CommandProperty, source: this, path: NameOf(() => PlayerCharacterCommands.ToggleSpellIsPreparedCommand))
                    .Bind(SheetCheckbox.CommandParameterProperty, source: this, path: NameOf(() => Spell))
                    ,
                    //.Bind(SheetCheckbox.IsCheckedProperty, source: this, path: JoinPath(nameof(Spell), nameof(Spell.IsPrepared)), convert: (bool isPrepared) => isPrepared),
                new SheetButton { Content = new Label { Text = "Cast", TextColor = Colors.Black, }, }
                    .Column(3)
            }
        };

    }
}
