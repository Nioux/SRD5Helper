using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.DataModels;
using SRD5Helper.ViewModels;
using System.Runtime.CompilerServices;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class AlternateColorDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate EvenTemplate { get; set; }
    public DataTemplate UnevenTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        //var skills = ((container as CollectionView).ItemsSource) as Skills;
        //var listSkills = skills.ToList();
        //return listSkills.IndexOf(item as Skill) % 2 == 0 ? EvenTemplate : UnevenTemplate;
        var skills = ((container as CollectionView).ItemsSource) as List<Skill>;
        var listSkills = skills.ToList();
        return listSkills.IndexOf(item as Skill) % 2 == 0 ? EvenTemplate : UnevenTemplate;
    }
}
public class SkillsView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty SkillsProperty =
        BindableProperty.Create(nameof(Skills), typeof(Skills), typeof(SkillsView), null);

    public Skills Skills
    {
        get => (Skills)GetValue(SkillsProperty);
        set => SetValue(SkillsProperty, value);
    }


    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();

    public SkillsView()
    {
        Style = Styles.Skills;

        Content = new CollectionView
        {
            SelectionMode = SelectionMode.Single,
            ItemTemplate = new AlternateColorDataTemplateSelector { EvenTemplate = GetDataTemplate(Styles.AlternateEven), UnevenTemplate = GetDataTemplate(Styles.AlternateUneven) }
        }
        .Bind(CollectionView.ItemsSourceProperty, source: this, path: nameof(Skills), convert: (Skills skills) => skills?.ToList());
    }

    private DataTemplate GetDataTemplate(Style style)
    {
        return new DataTemplate(() => 
            new SkillView { Style = style }
            .Bind(SkillView.SkillProperty)
        );
    }
}

public class SkillView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();

    public static readonly BindableProperty SkillProperty =
        BindableProperty.Create(nameof(Skill), typeof(Skill), typeof(SkillView), null, propertyChanged: SkillChanged);

    private static void SkillChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = bindable as SkillView;
        var skill = newValue as Skill;
        ToolTipProperties.SetText(view.SkillRollButton, skill.Mod.Description);
        ToolTipProperties.SetText(view.SkillAndAbilityName, skill.Datum.Description);
    }

    public Skill Skill
    {
        get => (Skill)GetValue(SkillProperty);
        set => SetValue(SkillProperty, value);
    }


    private View _proficiencyView = null;
    public View ProficiencyView => _proficiencyView ??= new HexagonView { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center }
        //.Row(SkillRows.First, SkillRows.Second)
        //.BindTapGesture(commandSource: this, commandPath: $"{nameof(PlayerCharacterCommands)}.{nameof(PlayerCharacterCommands.ToggleSkillProficiencyCommand)}", parameterSource: this, parameterPath: nameof(Skill))
        .Bind(VisualElement.StyleProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Proficiency), convert: (bool proficiency) => proficiency ? Styles.SkillProficiencyTrue : Styles.SkillProficiencyFalse);

    private View _skillAndAbilityName = null;
    public View SkillAndAbilityName => _skillAndAbilityName ??= new Label
    {
        //Style = Styles.SkillID,
        VerticalOptions = LayoutOptions.Center,
        FontFamily = Styles.BasicFontFamily,
        FontSize = Styles.TitleLabelFontSize,
        TextColor = Colors.Black,
        FontAttributes = FontAttributes.Bold,
        FormattedText = new FormattedString
        {
            Spans =
            {
                new Span { }
                    .Bind(Span.TextProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Name)),
                new Span { FontSize = Styles.SubtitleLabelFontSize, TextTransform = TextTransform.Uppercase, }//Style = Styles.SkillAbilityID, }
                    .Bind(Span.TextProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Ability), convert: (Ability ability) => $" ({ability?.Name?.Substring(0, 3)})"),
            },
        },
    };

    View _skillRollButton;
    public View SkillRollButton => _skillRollButton ??= new AbilityCheckButton { }
        .BindTapGesture(commandSource: this, commandPath: $"{nameof(PlayerCharacterCommands)}.{nameof(PlayerCharacterCommands.SkillModCommand)}", parameterSource: this, parameterPath: nameof(Skill))
        //.Bind(AbilityCheckButton.ModifierProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Mod), convert: (int? modifier) => modifier ?? 0),
        .Bind(AbilityCheckButton.ModifierProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Mod), convert: (AnnotatedNumber<int>? modifier) => modifier?.Value ?? 0);


    enum SkillColumn { SeparatorStart, Hexagon, SeparatorHexagonSkill, Skill, SeparatorSkillAbility, /*Ability, SeparatorAbilityMod,*/ Mod, SeparatorEnd };
    enum SkillRows { First, Second, Third };
    public SkillView()
    {
        Content = new Grid
        {
            //Style = style,
            ColumnDefinitions = Columns.Define(
                (SkillColumn.SeparatorStart, 15),
                (SkillColumn.Hexagon, Auto),
                (SkillColumn.SeparatorHexagonSkill, 15),
                (SkillColumn.Skill, Star),
                (SkillColumn.SeparatorSkillAbility, 5),
                //(SkillColumn.Ability, Styles.DefaultListFontSize * 4),
                //(SkillColumn.SeparatorAbilityMod, Star),
                (SkillColumn.Mod, Auto),
                (SkillColumn.SeparatorEnd, 15)
            ),
            RowDefinitions = Rows.Define(
                (SkillRows.First, Auto),
                (SkillRows.Second, Auto)
            ),
            Children =
            {
                ProficiencyView.Column(SkillColumn.Hexagon),
                SkillAndAbilityName.Column(SkillColumn.Skill),
                SkillRollButton.Column(SkillColumn.Mod),

                /*
                new HexagonView { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center }
                    .Column(SkillColumn.Hexagon)
                    //.Row(SkillRows.First, SkillRows.Second)
                    //.BindTapGesture(commandSource: this, commandPath: $"{nameof(PlayerCharacterCommands)}.{nameof(PlayerCharacterCommands.ToggleSkillProficiencyCommand)}", parameterSource: this, parameterPath: nameof(Skill))
                    .Bind(VisualElement.StyleProperty, source:this, path: nameof(Skill) + "." + nameof(Skill.Proficiency), convert: (bool proficiency) => proficiency ? Styles.SkillProficiencyTrue : Styles.SkillProficiencyFalse),
                new Label
                {
                    //Style = Styles.SkillID,
                    VerticalOptions = LayoutOptions.Center,
                    FontFamily = Styles.BasicFontFamily,
                    FontSize = Styles.TitleLabelFontSize,
                    TextColor = Colors.Black,
                    FontAttributes = FontAttributes.Bold,
                    FormattedText = new FormattedString
                    {
                        Spans =
                        {
                            new Span { }
                                .Bind(Span.TextProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Name)),
                            new Span { FontSize = Styles.SubtitleLabelFontSize, TextTransform = TextTransform.Uppercase, }//Style = Styles.SkillAbilityID, }
                                .Bind(Span.TextProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Ability), convert: (Ability ability) => $" ({ability?.Name?.Substring(0, 3)})"),
                        },
                    },
                }
                .Column(SkillColumn.Skill),
                //new Label { Style = Styles.SkillAbilityID, VerticalOptions = LayoutOptions.Center }
                //    .Column(SkillColumn.Ability)
                //    .Bind(Label.TextProperty, path: nameof(Skill.Ability), convert: (Ability ability) => $"({ability.Datum.Name.Substring(0, 3)})"),
                
                //new Label { Style = Styles.SkillMod, VerticalTextAlignment = TextAlignment.Center, VerticalOptions = LayoutOptions.Center }
                //    .Column(SkillColumn.Mod)
                //    //.Row(SkillRows.First, SkillRows.Second)
                //    .BindTapGesture(commandSource: this, commandPath: $"{nameof(PlayerCharacterCommands)}.{nameof(PlayerCharacterCommands.SkillModCommand)}", parameterSource: this, parameterPath: nameof(Skill))
                //    .Bind(Label.TextProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Mod), convert: (int mod) => $"{mod:+0;-#}"),

                new AbilityCheckButton { }
                    .Column(SkillColumn.Mod)
                    .BindTapGesture(commandSource: this, commandPath: $"{nameof(PlayerCharacterCommands)}.{nameof(PlayerCharacterCommands.SkillModCommand)}", parameterSource: this, parameterPath: nameof(Skill))
                    //.Bind(AbilityCheckButton.ModifierProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Mod), convert: (int? modifier) => modifier ?? 0),
                    .Bind(AbilityCheckButton.ModifierProperty, source: this, path: nameof(Skill) + "." + nameof(Skill.Mod), convert: (AnnotatedNumber<int>? modifier) => modifier?.Value ?? 0),


                new Label { Style = Styles.SkillModDescription, VerticalTextAlignment = TextAlignment.Center, VerticalOptions = LayoutOptions.Center }
                    .Column(SkillColumn.Skill, SkillColumn.Mod)
                    .Row(SkillRows.Second)
                    //.Bind(Label.TextProperty, path: nameof(Skill.ModDescription)),
                    .Bind(Label.TextProperty, path: nameof(Skill.Mod) + "." + nameof(Skill.Mod.Description)),
                */
            }
        };

    }
}
