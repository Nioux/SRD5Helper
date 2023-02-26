using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Maui.Controls;
using SRD5Helper.ViewModels;
using System.Runtime.CompilerServices;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class PlayerCharacterPage : TabBar
{
    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty PlayerCharacterProperty =
        BindableProperty.Create(nameof(PlayerCharacter), typeof(PlayerCharacter), typeof(PlayerCharacterPage), null);

    public PlayerCharacter PlayerCharacter
    {
        get => (PlayerCharacter)GetValue(PlayerCharacterProperty);
        set => SetValue(PlayerCharacterProperty, value);
    }

    private ShellContent GetShellContentLayout(View insideView)
    {
        return new ShellContent
        {
            Content = new ContentPage
            {
                Content = new Grid
                {
                    RowDefinitions = new RowDefinitionCollection
                    {
                        new RowDefinition(new GridLength(Styles.TitleLabelFontSize * 4)),
                        new RowDefinition(new GridLength(80)),
                        new RowDefinition(new GridLength(1, GridUnitType.Star)),
                    },
                    BackgroundColor = Styles.PageBackgroundColor,
                    Children =
                    {
                        new Grid
                        {
                            new BackgroundView {},
                            new ScrollView
                            {
                                //Background = Colors.Red,
                                Orientation = ScrollOrientation.Vertical,
                                Content = new VerticalStackLayout
                                {
                                    Children =
                                    {
                                        new ContentView
                                        {
                                            HeightRequest = 60,
                                        },
                                        insideView,
                                    },
                                },
                            },
                        }.Row(1).RowSpan(2),
                        new BoardView()
                        {
                            Background = Colors.Transparent,
                        }.Row(0).RowSpan(2)
                        .Bind(BoardView.PlayerCharacterProperty, source: this, path: nameof(PlayerCharacter)),
                },
                },
            },
        };
    }


    private ShellContent _abilitiesContent = null;
    public ShellContent AbilitiesContent => _abilitiesContent ??= 
        GetShellContentLayout(new AbilitiesView { }
        .Bind(AbilitiesView.AbilitiesProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Abilities))); 


    private ShellContent _skillsContent = null;
    public ShellContent SkillsContent => _skillsContent ??=
        GetShellContentLayout(new SkillsView { }
            .Bind(SkillsView.SkillsProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Skills)));


    private ShellContent _spellsContent = null;
    public ShellContent SpellsContent => _spellsContent ??= 
        GetShellContentLayout(new SpellbookView { }
            .Bind(SpellbookView.SpellsProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.SpellRefs))); //new ShellContent()


    private ShellContent _equipmentsContent = null;
    public ShellContent EquipmentsContent => _equipmentsContent ??= 
        GetShellContentLayout(new EquipmentsView { }
            .Bind(EquipmentsView.EquipmentSlotsProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.EquipmentRefs))); // new ShellContent


    private ShellContent _actionsContent = null;
    public ShellContent ActionsContent => _actionsContent ??= 
        GetShellContentLayout(new ActionsView { }
            .Bind(ActionsView.ActionsProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Actions))); // new ShellContent


    private ShellContent _featuresContent = null;
    public ShellContent FeaturesContent => _featuresContent ??= 
        GetShellContentLayout(new FeaturesView { }
            .Bind(FeaturesView.PlayerCharacterProperty, source: this, path: nameof(PlayerCharacter))); // new ShellContent
            //.Bind(FeaturesView.FeaturesProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Features))); // new ShellContent


    private ShellContent _conditionsContent = null;
    public ShellContent ConditionsContent => _conditionsContent ??= 
        GetShellContentLayout(new HealthView { }
            .Bind(HealthView.PlayerCharacterProperty, source: this, path: nameof(PlayerCharacter))); // new ShellContent
            //.Bind(HealthView.ConditionsProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Conditions))); // new ShellContent


    private ShellContent _progressionContent = null;
    public ShellContent ProgressionContent => _progressionContent ??= 
        //GetShellContentLayout(new ProgressionRazorView { }
            //.Bind(ProgressionView.PlayerCharacterProperty, source: this, path: nameof(PlayerCharacter))
            //);
    GetShellContentLayout(new ProgressionView { }
            .Bind(ProgressionView.PlayerCharacterProperty, source: this, path: nameof(PlayerCharacter)));


    public ShellContent UserModeContent => new ShellContent
    {
        Title = "Mode",
        Content = new ContentPage
        {
            Content = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
                    new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
                },
                RowDefinitions =
                {
                    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                },
                //HorizontalOptions = LayoutOptions.Start,
                Children =
                {
                    new Label { Text = "Débutant"}.Column(1).Row(0),
                    new Label { Text = "Avancé"}.Column(1).Row(1),
                    new Label { Text = "Debug"}.Column(1).Row(2),
                    new Microsoft.Maui.Controls.Switch
                    {
                    }.Column(0).Row(0)
                    .Bind(Microsoft.Maui.Controls.Switch.IsToggledProperty, source: this, path: nameof(Settings) + "." + nameof(Settings.UserMode), mode: BindingMode.TwoWay,
                        convert: (UserMode userMode) => {
                            return userMode == UserMode.Beginner;
                        },
                        convertBack: (bool selected) => {
                            if(selected)
                            {
                                Settings.UserMode = UserMode.Beginner;
                            }
                            return Settings.UserMode;
                        }),
                    new Microsoft.Maui.Controls.Switch
                    {
                    }.Column(0).Row(1)
                    .Bind(Microsoft.Maui.Controls.Switch.IsToggledProperty, source: this, path: nameof(Settings) + "." + nameof(Settings.UserMode), mode: BindingMode.TwoWay,
                        convert: (UserMode userMode) => {
                            return userMode == UserMode.Advanced;
                        },
                        convertBack: (bool selected) => {
                            if(selected)
                            {
                                Settings.UserMode = UserMode.Advanced;
                            }
                            return Settings.UserMode;
                        }),
                        //convert: (UserMode userMode) => userMode == UserMode.Advanced, convertBack: (bool selected) => UserMode.Advanced),
                    new Microsoft.Maui.Controls.Switch
                    {
                    }.Column(0).Row(2)
                    .Bind(Microsoft.Maui.Controls.Switch.IsToggledProperty, source: this, path: nameof(Settings) + "." + nameof(Settings.UserMode), mode: BindingMode.TwoWay,
                        convert: (UserMode userMode) => {
                            return userMode == UserMode.Debug;
                        },
                        convertBack: (bool selected) => {
                            if(selected)
                            {
                                Settings.UserMode = UserMode.Debug;
                            }
                            return Settings.UserMode;
                        }),
            }
            }
        }
    };

#if IOS || MACCATALYST
    private Tab _abilitiesTab = null;
    public Tab AbilitiesTab => _abilitiesTab ??= new Tab { Route = "abilities", Title = "Caractéristiques", Items = { AbilitiesContent } };

    private Tab _skillsTab = null;
    public Tab SkillsTab => _skillsTab ??= new Tab { Title = "Compétences", Items = { SkillsContent } };

    private Tab _actionsTab = null;
    public Tab ActionsTab => _actionsTab ??= new Tab { Title = "Actions", Items = { ActionsContent } };

    private Tab _conditionsTab = null;
    public Tab ConditionsTab => _conditionsTab ??= new Tab { Title = "Vie & États", Items = { ConditionsContent } };

    private Tab _equipmentsTab = null;
    public Tab EquipmentsTab => _equipmentsTab ??= new Tab { Title = "Équipement", Items = { EquipmentsContent } };

    private Tab _spellsTab = null;
    public Tab SpellsTab => _spellsTab ??= new Tab { Title = "Magie", Items = { SpellsContent } };
        //.Bind<Tab>(Tab.IsVisibleProperty, source: this, path: nameof(PlayerCharacter), converter: new FuncConverter<PlayerCharacter, bool>(pc => pc != null && pc.SpellRefs.Count > 0));

    private Tab _featuresTab = null;
    public Tab FeaturesTab => _featuresTab ??= new Tab { Title = "Dons & Traits", Items = { FeaturesContent } };

    private Tab _progressionTab = null;
    public Tab ProgressionTab => _progressionTab ??= new Tab { Title = "Progression", Items = { ProgressionContent } };

#if DEBUG
    private Tab _userModeTab = null;
    public Tab UserModeTab => _userModeTab ??= new Tab { Title = "DEBUG", Items = { UserModeContent } };
#endif // DEBUG

    private Tab _homeTab = null;
    public Tab HomeTab => _homeTab ??= new Tab { Title = "Accueil", Items = { new ShellContent { Content = new HomePage() } } };
#else // IOS
    private Tab _abilitiesTab = null;
    public Tab AbilitiesTab => _abilitiesTab ??= new Tab { Route = "abilities", Icon = "skills.png", Title = "Caractéristiques", Items = { AbilitiesContent } };

    private Tab _skillsTab = null;
    public Tab SkillsTab => _skillsTab ??= new Tab { Icon = "juggler.png", Title = "Compétences", Items = { SkillsContent } };

    private Tab _actionsTab = null;
    public Tab ActionsTab => _actionsTab ??= new Tab { Icon = "sword_clash.png", Title = "Actions", Items = { ActionsContent } };

    private Tab _conditionsTab = null;
    public Tab ConditionsTab => _conditionsTab ??= new Tab { Icon = "life_bar.png", Title = "Vie & États", Items = { ConditionsContent } };

    private Tab _equipmentsTab = null;
    public Tab EquipmentsTab => _equipmentsTab ??= new Tab { Icon = "light_backpack.png", Title = "Équipement", Items = { EquipmentsContent } };

    private Tab _spellsTab = null;
    public Tab SpellsTab => _spellsTab ??= new Tab { Icon = "spellbook.png", Title = "Magie", Items = { SpellsContent } };
        //.Bind<Tab>(Tab.IsVisibleProperty, source: this, path: nameof(PlayerCharacter), converter: new FuncConverter<PlayerCharacter, bool>(pc => pc != null && pc.SpellRefs.Count > 0));

    private Tab _featuresTab = null;
    public Tab FeaturesTab => _featuresTab ??= new Tab { Icon = "stars_stack.png", Title = "Dons & Traits", Items = { FeaturesContent } };

    private Tab _progressionTab = null;
    public Tab ProgressionTab => _progressionTab ??= new Tab { Icon = "progression.png", Title = "Progression", Items = { ProgressionContent } };

#if DEBUG
    private Tab _userModeTab = null;
    public Tab UserModeTab => _userModeTab ??= new Tab { Icon = "spotted_bug.png", Title = "DEBUG", Items = { UserModeContent } };
#endif // DEBUG

    private Tab _homeTab = null;
    public Tab HomeTab => _homeTab ??= new Tab { Route = "home2", Icon = "backup.png", Title = "Accueil", Items = { new ShellContent { Content = new HomePage() } } };
#endif // IOS

    public PlayerCharacterPage()
    {
        Route = "pc";
#if WINDOWS
        MainDisplayWidth = DeviceDisplay.MainDisplayInfo.Width;
        MainDisplayHeight = DeviceDisplay.MainDisplayInfo.Height;
#else
        MainDisplayWidth = DeviceDisplay.MainDisplayInfo.Width;
        MainDisplayHeight = DeviceDisplay.MainDisplayInfo.Height;
        DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
#endif

        Items.Add(AbilitiesTab);
        Items.Add(SkillsTab);
        Items.Add(ActionsTab);
        Items.Add(ConditionsTab);
        Items.Add(EquipmentsTab);
        Items.Add(SpellsTab);
        Items.Add(FeaturesTab);
        Items.Add(ProgressionTab);
#if DEBUG
        Items.Add(UserModeTab);
#endif // DEBUG
        Items.Add(HomeTab);
        
        Shell.SetTabBarIsVisible(HomeTab, false);
        CurrentItem = HomeTab;
    }

    public static readonly BindableProperty MainDisplayWidthProperty =
        BindableProperty.Create(nameof(MainDisplayWidth), typeof(double), typeof(MainPage), (double)0);
    public double MainDisplayWidth
    {
        get => (double)GetValue(MainDisplayWidthProperty);
        set => SetValue(MainDisplayWidthProperty, value);
    }
    public static readonly BindableProperty MainDisplayHeightProperty =
        BindableProperty.Create(nameof(MainDisplayHeight), typeof(double), typeof(MainPage), (double)0);
    public double MainDisplayHeight
    {
        get => (double)GetValue(MainDisplayHeightProperty);
        set => SetValue(MainDisplayHeightProperty, value);
    }
    /*
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        MainDisplayWidth = width;
        MainDisplayHeight = height;
    }*/
    private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
    {
        MainDisplayWidth = e.DisplayInfo.Width;
        MainDisplayHeight = e.DisplayInfo.Height;
    }
}

