using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.Data;
using System.Diagnostics;

namespace SRD5Helper;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new ContentPage(); // AppShell();
	}

    protected override async void OnStart() {
        base.OnStart();

        var storage = Ioc.Default.GetRequiredService<DataService>();
        try {
            //await storage.LoadSpellsAsync();
            await storage.LoadPlayerCharactersAsync();
            //var spellrefs = storage.PlayerCharacters["selmays"].SpellRefs;
            //foreach(var spellref in spellrefs)
            //         {
            //	Debug.WriteLine(spellref.Spell.Name);
            //	if (spellref.Spell.Conditions != null)
            //	{
            //		Debug.WriteLine("Conditions : " + spellref.Spell.Conditions.Aggregate("", (current, next) => current + "," + next));
            //	}
            //}
        }
        catch (Exception ex) {
            Debug.WriteLine(ex);
        }

#if DEBUG
        LogPCs();
        new UnitTests().TestU();

        //foreach (var pc in storage.PlayerCharacters)
        //{
        //    pc.Value.HasChanged = false;
        //}

        Debug.WriteLine($"Width = {DeviceDisplay.MainDisplayInfo.Width}");
        Debug.WriteLine($"Height = {DeviceDisplay.MainDisplayInfo.Height}");
        Debug.WriteLine($"Density = {DeviceDisplay.MainDisplayInfo.Density}");
        Debug.WriteLine($"Orientation = {DeviceDisplay.MainDisplayInfo.Orientation}");
        Debug.WriteLine($"Rotation = {DeviceDisplay.MainDisplayInfo.Rotation}");
        Debug.WriteLine($"Micro = {Device.GetNamedSize(NamedSize.Micro, typeof(Label))}");
        Debug.WriteLine($"Small = {Device.GetNamedSize(NamedSize.Small, typeof(Label))}");
        Debug.WriteLine($"Medium = {Device.GetNamedSize(NamedSize.Medium, typeof(Label))}");
        Debug.WriteLine($"Large = {Device.GetNamedSize(NamedSize.Large, typeof(Label))}");
        Debug.WriteLine($"Body = {Device.GetNamedSize(NamedSize.Body, typeof(Label))}");
        Debug.WriteLine($"Caption = {Device.GetNamedSize(NamedSize.Caption, typeof(Label))}");
        Debug.WriteLine($"Default = {Device.GetNamedSize(NamedSize.Default, typeof(Label))}");
        Debug.WriteLine($"Header = {Device.GetNamedSize(NamedSize.Header, typeof(Label))}");
        Debug.WriteLine($"Subtitle = {Device.GetNamedSize(NamedSize.Subtitle, typeof(Label))}");
        Debug.WriteLine($"Title = {Device.GetNamedSize(NamedSize.Title, typeof(Label))}");
#endif
        //        const int WindowWidth = 400;
        //        const int WindowHeight = 300;
        //        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        //        {
        //#if WINDOWS
        //            var mauiWindow = handler.VirtualView;
        //            var nativeWindow = handler.PlatformView;
        //            nativeWindow.Activate();
        //            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
        //            Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
        //            Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
        //            appWindow.Resize(new Windows.Graphics.SizeInt32(WindowWidth, WindowHeight));
        //#endif
        //        });

        MainPage = new Views.MainPage();
        //MainPage = new MainPage();
        //DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        Debug.WriteLine($"DeviceDisplay.Current.MainDisplayInfo {DeviceDisplay.Current.MainDisplayInfo.Width} / {DeviceDisplay.Current.MainDisplayInfo.Height} / {DeviceDisplay.Current.MainDisplayInfo.Orientation} / {DeviceDisplay.Current.MainDisplayInfo.Rotation} / {DeviceDisplay.Current.MainDisplayInfo.Density}");
    }

    private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e) {
        Debug.WriteLine($"DeviceDisplay_MainDisplayInfoChanged {e.DisplayInfo.Width} / {e.DisplayInfo.Height} / {e.DisplayInfo.Orientation} / {e.DisplayInfo.Rotation} / {e.DisplayInfo.Density}");
    }


    void LogPCs() {
        var storage = Ioc.Default.GetRequiredService<DataService>();
        foreach (var pc in storage.PlayerCharacters) {
            Debug.WriteLine(pc.Value);

            Debug.WriteLine("");
            Debug.WriteLine("");
        }
    }
}
