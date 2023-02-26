using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Maui.Controls.Shapes;
using SRD5Helper.ViewModels;
using System.Runtime.CompilerServices;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class AbilitiesView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty AbilitiesProperty =
        BindableProperty.Create(nameof(Abilities), typeof(Abilities), typeof(AbilitiesView), null);

    public Abilities Abilities
    {
        get => (Abilities)GetValue(AbilitiesProperty);
        set => SetValue(AbilitiesProperty, value);
    }

    //protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //{
    //    base.OnPropertyChanged(propertyName);
    //    if (propertyName == nameof(Abilities))
    //    {
    //        InitContent();
    //    }
    //}
    public AbilitiesView()
    {
        //BackgroundColor = Colors.Transparent; // Styles.PageBackgroundColor;
                                              // bindable layouts
                                              // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/bindable-layouts

        Content = AbilitiesGrid;
    }

    private View _strengthView = null;
    public View StrengthView => _strengthView ??= new AbilityView { }
        .Bind(AbilityView.AbilityProperty, source: this, path: NameOf(() => Abilities.Strength));
        //.Bind(AbilityView.AbilityProperty, source: this, path: $"{nameof(Abilities)}.{nameof(Abilities.Strength)}");

    private View _dexterityView = null;
    public View DexterityView => _dexterityView ??= new AbilityView { }
        .Bind(AbilityView.AbilityProperty, source: this, path: NameOf(() => Abilities.Dexterity));
        //.Bind(AbilityView.AbilityProperty, source: this, path: $"{nameof(Abilities)}.{nameof(Abilities.Dexterity)}");

    private View _constitutionView = null;
    public View ConstitutionView => _constitutionView ??= new AbilityView { }
        .Bind(AbilityView.AbilityProperty, source: this, path: NameOf(() => Abilities.Constitution));
        //.Bind(AbilityView.AbilityProperty, source: this, path: $"{nameof(Abilities)}.{nameof(Abilities.Constitution)}");

    private View _intelligenceView = null;
    public View IntelligenceView => _intelligenceView ??= new AbilityView { }
        .Bind(AbilityView.AbilityProperty, source: this, path: NameOf(() => Abilities.Intelligence));
        //.Bind(AbilityView.AbilityProperty, source: this, path: $"{nameof(Abilities)}.{nameof(Abilities.Intelligence)}");

    private View _wisdomView = null;
    public View WisdomView => _wisdomView ??= new AbilityView { }
        .Bind(AbilityView.AbilityProperty, source: this, path: NameOf(() => Abilities.Wisdom));
        //.Bind(AbilityView.AbilityProperty, source: this, path: $"{nameof(Abilities)}.{nameof(Abilities.Wisdom)}");

    private View _charismaView = null;
    public View CharismaView => _charismaView ??= new AbilityView { }
        .Bind(AbilityView.AbilityProperty, source: this, path: NameOf(() => Abilities.Charisma));
        //.Bind(AbilityView.AbilityProperty, source: this, path: $"{nameof(Abilities)}.{nameof(Abilities.Charisma)}");
    /*
    public View AbilitiesGridOld => new Grid
    {
        RowSpacing = -Styles.AbilityHexagonHeight / 4,
        Style = Styles.Abilities,
        ColumnDefinitions =
        {
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
        },
        RowDefinitions =
        {
            new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
            new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
            new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
        },
        Children =
        {
            StrengthView.Row(0).Column(0),
            DexterityView.Row(1).Column(0),
            ConstitutionView.Row(2).Column(0),
            IntelligenceView.Row(0).Column(1),
            WisdomView.Row(1).Column(1),
            CharismaView.Row(2).Column(1),
        }
    };*/
    public View AbilitiesGrid => new FlexLayout
    {
        JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
        AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
        AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start,
        Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
        Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
        //RowSpacing = -Styles.AbilityHexagonHeight / 4,
        //Style = Styles.Abilities,
        //ColumnDefinitions =
        //{
        //    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
        //    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
        //},
        //RowDefinitions =
        //{
        //    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
        //    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
        //    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
        //},
        Children =
        {
            StrengthView,
            DexterityView,
            ConstitutionView,
            IntelligenceView,
            WisdomView,
            CharismaView,
        }
    };
}
public class AbilityView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty AbilityProperty =
        BindableProperty.Create(nameof(Ability), typeof(Ability), typeof(AbilityView), null, propertyChanged: AbilityChanged);

    private static void AbilityChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = bindable as AbilityView;
        var ability = newValue as Ability;
        MauiGestures.Gesture.SetCommandParameter(view.ScoreView, ability);
        ToolTipProperties.SetText(view, ability.Datum.Brief);
    }

    public Ability Ability
    {
        get => (Ability)GetValue(AbilityProperty);
        set => SetValue(AbilityProperty, value);
    }

    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();

    View _backView = null;
    View BackView => _backView ??= new Image
    {
        BackgroundColor = Color.FromArgb("407F7F7F"),
        /*StrokeShape = new Rectangle // RoundRectangle()
        {
            BackgroundColor = Colors.Red,
            //CornerRadius = new CornerRadius(10)
        },*/
        /*Content = new Grid()
        {
            //BackgroundColor = Color.FromArgb("C7CCD2"),
            //BackgroundColor = Color.FromArgb("C7000000"),
        }*/
    };

    /*View _scoreView = null;
    View ScoreView => _scoreView ??= new HexagonNameValueView { ZIndex = 1, Name = "VALEUR", Style = Styles.AbilityScore }
        .BindTapGesture(commandSource: PlayerCharacterCommands, commandPath: nameof(PlayerCharacterCommands.AbilityScoreCommand), parameterSource: this, parameterPath: nameof(Ability))
        .Bind(HexagonNameValueView.HexagonStrokeProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.IsScoreAltered)}", convert: (bool altered) => altered ? Colors.Red : Color.FromArgb("849098"))
        .Bind(HexagonNameValueView.ValueProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.Score)}");

    View _saveView = null;
    View SaveView => _saveView ??= new HexagonNameValueView { ZIndex = 2, Name = "SAUV.", Style = Styles.AbilitySave }
        .BindTapGesture(commandSource: PlayerCharacterCommands, commandPath: nameof(PlayerCharacterCommands.AbilitySaveCommand), parameterSource: this, parameterPath: nameof(Ability))
        .Bind(HexagonNameValueView.HexagonStrokeProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.IsSaveAltered)}", convert: (bool altered) => altered ? Colors.Red : Color.FromArgb("849098"))
        .Bind(HexagonNameValueView.ValueProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.Save)}", convert: (int save) => save.ToString("+0;-#"));
    */


    private View _scoreView = null;
    public View ScoreView => _scoreView ??= new BoardAttributeButton()
    {
        HorizontalOptions = LayoutOptions.Start,
        NameFontSize = Styles.MicroLabelFontSize,
        ValueFontSize = Styles.TitleLabelFontSize,
        SizeRatio = HexagonGeometry.GetRegularHexagonWidth(1.0),
        StrokeShape = new Microsoft.Maui.Controls.Shapes.Path
        {
            Stroke = Colors.Black,
            Aspect = Stretch.Uniform,
            HorizontalOptions = LayoutOptions.Center,
            Data = Geometries.HexagonGeometry,
        },
        Name = "VAL.",
    }
    //.BindTapGesture(commandSource: this, commandPath: NameOf(() => PlayerCharacterCommands.AbilityScoreCommand), parameterSource: this, parameterPath: NameOf(() => Ability))
    .Bind(BoardAttributeButton.ValueProperty, source: this, path: NameOf(() => Ability.Score));
    //.BindTapGesture(commandSource: PlayerCharacterCommands, commandPath: nameof(PlayerCharacterCommands.AbilityScoreCommand), parameterSource: this, parameterPath: nameof(Ability))
    //.Bind(BoardAttributeButton.ValueProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.Score)}");


    private View _saveView = null;
    public View SaveView => _saveView ??= new BoardAttributeButton()
    {
        HorizontalOptions = LayoutOptions.End,
        NameFontSize = Styles.MicroLabelFontSize,
        ValueFontSize = Styles.TitleLabelFontSize,
        SizeRatio = HexagonGeometry.GetRegularHexagonWidth(1.0),
        StrokeShape = new Microsoft.Maui.Controls.Shapes.Path
        {
            Stroke = Colors.Black,
            Aspect = Stretch.Uniform,
            HorizontalOptions = LayoutOptions.Center,
            Data = Geometries.HexagonGeometry,
        },
        Name = "SAUV.",
    }
    .BindTapGesture(commandSource: this, commandPath: NameOf(() => PlayerCharacterCommands.AbilitySaveCommand), parameterSource: this, parameterPath: NameOf(() => Ability))
    .Bind(BoardAttributeButton.ValueProperty, source: this, path: NameOf(() => Ability.Save), convert: (int save) => save.ToString("+0;-#"));
    //.BindTapGesture(commandSource: PlayerCharacterCommands, commandPath: nameof(PlayerCharacterCommands.AbilitySaveCommand), parameterSource: this, parameterPath: nameof(Ability))
    //.Bind(BoardAttributeButton.ValueProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.Save)}", convert: (int save) => save.ToString("+0;-#"));



    // Name
    View _nameView = null;
    public View NameView => _nameView ??= new Grid
    {
        //HorizontalOptions = LayoutOptions.StartAndExpand,
        Children = 
        { 
            new Label
            {
                TextColor = Colors.Black,
                TextTransform = TextTransform.Uppercase,
                Padding = new Thickness(5,5,0,0),
                //Style = Styles.AbilityModHeader,
                FontSize = Styles.MicroLabelFontSize,
                //HorizontalOptions = LayoutOptions.StartAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
            }
            .Bind(Label.TextProperty, source: this, path: NameOf(() => Ability.Name)) 
        }
    //.Bind(Label.TextProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.Name)}") }
    };

    // Mod
    /*View _modView = null;
    View ModView => _modView ??= new HexagonNameValueView//new Label
    {
        ZIndex = 4,
        Name = "Mod.",
        Style = Styles.AbilityScore,
        HexagonHeight = 90,
        //Style = Styles.AbilityMod,
        //HorizontalTextAlignment = TextAlignment.Start,
        //VerticalTextAlignment = TextAlignment.Start,
    }
    .BindTapGesture(commandSource: PlayerCharacterCommands, commandPath: nameof(PlayerCharacterCommands.AbilityModCommand), parameterSource: this, parameterPath: nameof(Ability))
    //.Bind(HexagonNameValueView.TextColorProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.IsModAltered)}", convert: (bool altered) => altered ? Colors.Red : Styles.DefaultTextColor)
    .Bind(HexagonNameValueView.ValueProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.Mod)}", convert: (int mod) => mod.ToString("+0;-#"))
    ;*/


    private View _modView = null;
    public View ModView => _modView ??= new TextSheetButton()
    {
        //NameFontSize = Styles.MicroLabelFontSize * 1.4,
        ValueFontSize = Styles.TitleLabelFontSize * 1.4,
        WidthRequest = Styles.TitleLabelFontSize * 4,
        Padding = new Thickness(Styles.TitleLabelFontSize / 2),
        //SizeRatio = 1.5, //HexagonGeometry.GetRegularHexagonWidth(1.0),
        Stroke = Colors.Black,
        StrokeShape = new Rectangle
        {
            Stroke = Colors.Black,
            Aspect = Stretch.Uniform,
            HorizontalOptions = LayoutOptions.Center,
        },
        /*StrokeShape = new Microsoft.Maui.Controls.Shapes.Path
        {
            Stroke = Colors.Black,
            Aspect = Stretch.Uniform,
            HorizontalOptions = LayoutOptions.Center,
            Data = Geometries.HexagonGeometry,
        },*/
        //Name = "", //"MOD.",
    }
    .BindTapGesture(commandSource: this, commandPath: NameOf(() => PlayerCharacterCommands.AbilityModCommand), parameterSource: this, parameterPath: NameOf(() => Ability))
    .Bind(TextSheetButton.ValueProperty, source: this, path: NameOf(() => Ability.Mod), convert: (int mod) => mod.ToString("+0;-#"));
    //.BindTapGesture(commandSource: PlayerCharacterCommands, commandPath: nameof(PlayerCharacterCommands.AbilityModCommand), parameterSource: this, parameterPath: nameof(Ability))
    //.Bind(TextSheetButton.ValueProperty, source: this, path: $"{nameof(Ability)}.{nameof(Ability.Mod)}", convert: (int mod) => mod.ToString("+0;-#"));



    View _saveProficiencyView = null;
    public View SaveProficiencyView => _saveProficiencyView ??= new HexagonBullet { HorizontalOptions = LayoutOptions.End } // Style = Styles.AbilitySaveProficiency }
        .Bind(VisualElement.StyleProperty, source: this, path: NameOf(() => Ability.SaveProficiency), convert: (bool save) => save ? Styles.AbilitySaveProficiencyTrue : Styles.AbilitySaveProficiencyFalse)
        .Bind(CheckBox.IsCheckedProperty, source: this, path: NameOf(() => Ability.SaveProficiency), mode: BindingMode.TwoWay);

    public AbilityView()
    {
        MauiGestures.Gesture.SetLongPressCommand(ScoreView, PlayerCharacterCommands.AbilityScoreCommand);
        MauiGestures.Gesture.SetCommandParameter(ScoreView, Ability);
        Content = new Grid
        {
            //RowSpacing = 2,
            RowDefinitions = new RowDefinitionCollection
            {
                //new RowDefinition { Height = Styles.AbilityHexagonHeight / 4 },
                //new RowDefinition { Height = Styles.AbilityHexagonHeight / 2 },
                //new RowDefinition { Height = Styles.AbilityHexagonHeight / 4 },
                //new RowDefinition { Height = Styles.AbilityHexagonHeight / 2 },
                //new RowDefinition { Height = Styles.AbilityHexagonHeight / 4 },
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                //new ColumnDefinition { Width = HexagonGeometry.GetRegularHexagonWidth(Styles.AbilityHexagonHeight) * 2 },
                //new ColumnDefinition { Width = HexagonGeometry.GetRegularHexagonWidth(Styles.AbilityHexagonHeight) / 2 },
                //new ColumnDefinition { Width = HexagonGeometry.GetRegularHexagonWidth(Styles.AbilityHexagonHeight) / 2 },
                //new ColumnDefinition { Width = HexagonGeometry.GetRegularHexagonWidth(Styles.AbilityHexagonHeight) / 2 },
                new ColumnDefinition (new GridLength(1, GridUnitType.Auto)),
                new ColumnDefinition (new GridLength(1, GridUnitType.Auto)),
                new ColumnDefinition (new GridLength(1, GridUnitType.Auto)),
                new ColumnDefinition (new GridLength(1, GridUnitType.Auto)),
                new ColumnDefinition (new GridLength(1, GridUnitType.Auto)),
            },
            Children =
            {
                BackView.Column(0).Row(0).ColumnSpan(4).RowSpan(4),
                NameView.Column(0).Row(0).ColumnSpan(5).RowSpan(1),
                ModView.Column(0).Row(1).ColumnSpan(2).RowSpan(3),
                ScoreView.Column(2).Row(1).ColumnSpan(2).RowSpan(2),
                SaveView.Column(3).Row(2).ColumnSpan(2).RowSpan(2),
                SaveProficiencyView.Column(2).Row(3).ColumnSpan(1).RowSpan(2),
            }
        };
    }
}
