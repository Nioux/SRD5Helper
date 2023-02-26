using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.Data;
using System.Diagnostics;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class MainPage : Shell
{
    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();
    public DataService Storage => Ioc.Default.GetRequiredService<DataService>();
    public MainPage()
    {
        BackgroundColor = Colors.White;

/*        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
#if ANDROID*/
            Items.Add(new PlayerCharacterPage { }
                .Bind(PlayerCharacterPage.PlayerCharacterProperty, source: Settings, path: nameof(Settings.CurrentPlayerCharacter))); // PlayerCharacter = pc, Title = pc.CharacterName });
        /*#endif
                }
                else
                {
        #if WINDOWS
                    foreach (var pc in Storage.PlayerCharacters.Values)
                    {
                        Items.Add(new ShellContent
                        {
                            Title = pc.CharacterName,
                            Content = new ContentPage
                            {
                                BackgroundImageSource = "background.jpg",
                                //Content = new ScrollView
                                //{
                                //    HeightRequest = 500,
                                //    WidthRequest = 500,
                                Content = new FlatPlayerCharacterPage { PlayerCharacter = pc }
                                //.Bind(FlatPlayerCharacterPage.PlayerCharacterProperty, path: nameof(PlayerCharacter))
                                //}
                            }
                        });
                    }
        #endif
                }*/

        this.SizeChanged += MainPage_SizeChanged;
        this.LayoutChanged += MainPage_LayoutChanged;
#if !WINDOWS
        DeviceDisplay.Current.MainDisplayInfoChanged += Current_MainDisplayInfoChanged;
#endif
    }

    private void Current_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
    {
        Debug.WriteLine("MainDisplayInfoChanged");
        Debug.WriteLine($"Width = {e.DisplayInfo.Width}");
        Debug.WriteLine($"Height = {e.DisplayInfo.Height}");
        Debug.WriteLine($"Density = {e.DisplayInfo.Density}");
        Debug.WriteLine($"Orientation = {e.DisplayInfo.Orientation}");
        Debug.WriteLine($"Rotation = {e.DisplayInfo.Rotation}");
        Debug.WriteLine($"Micro = {Device.GetNamedSize(NamedSize.Micro, typeof(Label))}");
        Debug.WriteLine($"Small = {Device.GetNamedSize(NamedSize.Small, typeof(Label))}");
        Debug.WriteLine($"Medium = {Device.GetNamedSize(NamedSize.Medium, typeof(Label))}");
        Debug.WriteLine($"Large = {Device.GetNamedSize(NamedSize.Large, typeof(Label))}");
    }

    private void MainPage_SizeChanged(object sender, EventArgs e)
    {
        Debug.WriteLine("MainPage_SizeChanged");
    }

    private void MainPage_LayoutChanged(object sender, EventArgs e)
    {
        Debug.WriteLine("MainPage_LayoutChanged");
    }

}

