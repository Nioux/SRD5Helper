using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.ViewModels;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class FlatPlayerCharacterPage : ContentView
{
    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();
    public static readonly BindableProperty PlayerCharacterProperty =
        BindableProperty.Create(nameof(PlayerCharacter), typeof(PlayerCharacter), typeof(FlatPlayerCharacterPage), null);

    public PlayerCharacter PlayerCharacter
    {
        get => (PlayerCharacter)GetValue(PlayerCharacterProperty);
        set => SetValue(PlayerCharacterProperty, value);
    }

    public FlatPlayerCharacterPage()
    {
        var screen = new Grid
        {
            ColumnDefinitions = new ColumnDefinitionCollection
        {
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
        },
            Children =
        {
            new AbilitiesView()
            {
                WidthRequest = 200,
            }
            .Bind(AbilitiesView.AbilitiesProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Abilities)),
            new ScrollView
            {
                    WidthRequest = 200,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Children =
                    {
                        new BoardView
                        {
                        }
                        .Bind(BoardView.PlayerCharacterProperty, source:this, path: nameof(PlayerCharacter)),
                        new ActionsView()
                        {
                            WidthRequest = 200,
                        }
                        .Bind(ActionsView.ActionsProperty, source:this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Actions)),
                        new RadioButton
                        {
                            Content = "Débutant",
                            Value = UserMode.Beginner,
                        }
                        .Bind(RadioButton.IsCheckedProperty, source: this, path: nameof(Settings) + "." + nameof(Settings.UserMode), mode: BindingMode.TwoWay, convert: (UserMode userMode) => userMode == UserMode.Beginner, convertBack: (bool selected) => UserMode.Beginner),
                        new RadioButton
                        {
                            Content = "Normal",
                            Value = UserMode.Normal,
                            IsVisible = false,
                        }
                        .Bind(RadioButton.IsCheckedProperty, source: this, path: nameof(Settings) + "." + nameof(Settings.UserMode), mode: BindingMode.TwoWay, convert: (UserMode userMode) => userMode == UserMode.Normal, convertBack: (bool selected) => UserMode.Normal),
                        new RadioButton
                        {
                            Content = "Avancé",
                            Value = UserMode.Advanced,
                        }
                        .Bind(RadioButton.IsCheckedProperty, source: this, path: nameof(Settings) + "." + nameof(Settings.UserMode), mode: BindingMode.TwoWay, convert: (UserMode userMode) => userMode == UserMode.Advanced, convertBack: (bool selected) => UserMode.Advanced),
                        new RadioButton
                        {
                            Content = "Debug",
                            Value = UserMode.Debug,
                        }
                        .Bind(RadioButton.IsCheckedProperty, source: this, path: nameof(Settings) + "." + nameof(Settings.UserMode), mode: BindingMode.TwoWay, convert: (UserMode userMode) => userMode == UserMode.Debug, convertBack: (bool selected) => UserMode.Debug),
                        new Image
                        {}
                        .Bind(Image.SourceProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.CharacterPicture)),
                    },
                }.Column(1).Row(0),
            }.Column(1).Row(0),
            new SkillsView()
            {
                WidthRequest = 300,
            }.Column(2).Row(0)
            .Bind(SkillsView.SkillsProperty, source : this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Skills)),
            new SpellbookView()
            {
                WidthRequest = 280,
            }.Column(3).Row(0)
            .Bind(SpellbookView.SpellsProperty, source:this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.SpellRefsByLevel)),
            new EquipmentsView
            {
                WidthRequest = 200,
            }.Column(4).Row(0)
            .Bind(EquipmentsView.EquipmentSlotsProperty, source:this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.EquipmentRefs)),
            new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new FeaturesView { WidthRequest = 200, }
                    .Bind(FeaturesView.PlayerCharacterProperty, source:this, path: nameof(PlayerCharacter)),
                    //.Bind(FeaturesView.FeaturesProperty, source:this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Features)),
                }
            }.Column(5).Row(0),
            new HealthView
            {
                WidthRequest = 300,
            }.Column(6).Row(0)
            .Bind(HealthView.PlayerCharacterProperty, source : this, path: nameof(PlayerCharacter)),
            //.Bind(HealthView.ConditionsProperty, source : this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Conditions)),
        }
        };
        Content = screen;
    }
}

