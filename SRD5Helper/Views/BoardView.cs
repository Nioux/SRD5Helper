
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Maui.Controls.Shapes;
using SRD5Helper.ViewModels;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class BoardView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();

    public static readonly BindableProperty PlayerCharacterProperty =
        BindableProperty.Create(nameof(PlayerCharacter), typeof(PlayerCharacter), typeof(BoardView), null);

    public PlayerCharacter PlayerCharacter
    {
        get => (PlayerCharacter)GetValue(PlayerCharacterProperty);
        set => SetValue(PlayerCharacterProperty, value);
    }

    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();



    private Span CharacterTitleSpan => 
        new Span 
        { 
            FontFamily = Styles.TitleFontFamily, 
            FontSize = Styles.TitleLabelFontSize, 
        }
        //.Bind(Span.TextColorProperty, source: this, path: NameOf(() => PlayerCharacter.HasChanged), convert: (bool changed) => changed ? Colors.Red : Colors.White)
        .Bind(Span.TextProperty, source: this, path: NameOf(() => PlayerCharacter.CharacterName));
        //.Bind(Span.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.CharacterName)}");

    private Span PrimaryClassSpan =>
        new Span { }
        .Bind(Span.TextProperty, source: this, path: NameOf(() => PlayerCharacter.PrimaryClass.Name));
        //.Bind(Span.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.PrimaryClass)}.{nameof(PlayerCharacter.PrimaryClass.Name)}");

    private Span OriginSpan =>
        new Span { }
        .Bind(Span.TextProperty, source: this, path: NameOf(() => PlayerCharacter.Origin.Name));

    private Span LevelSpan =>
        new Span { }
        .Bind(Span.TextProperty, source: this, path: NameOf(() => PlayerCharacter.Level), convert: (int level) => $"NIV. {level}");

    private Span SpaceSpan => new Span { Text = " " };
    private Span ReturnSpan => new Span { Text = "\n" };

    private View _characterTitleView = null;
    private View CharacterTitleView =>
        _characterTitleView ??=
            new Label
            {
                FontFamily = Styles.BasicFontFamily,
                FontSize = Styles.DefaultLabelFontSize,
                TextColor = Colors.White,
                TextTransform = TextTransform.Uppercase,
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        CharacterTitleSpan,
                        ReturnSpan,
                        OriginSpan,
                        SpaceSpan,
                        PrimaryClassSpan,
                        SpaceSpan,
                        LevelSpan,
                    },
                },
            }
            .BindTapGesture(commandSource: this, commandPath: NameOf(() => PlayerCharacterCommands.UpLevelCommand), parameterSource: this, parameterPath: NameOf(() => PlayerCharacter));

    private View _proficiencyBonusView = null;
    public View ProficiencyBonusView => _proficiencyBonusView ??= new BoardAttributeButton()
    {
        NameFontSize = Styles.MicroLabelFontSize,
        ValueFontSize = Styles.TitleLabelFontSize,
        StrokeShape = new RoundRectangle
        {            
            Stroke = Colors.Red, // Color.FromArgb("77FF0000"),// Colors.Black,
            CornerRadius = new CornerRadius(100)
        },
        Name = "MAIT.",
    }
    .Bind(BoardAttributeButton.ValueProperty, source: this, path: NameOf(() => PlayerCharacter.ProficiencyBonus), convert: (int val) => $"{val:+0;-#}");

    private View _intiativeView = null;
    public View InitiativeView => _intiativeView ??= new BoardAttributeButton()
    {
        NameFontSize = Styles.MicroLabelFontSize,
        ValueFontSize = Styles.TitleLabelFontSize,
        StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(10)
        },
        Name = "INIT.",
    }
    .Bind(BoardAttributeButton.ValueProperty, source: this, path: NameOf(() => PlayerCharacter.Initiative), convert: (int val) => $"{val:+0;-#}");
    
    private View _armorClassView = null;
    public View ArmorClassView => _armorClassView ??= new BoardAttributeButton()
    {
        NameFontSize = Styles.MicroLabelFontSize,
        ValueFontSize = Styles.TitleLabelFontSize,
        StrokeShape = new Microsoft.Maui.Controls.Shapes.Path
        {
            Stroke = Colors.Black,
            Aspect = Stretch.Uniform,
            HorizontalOptions = LayoutOptions.Center,
            Data = Geometries.ShieldGeometry,
        },
        Name = "CA",
    }
    .Bind(BoardAttributeButton.ValueProperty, source: this, path: NameOf(() => PlayerCharacter.ArmorClass), convert: (int val) => $"{val}");

    private View _hitPointsView = null;
    public View HitPointsView => _hitPointsView ??= new BoardAttributeButton()
    {
        NameFontSize = Styles.MicroLabelFontSize,
        ValueFontSize = Styles.TitleLabelFontSize,
        StrokeShape = new Microsoft.Maui.Controls.Shapes.Path
        {
            Stroke = Colors.Black,
            Aspect = Stretch.Uniform,
            HorizontalOptions = LayoutOptions.Center,
            Data = Geometries.HeartGeometry,
        },
        Name = "PV",
    }
    .Bind(BoardAttributeButton.ValueProperty, source: this, path: NameOf(() => PlayerCharacter.TotalTemporaryHitPoints), convert: (int val) => $"{val}");
    
    private View _generalAttributesView = null;
    private View GeneralAttributesView => _generalAttributesView ??= new HorizontalStackLayout
    {
        Children =
        {
            ProficiencyBonusView,
            InitiativeView,
            ArmorClassView,
            HitPointsView,
        }
    };

    public BoardView()
    {
        Content = new Grid
        {
            ColumnDefinitions = new()
            {
                new ColumnDefinition(new GridLength(1, GridUnitType.Star)),
                new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
            },
            RowDefinitions = new()
            {
                new RowDefinition(new GridLength(0, GridUnitType.Auto)),
                new RowDefinition(new GridLength(0, GridUnitType.Auto)),
            },
            Children =
            {
                BackgroundView.Column(0).ColumnSpan(2).Row(0).RowSpan(2),
                CharacterTitleView.Margin(new Thickness(20, 20, 20, 0)).Column(0).Row(0),
                PlayerPictureView.Column(1).Row(0).RowSpan(2),
                GeneralAttributesView.Column(0).Row(1),
            }
        };
    }

    private View _backgroundView = null;
    private View BackgroundView => _backgroundView ??= new Grid
    {
        HeightRequest = Styles.TitleLabelFontSize * 4,
        VerticalOptions = LayoutOptions.Start,
#if IOS || MACCATALYST
        BackgroundColor = Colors.DarkBlue,
#else
        Children =
        {
            new Image
            {
                Source = "background_dark.png",
                Aspect = Aspect.AspectFill,
                VerticalOptions = LayoutOptions.Start,
            },
        },
#endif // !IOS
    };

    private Border _playerPictureView = null;
    public Border PlayerPictureView
    {
        get
        {
            if (_playerPictureView == null)
            {
                _playerPictureView ??= new Border
                {
                    Stroke = Color.FromArgb("#000000"),
                    Background = Color.FromArgb("#ffffff"),
                    StrokeThickness = 1,
                    HorizontalOptions = LayoutOptions.End,
                    Shadow = new Shadow { Brush = Brush.White, Opacity = 0.5f, Offset = new Point(10, 10), },
                    StrokeShape = new Microsoft.Maui.Controls.Shapes.Path
                    {
                        Stroke = Colors.Black,
                        Aspect = Stretch.Uniform,
                        HorizontalOptions = LayoutOptions.Center,
                        HeightRequest = Styles.TitleLabelFontSize * 3,
                        Data = Geometries.HexagonGeometry,
                    },
                    WidthRequest = Styles.TitleLabelFontSize * 3,
                    HeightRequest = Styles.TitleLabelFontSize * 3,
                    Margin = new Thickness(15),
                    Padding = new Thickness(0),
                    VerticalOptions = LayoutOptions.Start,
                };
                var button = new ImageButton { }
                    .Bind(ImageButton.SourceProperty, source: this, path: NameOf(() => PlayerCharacter.CharacterSmallPicture))
                    .ShadowClickEffect();
                    /*.Trigger(GetEventActionTrigger<ImageButton>("Pressed", (sender) => 
                    {
                        var border = sender.Parent as Border;
                        border.TranslationX = 5;
                        border.TranslationY = 5;
                        border.Shadow.Offset = new Point(5, 5);
                    }))
                    .Trigger(GetEventActionTrigger<ImageButton>("Released", (sender) =>
                     {
                         var border = sender.Parent as Border;
                         border.TranslationX = 0;
                         border.TranslationY = 0;
                         border.Shadow.Offset = new Point(10, 10);
                     }));*/


                /*var triggerPressed = new Trigger(typeof(ImageButton))
                {
                    Property = ImageButton.IsPressedProperty,
                    Value = true,
                };
                triggerPressed.Setters.Add(new Setter()
                {
                    TargetName = (_playerPictureView as FrameworkElement)
                });*/

                /*                
                                var triggerPressed = new EventTrigger()
                                {
                                    Event = "Pressed",
                                };
                                triggerPressed.Actions.Add(new InlineTriggerAction<ImageButton>
                                {
                                    OnInvoke = (sender) =>
                                    {
                                        var border = sender.Parent as Border;
                                        border.TranslationX = 3;
                                        border.TranslationY = 3;
                                        border.Shadow.Offset = new Point(5, 5);
                                    }
                                });
                                button.Triggers.Add(triggerPressed);*/
                //var triggerReleased = new EventTrigger()
                //{
                //    Event = "Released",
                //};
                //triggerReleased.Actions.Add(new InlineTriggerAction<ImageButton> 
                //{
                //    OnInvoke = (sender) =>
                //    {
                //        var border = sender.Parent as Border;
                //        border.TranslationX = 0;
                //        border.TranslationY = 0;
                //        border.Shadow.Offset = new Point(10, 10);
                //    }
                //}); // ButtonReleasedTriggerAction());
                //button.Triggers.Add(triggerReleased);
                /*button.Pressed += (sender, args) =>
                {
                    _playerPictureView.TranslationX = 5;
                    _playerPictureView.TranslationY = 5;
                    _playerPictureView.Shadow = new Shadow { Brush = Brush.Blue, Opacity = 0.5f, Offset = new Point(5, 5), };
                };
                button.Released += (sender, args) =>
                {
                    _playerPictureView.TranslationX = 0;
                    _playerPictureView.TranslationY = 0;
                    _playerPictureView.Shadow = new Shadow { Brush = Brush.Blue, Opacity = 0.5f, Offset = new Point(10, 10), };
                };*/
                _playerPictureView.Content = button;
            }
            return _playerPictureView;
        }
    }
    public class InlineTriggerAction<T> : TriggerAction<T> where T : BindableObject
    {
        public Action<T> OnInvoke;
        protected override void Invoke(T sender)
        {
            OnInvoke?.Invoke(sender);
        }
    }

    public TriggerBase GetEventActionTrigger<TBindableObject>(string eventTrigger, Action<TBindableObject> onInvoke) where TBindableObject : View
    {
        var trigger = new EventTrigger()
        {
            Event = eventTrigger,
        };
        trigger.Actions.Add(new InlineTriggerAction<TBindableObject>
        {
            OnInvoke = onInvoke
        });
        return trigger;
    }
    //public class ButtonPressedTriggerAction : TriggerAction<ImageButton>
    //{
    //    protected override void Invoke(ImageButton button)
    //    {
    //        var border = button.Parent as Border;
    //        border.TranslationX = 3;
    //        border.TranslationY = 3;
    //        border.Shadow.Offset = new Point(5, 5);
    //    }
    //}
    //public class ButtonReleasedTriggerAction : TriggerAction<ImageButton>
    //{
    //    protected override void Invoke(ImageButton button)
    //    {
    //        var border = button.Parent as Border;
    //        border.TranslationX = 0;
    //        border.TranslationY = 0;
    //        border.Shadow.Offset = new Point(10, 10);
    //    }
    //}
}
