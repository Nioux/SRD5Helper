using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Controls.StyleSheets;
using SRD5Helper.Data;
using SRD5Helper.ViewModels;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class HomePage : ContentPage
{
    public HomePage()
    {
        //using (var reader = new StringReader("^contentpage { background-image: background_dark.png; }"))
        //{
        //    this.Resources.Add(StyleSheet.FromReader(reader));
        //}
        
        //BackgroundImageSource = ImageSource.FromFile("background_light.png");
        //BackgroundColor = Colors.White;
        //Background = new ImageBrush {  }; new FileImageSource { File = "" }; // ImageSource.FromFile("background_dark.png"));
        //var webView = new Microsoft.Maui.Controls.WebView { Source = new HtmlWebViewSource { Html = "<![CDATA[<html><head></head><body><h1>.NET MAUI</h1><p>The CSS and image are loaded from local files!</p><p><a href=\"Dices/index.html\">next page</a></p></body></html>]]>" } };

        //webView.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetMixedContentMode(Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.MixedContentHandling.AlwaysAllow);
        //webView.HandlerChanged += WebView_HandlerChanged;
        //Content = webView;

        Content = new Grid
        {
            Children =
            { 
                //new Image
                //{
                //    Source = "background_light.png",
                //    Aspect = Aspect.Center,
                //},
                new BackgroundView {},
                new ScrollView
                {
                    Content = new VerticalStackLayout
                    {
                        Margin = new Thickness(20),
                        Children =
                        {
                            new Image { HeightRequest = 150, Source = "logo_big.png" },
                            PlayerCharactersView,
                        },
                    },
                },
            },
        };
    }

    private void WebView_HandlerChanged(object sender, EventArgs e)
    {
        #if ANDROID         
        var handler = (sender as Microsoft.Maui.Controls.WebView).Handler as Microsoft.Maui.Handlers.WebViewHandler;         
        var webView = handler.PlatformView;         
        webView.Settings.AllowFileAccessFromFileURLs = true;         
        webView.Settings.AllowUniversalAccessFromFileURLs = true; 
        #endif
    }

    private DataService _storage = null;
    public DataService Storage => _storage ??= Ioc.Default.GetRequiredService<DataService>();

    private List<PlayerCharacter> _playerCharacters = null;
    public List<PlayerCharacter> PlayerCharacters => _playerCharacters ??= Storage.PlayerCharacters.Values.ToList();

    private FlexLayout _playerCharactersView = null;
    public FlexLayout PlayerCharactersView => _playerCharactersView ??= new FlexLayout
    {
        Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
        Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
        JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceAround,
        Padding = new Thickness(20),
        Margin = new Thickness(20),
        //ColumnSpacing = 20,
        //ColumnDefinitions =
        //{
        //    new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
        //},
        //RowDefinitions =
        //{
        //    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new RowDefinition(new GridLength(1, GridUnitType.Auto)),

        //    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
        //    new RowDefinition(new GridLength(1, GridUnitType.Auto)),

        //    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
        //},
        Children =
        {
            GetPlayerPictureView(PlayerCharacters[0]),
            GetPlayerPictureView(PlayerCharacters[1]),
            GetPlayerPictureView(PlayerCharacters[2]),
            GetPlayerPictureView(PlayerCharacters[3]),
            GetPlayerPictureView(PlayerCharacters[4]),
            GetPlayerPictureView(PlayerCharacters[5]),
            GetPlayerPictureView(PlayerCharacters[6]),
            GetPlayerPictureView(PlayerCharacters[7]),
            GetPlayerPictureView(PlayerCharacters[8]),
            GetPlayerPictureView(PlayerCharacters[9]),
            GetPlayerPictureView(PlayerCharacters[10]),
        }
    };

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    Ioc.Default.GetRequiredService<Settings>().CurrentPlayerCharacter = null;
    //}
    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();

    public Border GetPlayerPictureView(PlayerCharacter pc)
    {
        var _playerPictureView = new Border
        {
            Stroke = Color.FromArgb("#000000"),
            Background = Color.FromArgb("#ffffff"),
            StrokeThickness = 1,
            HorizontalOptions = LayoutOptions.End,
            Shadow = new Shadow { Brush = Brush.Black, Opacity = 0.5f, Offset = new Point(10, 10), },
            StrokeShape = new Microsoft.Maui.Controls.Shapes.Path
            {
                Stroke = Colors.Black,
                Aspect = Stretch.Uniform,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = 140,
                //WidthRequest = 160,
                Data = Geometries.HexagonGeometry, // (Geometry)new PathGeometryConverter().ConvertFromInvariantString("M256 21.52l-4.5 2.597L52.934 138.76v234.48L256 490.48l203.066-117.24V138.76L256 21.52z"),
            },


            //Stroke = Color.FromArgb("#000000"),
            //Background = Color.FromArgb("#ffffff"),
            //StrokeThickness = 1,
            //HorizontalOptions = LayoutOptions.End,
            //Shadow = new Shadow { Brush = Brush.White, Opacity = 0.5f, Offset = new Point(10, 10), },
            //StrokeShape = HexagonGeometry.GetRegularHexagonPathGeometry(160),

            //StrokeShape = new RoundRectangle
            //{
            //    CornerRadius = new CornerRadius(40, 0, 0, 40)
            //},                        
            //BackgroundColor = Colors.Black,
            WidthRequest = 140,
            HeightRequest = 140,
            //Margin = new Thickness(15),
            Padding = new Thickness(0),
            VerticalOptions = LayoutOptions.Start,
        };
        var button = new Microsoft.Maui.Controls.ImageButton { Source = pc.CharacterSmallPicture }
            //.Bind(ImageButton.SourceProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.CharacterSmallPicture))
            .Trigger(GetEventActionTrigger<Microsoft.Maui.Controls.ImageButton>("Pressed", (sender) =>
            {
                var border = sender.Parent as Border;
                border.TranslationX = 5;
                border.TranslationY = 5;
                border.Shadow.Offset = new Point(5, 5);
            }))
            .Trigger(GetEventActionTrigger<Microsoft.Maui.Controls.ImageButton>("Released", (sender) =>
            {
                var border = sender.Parent as Border;
                border.TranslationX = 0;
                border.TranslationY = 0;
                border.Shadow.Offset = new Point(10, 10);
            }));
        button.Command = Ioc.Default.GetRequiredService<PlayerCharacterCommands>().SetPlayerCharacterCommand;
        button.CommandParameter = pc;

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
        return _playerPictureView;
    }

    private void Button_Pressed(object sender, EventArgs e)
    {
        throw new NotImplementedException();
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
}