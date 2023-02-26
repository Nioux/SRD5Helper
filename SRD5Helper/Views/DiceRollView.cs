using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.Units;
using SRD5Helper.ViewModels;
using YamlDotNet.Core.Tokens;

namespace SRD5Helper.Views;

public class AbilityDiceRollView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty AbilityProperty =
        BindableProperty.Create(nameof(Ability), typeof(Ability), typeof(AbilityDiceRollView), null);

    public Ability Ability
    {
        get => (Ability)GetValue(AbilityProperty);
        set => SetValue(AbilityProperty, value);
    }

    public static readonly BindableProperty D201Property =
    BindableProperty.Create(nameof(D201), typeof(int?), typeof(AbilityDiceRollView), null);

    public int? D201
    {
        get => (int?)GetValue(D201Property);
        set => SetValue(D201Property, value);
    }

    public static readonly BindableProperty D202Property =
    BindableProperty.Create(nameof(D202), typeof(int?), typeof(AbilityDiceRollView), null);

    public int? D202
    {
        get => (int?)GetValue(D202Property);
        set => SetValue(D202Property, value);
    }


    public AdvantageDisadvantage AdvantageDisadvantage { get; set; }
    public string Result { get; set; }

    public AbilityDiceRollView()
	{
        var d20 = Random.Shared.Next(20) + 1;

        //var span1 = new Span { FontFamily = Styles.BasicFontFamily, FontSize = Styles.TitleLabelFontSize * 2, }
        //.Bind(Span.TextProperty, path: nameof(Ability), source: this, convert: (Ability ability) => $"Test de caractéristique ({ability?.Name})\n\n");
        var formattedText = new FormattedString
        {
            Spans =
            {
                new Span { FontFamily = Styles.BasicFontFamily, FontSize = Styles.TitleLabelFontSize, }
                    .Bind(Span.TextProperty, path: nameof(Ability), source: this, convert: (Ability ability) => $"Test de caractéristique ({ability?.Name})\n\n"),
                
                new Span { Text = PlayerCharacterCommands.GameIconsFont.D20, FontFamily = "GameIcons", FontSize = Styles.SubtitleLabelFontSize, },

                new Span { FontSize = Styles.SubtitleLabelFontSize, }
                    .Bind(
                        Span.TextProperty, 
                        bindings: new [] 
                        {
                            new Binding(source: this, path: nameof(Ability)),
                            new Binding(source: this, path: nameof(D201)),
                            new Binding(source: this, path: nameof(D202)),
                        },
                        converter: 
                            new FuncMultiConverter<Ability, int, int, string>(convert: ((Ability ability, int d201, int d202) values) => $" + Mod ({values.ability?.Name}) = {values.d201} {values.ability?.Mod:+0;-#} = {values.d201 + values.ability?.Mod}\n\n")),
                    
                    //.Bind(Span.TextProperty, path: nameof(Ability), source: this, convert: (Ability ability) => $" + Mod ({ability?.Name}) = {d20} {ability?.Mod:+0;-#} = {d20 + ability?.Mod}\n\n"),

                //new Span { FontSize = Styles.SubtitleLabelFontSize, }
                //    .Bind(Span.TextProperty, path: nameof(Ability), source: this, convert: (Ability ability) => $" + Mod ({ability?.Name}) = {d20} {ability?.Mod:+0;-#} = {d20 + ability?.Mod}\n\n"),

                new Span { FontFamily = Styles.BasicFontFamily, FontSize = Styles.TitleLabelFontSize, }
                    .Bind(Span.TextProperty, path: nameof(Ability), source: this, convert: (Ability ability) => $"{d20 + ability?.Mod}"),
            }
        };
        var label = new Label { LineBreakMode = LineBreakMode.WordWrap, BackgroundColor = Colors.White, TextColor = Colors.Black, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FormattedText = formattedText };
        var dice = new DiceView { DiceType = 20, RollValue = (Random.Shared.Next(20) + 1), WidthRequest = 100 };
        Content = new Grid 
        { 
            MaximumWidthRequest = 400, 
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
            },
            Children = 
            { 
                label.Row(0), 
                dice.Row(1),
            } 
        };
        dice.RollAsync().ContinueWith((ok) => { D201 = 18; D202 = 15; });
        BackgroundColor = Colors.White;
        /*new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};*/
	}

}

public class DiceView : ContentView
{
    public static readonly BindableProperty DiceTypeProperty =
        BindableProperty.Create(nameof(DiceType), typeof(int), typeof(DiceView), 0);

    public int DiceType
    {
        get => (int)GetValue(DiceTypeProperty);
        set => SetValue(DiceTypeProperty, value);
    }


    public static readonly BindableProperty RollValueProperty =
        BindableProperty.Create(nameof(RollValue), typeof(int), typeof(DiceView), 0);

    public int RollValue
    {
        get => (int)GetValue(RollValueProperty);
        set => SetValue(RollValueProperty, value);
    }


    private View _dice = null;
    public View Dice => _dice ??= new Image { Source = "d20.png" }
        .Bind(Image.SourceProperty, path: nameof(DiceType), source: this, convert: (int diceType) => $"d{diceType}.png");

    private View _roll = null;
    public View Roll => _roll ??= new Label { Opacity = 0.0, TextColor = Colors.Black, FontFamily = "Florencesans", FontSize = 40, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, }
        .Bind(Label.TextProperty, path: nameof(RollValue), source: this, convert: (int rollValue) => $"{rollValue}");

    public DiceView()
    {
        Content = new Grid
        {
            Children =
            {
                Dice,
                Roll,
            },
        };
    }

    public async Task RollAsync()
    {
        await Task.WhenAll<bool>
        (
            Dice.RotateXTo(360 * (Random.Shared.Next(2) + 1), 2000, Easing.SinInOut),
            Dice.RotateYTo(360 * (Random.Shared.Next(2) + 1), 2000, Easing.SinInOut),
            Dice.RotateTo(360 * (Random.Shared.Next(2) + 1), 2000, Easing.SinInOut)
        );
        await Task.WhenAll<bool>(
            Dice.FadeTo(0.2, 1000),
            Roll.FadeTo(1, 1000)
            );
    }
}