using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using SRD5Helper.Data;
using SRD5Helper.DataModels;
using SRD5Helper.Resources.Library;
using SRD5Helper.ViewModels;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class ActionsView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    
    public static readonly BindableProperty ActionsProperty =
		BindableProperty.Create(nameof(Actions), typeof(IList), typeof(ActionsView), null);

	public IReadOnlyList<PlayerAction> Actions
	{
		get => (IReadOnlyList<PlayerAction>)GetValue(ActionsProperty);
		set => SetValue(ActionsProperty, value);
	}

    public static readonly BindableProperty ActionsByCategoryProperty =
    BindableProperty.Create(nameof(ActionsByCategory), typeof(IEnumerable), typeof(ActionsView), null);

    public IEnumerable<IGrouping<string, PlayerAction>> ActionsByCategory
    {
        get => (IEnumerable<IGrouping<string, PlayerAction>>)GetValue(ActionsByCategoryProperty);
        set => SetValue(ActionsByCategoryProperty, value);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(Actions))
        {
            ActionsByCategory = Actions.GroupBy(action => action.Category);
        }
        if (propertyName == nameof(ActionsByCategory))
        {
            BindableLayout.SetItemsSource(Content, ActionsByCategory);
        }
    }


    public ActionsView()
	{
		Content = new FlexLayout
        {
            JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
            AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
            AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start,
            Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
            Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
            /*Children =
            {
                new ToggledView
                {
                    Header = new Label { Text = "Aider", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                    Content = new Label { Text = "Un combattant peut apporter son aide à un autre.", TextColor = Colors.Black, FontSize = 15, FontFamily = "Florencesans" },
                    //Content = new Label { Text = "Un combattant peut apporter son aide à un autre. Le combattant\r\naidé obtient l’avantage sur son prochain test de caractéristique\r\n(même si celui-ci a lieu au round suivant), si ce\r\ntest correspond à l’action pour laquelle le premier a apporté\r\nson aide. En combat, pour aider un allié, il faut se trouver\r\nà 1,50 mètre de lui au maximum. Le PJ qui aide, en déconcentrant\r\nl’adversaire ou en soutenant son allié, permet au\r\npersonnage aidé de bénéficier de l’avantage sur son premier\r\njet d’attaque.", TextColor = Colors.Black, FontSize = 15, FontFamily = "Florencesans" },
                },
                new ToggledView
                {
                    Header = new Label { Text = "Attaquer", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                    Content = MeleeAttacks,
                },
                new ToggledView
                {
                    Header = new Label { Text = "Chercher" , TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                    Content = new Label { Text = "Cette action consiste à consacrer son tour à la recherche\r\nd’un élément particulier.", TextColor = Colors.Black, FontSize = 15, FontFamily = "Florencesans"  },
                },
                new Label { Text = "Esquiver", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                new Label { Text = "Lancer un sort", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                new Label { Text = "Se cacher", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                new Label { Text = "Se précipiter", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                new Label { Text = "Se tenir prêt", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                new Label { Text = "Utiliser un objet", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
                new Label { Text = "Autre chose ?", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
            },*/
        };
        BindableLayout.SetItemTemplate(Content,
            new DataTemplate(() =>
            new GroupedActionsView { }
            .Bind(GroupedActionsView.GroupedActionsProperty)));
    }

    /*CollectionView MeleeAttacks => new CollectionView
	{
        //Header = new Label {  Text = "Attaquer", TextColor = Colors.Black, FontSize = 25, FontFamily = Styles.BasicFontFamily },
        ItemTemplate = new DataTemplate(() => new WeaponAttackView { }.Bind(WeaponAttackView.WeaponProperty)),
	}.Bind(CollectionView.ItemsSourceProperty, source: this, path: nameof(Weapons));*/
}

public class GroupedActionsView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    public DataService Library => Ioc.Default.GetRequiredService<DataService>();

    public static readonly BindableProperty GroupedActionsProperty =
        BindableProperty.Create(nameof(GroupedActions), typeof(IGrouping<string, PlayerAction>), typeof(GroupedActionsView), null);

    public IGrouping<string, PlayerAction> GroupedActions
    {
        get => (IGrouping<string, PlayerAction>)GetValue(GroupedActionsProperty);
        set => SetValue(GroupedActionsProperty, value);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(GroupedActions))
        {
            BindableLayout.SetItemsSource(ActionsView, GroupedActions);
        }
    }

    private View _header = null;
    public View Header => _header ??=
        new Grid
        {
            Style = Styles.SpellsHeaderView,
            Children =
            {
                new Label { /*WidthRequest = 300, */Style = Styles.SpellsHeaderLabel, Margin = 15 }
                .Bind(Label.TextProperty, source: this, path: NameOf(() => GroupedActions.Key))
            }
        };

    private View _actionsView = null;
    public View ActionsView => _actionsView ??= new VerticalStackLayout { /*WidthRequest = 300, */BackgroundColor = Styles.TableTitleBackgroundColor, };

    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();
    public GroupedActionsView()
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
                ActionsView.Row(1),
            },
        };
        BindableLayout.SetItemTemplateSelector(ActionsView, new GroupedActionsDataTemplateSelector { EvenTemplate = GetItemTemplate(Styles.AlternateEven), UnevenTemplate = GetItemTemplate(Styles.AlternateUneven) });
    }

    DataTemplate GetItemTemplate(Style style) => new DataTemplate(
    () => new ActionView
    { Style = style }.Bind(ActionView.ActionProperty));
}

public class GroupedActionsDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate EvenTemplate { get; set; }
    public DataTemplate UnevenTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var actions = (BindableLayout.GetItemsSource(container) as IGrouping<string, PlayerAction>).ToList();
        var action = item as PlayerAction;
        if(action.Item is Equipment)
        {
            return new DataTemplate(() => new WeaponAttackView { }.Bind(WeaponAttackView.WeaponProperty, path: nameof(PlayerAction.Item)));
        }
        return actions.IndexOf(action) % 2 == 0 ? EvenTemplate : UnevenTemplate;
    }
}

public class ActionView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();

    public static readonly BindableProperty ActionProperty =
    BindableProperty.Create(nameof(Action), typeof(PlayerAction), typeof(ActionView), null);

    public PlayerAction Action
    {
        get => (PlayerAction)GetValue(ActionProperty);
        set => SetValue(ActionProperty, value);
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

    public ActionView()
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
                new Expander()
                {
                    Header = new Label { Style = Styles.DefaultListBasicLabel, Margin = 15, }
                        .Bind(Label.TextProperty, source: this, path: NameOf(() => Action.Name)),
                    Content = new Label { Style = Styles.DefaultListBasicLabel, Margin = 15, }
                        .Bind(Label.TextProperty, source: this, path: NameOf(() => Action.Description)),
                }.Assign(out Expander expander).ClickGesture(() => expander.IsExpanded = true)
                .Column(0)
                //new SheetCheckbox { WidthRequest = 20, HeightRequest = 20, }
                //    .Column(1)
                //    .Bind(SheetCheckbox.IsCheckedProperty, source: this, path: NameOf(() => Spell.IsKnown))
                //    //.BindCommand(source: this, path: NameOf(() => PlayerCharacterCommands.ToggleSpellIsKnownCommand), parameterPath: NameOf(() => Spell), parameterSource: this)
                //    .Bind(SheetCheckbox.CommandProperty, source: this, path: NameOf(() => PlayerCharacterCommands.ToggleSpellIsKnownCommand))
                //    .Bind(SheetCheckbox.CommandParameterProperty, source: this, path: NameOf(() => Spell))
                //    ,
                //    //.Bind(SheetCheckbox.IsCheckedProperty, source: this, path: JoinPath(nameof(Spell), nameof(Spell.IsKnown)), convert: (bool isKnown) => isKnown),
                //new SheetCheckbox { WidthRequest = 20, HeightRequest = 20, }
                //    .Column(2)
                //    .Bind(SheetCheckbox.IsCheckedProperty, source: this, path: NameOf(() => Spell.IsPrepared), mode: BindingMode.TwoWay),
                //    //.Bind(SheetCheckbox.IsCheckedProperty, source: this, path: JoinPath(nameof(Spell), nameof(Spell.IsPrepared)), convert: (bool isPrepared) => isPrepared),
                //new SheetButton { Content = new Label { Text = "Cast", TextColor = Colors.Black, }, }
                //    .Column(3)
            }
        };

    }
}


/*
public class ToggledView : VerticalStackLayout
{
    public static readonly BindableProperty HeaderProperty =
        BindableProperty.Create(nameof(Header), typeof(View), typeof(ToggledView), null);

    public View Header
    {
        get => (View)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly BindableProperty ContentProperty =
        BindableProperty.Create(nameof(Content), typeof(View), typeof(ToggledView), null);

    public View Content
    {
        get => (View)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public View _headerRealView = null;
    public View HeaderRealView => _headerRealView ??=
        new ContentView { }
            .Bind(ContentView.ContentProperty, source: this, path: nameof(Header));
    public View _contentRealView = null;
    public View ContentRealView => _contentRealView ??=
        new ContentView { IsVisible = true }
            .Bind(ContentView.ContentProperty, source: this, path: nameof(Content));
    public ToggledView()
    {
        Add(HeaderRealView);
        Add(ContentRealView);
        HeaderRealView.GestureRecognizers.Add(new TapGestureRecognizer { Command = new RelayCommand(() => ContentRealView.IsVisible = !ContentRealView.IsVisible) });
    }
}
*/
public class WeaponAttackView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty WeaponProperty =
        BindableProperty.Create(nameof(Weapon), typeof(Equipment), typeof(WeaponAttackView), null);

    public Equipment Weapon
    {
        get => (Equipment)GetValue(WeaponProperty);
        set => SetValue(WeaponProperty, value);
    }

    public View NameView => new Label { TextColor = Colors.Black, FontSize = 15, FontFamily = Styles.BasicFontFamily /*FontFamily = Styles.ScriptFontFamily*/, }
        .Bind(Label.TextProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.Name);


    public View MeleeAttackButton => new HorizontalStackLayout
    { 
        //new Image { Source = "melee.png", WidthRequest = 50, HeightRequest = 50, },
        new AttackRollButton { MeleeRange = MeleeRangeEnum.Melee, }
            .Bind(AttackRollButton.ModifierProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.MeleeAttackModifier)}", convert: (int? modifier) => modifier ?? 0)
    }.Bind(VisualElement.IsVisibleProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.MeleeDamage != null || e?.TwoHandledMeleeDamage != null);

    public View RangeAttackButton => new HorizontalStackLayout
    {
        //new Image { Source = "range.png", WidthRequest = 50, HeightRequest = 50, },
        new AttackRollButton { MeleeRange = MeleeRangeEnum.Range, }
            .Bind(AttackRollButton.ModifierProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.RangeAttackModifier)}", convert: (int? modifier) => modifier ?? 0)
    }.Bind(VisualElement.IsVisibleProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.RangeDamage != null);

    public View MeleeDamageButton => new DamageButton { BackgroundColor = Colors.White }
        .Bind(VisualElement.IsVisibleProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.MeleeDamage)}", convert: (Damage? damage) => damage != null) 
        .Bind(DamageButton.DieTypeProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.MeleeDamage)}", convert: (Damage? damage) => damage?.Dice ?? 0)
        .Bind(DamageButton.DiceCountProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.MeleeDamage)}", convert: (Damage? damage) => damage?.DiceCount ?? 1)
        .Bind(DamageButton.DamageTypeProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.MeleeDamage)}", convert: (Damage? damage) => damage?.Type ?? 0)
        .Bind(DamageButton.ModifierProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.MeleeDamage)}", convert: (Damage? damage) => damage?.Modifier ?? 0);

    public View TwhoHandledMeleeDamageButton => new DamageButton { BackgroundColor = Colors.White, TwoHandled = true, }
        .Bind(VisualElement.IsVisibleProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.TwoHandledMeleeDamage)}", convert: (Damage? damage) => damage != null)
        .Bind(DamageButton.DieTypeProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.TwoHandledMeleeDamage)}", convert: (Damage? damage) => damage?.Dice ?? 0)
        .Bind(DamageButton.DiceCountProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.TwoHandledMeleeDamage)}", convert: (Damage? damage) => damage?.DiceCount ?? 1)
        .Bind(DamageButton.DamageTypeProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.TwoHandledMeleeDamage)}", convert: (Damage? damage) => damage?.Type ?? 0)
        .Bind(DamageButton.ModifierProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.TwoHandledMeleeDamage)}", convert: (Damage? damage) => damage?.Modifier ?? 0);

    public View RangeDamageButton => new DamageButton { BackgroundColor = Colors.White }
        .Bind(VisualElement.IsVisibleProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.RangeDamage)}", convert: (Damage? damage) => damage != null)
        .Bind(DamageButton.DieTypeProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.RangeDamage)}", convert: (Damage? damage) => damage?.Dice ?? 0)
        .Bind(DamageButton.DiceCountProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.RangeDamage)}", convert: (Damage? damage) => damage?.DiceCount ?? 1)
        .Bind(DamageButton.DamageTypeProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.RangeDamage)}", convert: (Damage? damage) => damage?.Type ?? 0)
        .Bind(DamageButton.ModifierProperty, source: this, path: $"{nameof(Weapon)}.{nameof(Equipment.RangeDamage)}", convert: (Damage? damage) => damage?.Modifier ?? 0);

    public WeaponAttackView()
    {
        Content = new Grid
        {
            BackgroundColor = Colors.White,
            ColumnDefinitions = new()
            {
                new ColumnDefinition(GridLength.Auto),
                new ColumnDefinition(GridLength.Auto),
                new ColumnDefinition(GridLength.Auto),
            },
            RowDefinitions = new()
            {
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto),
            },
            Children =
            {
                NameView
                    .Column(0).Row(0).RowSpan(1).ColumnSpan(3),
                MeleeAttackButton
                    .Column(1).Row(1).RowSpan(2),
                MeleeDamageButton
                    .Column(2).Row(1),
                TwhoHandledMeleeDamageButton
                    .Column(2).Row(2),
                RangeAttackButton
                    .Column(1).Row(3),
                RangeDamageButton
                    .Column(2).Row(3),

                //new Label { TextColor = Colors.Black, BackgroundColor = Colors.White }
                //    .Bind(Label.TextProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.MeleeAttackModifier, stringFormat: "Mod: {0}"),
                //new Label { TextColor = Colors.Black, BackgroundColor = Colors.White }
                //    .Bind(Label.TextProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.MeleeDamage ?? e?.TwoHandledMeleeDamage, stringFormat: "Corps à corps: {0}"),



                //new Label { TextColor = Colors.Black, BackgroundColor = Colors.White }
                //    .Bind(Label.TextProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.MeleeDamage, stringFormat: "Une main: {0}"),
                //new Label { TextColor = Colors.Black, BackgroundColor = Colors.White }
                //    .Bind(Label.TextProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.TwoHandledMeleeDamage, stringFormat: "Deux mains: {0}"),
                //new Label { TextColor = Colors.Black, BackgroundColor = Colors.White }
                //    .Bind(Label.TextProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.RangeAttackModifier, stringFormat: "Mod: {0}"),
                //new Label { TextColor = Colors.Black, BackgroundColor = Colors.White }
                //    .Bind(Label.TextProperty, source: this, path: nameof(Weapon), convert: (Equipment e) => e?.RangeDamage, stringFormat: "Distance: {0}"),
    //               new Label { TextColor = Colors.Black, }
    //                   .Bind(Label.TextProperty, convert: (Equipment e) => e?.Datum.Name),
				//new Label { TextColor = Colors.Black, }
    //                   .Bind(Label.TextProperty, convert: (Equipment e) => ToDamageString(e?.Datum.MeleeDamage)),
				//new Label { TextColor = Colors.Black, }
    //                   .Bind(Label.TextProperty, convert: (Equipment e) => ToDamageString(e?.Datum.RangeDamage)),
			}
        };
    }
}
  