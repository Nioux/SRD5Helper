using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.DependencyInjection;
using MauiGestures;
using SRD5Helper.Data;
using SRD5Helper.Views;

namespace SRD5Helper;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        /*var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();*/
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            //.UseSkiaSharp()
            .AddAdvancedGestures()
            //.UseMauiCompatibility()
            //.ConfigureEssentials(builder => { builder.AddAppAction(new AppAction("machin", "Youhou")); })
            .ConfigureMauiHandlers(handlers => {
                handlers.AddMauiControlsHandlers(); //(typeof(Xamarin.CommunityToolkit.UI.Views.TabView).Assembly);
                                                    //	// Register ALL handlers in the Xamarin Community Toolkit assembly
                                                    //	handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.TabView).Assembly);

                //handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.MediaElementRenderer).Assembly);
                //handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.MediaElement).Assembly);
            })
            .UseMauiCommunityToolkit()
            //.UseMauiCompatibility()
            //.ConfigureMauiHandlers(handlers =>
            //{
            //	// Register ALL handlers in the Xamarin Community Toolkit assembly
            //	//handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.MediaElementRenderer).Assembly);
            //	handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.PopupRenderer).Assembly);

            //	// Register just one handler for the control you need
            //	//handlers.AddCompatibilityRenderer(typeof(Xamarin.CommunityToolkit.UI.Views.MediaElement), typeof(Xamarin.CommunityToolkit.UI.Views.MediaElementRenderer));
            //})
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("WolgastTwoBold.otf", "WolgastTwoBold");
                fonts.AddFont("WolgastTwoNormal.otf", "WolgastTwoNormal");
                fonts.AddFont("LiberationSans-Regular.ttf", "LiberationSansRegular");
                fonts.AddFont("LiberationSans-Bold.ttf", "LiberationSansBold");
                fonts.AddFont("LiberationSans-Italic.ttf", "LiberationSansItalic");
                fonts.AddFont("LiberationSans-BoldItalic.ttf", "LiberationSansBoldItalic");
                fonts.AddFont("FontAwesome6Brands-Regular-400.otf", "FontAwesome6BrandsRegular");
                fonts.AddFont("FontAwesome6Free-Regular-400.otf", "FontAwesome6FreeRegular");
                fonts.AddFont("FontAwesome6Free-Solid-900.otf", "FontAwesome6FreeSolid");
                fonts.AddFont("CapitalisTypOasis.ttf", "CapitalisTypOasis");
                fonts.AddFont("Florsn33.ttf", "Florencesans");
                //fonts.AddFont("FontAwesome6Free-Regular-400.otf", "FontAwesome");
                fonts.AddFont("game-icons.ttf", "GameIcons");
                fonts.AddFont("d20.ttf", "d20");
                fonts.AddFont("Dices.ttf", "Dices");
                //fonts.AddFont("Dices.ttf", "Untitled1");
            })
            .ConfigureEffects(effects => {
#if __ANDROID__
                //effects.Add<TouchEffect, Xamarin.CommunityToolkit.Android.Effects.PlatformTouchEffect>();
                //effects.Add<Xamarin.CommunityToolkit.UI.Views.Expander, Xamarin.CommunityToolkit.UI.Views.Expander>();
#elif WINDOWS
                //effects.Add<TouchEffect, Xamarin.CommunityToolkit.Effects..Effects.TouchEffect>();
#endif
            });//.ConfigureGraphicsControls();

        //builder.Services.AddMauiBlazorWebView();
#if DEBUG
        //builder.Services.AddMauiBlazorWebViewDeveloperTools();
#endif

        Ioc.Default.ConfigureServices(new ServiceCollection()
            .AddSingleton<DataService>()
            .AddSingleton<Settings>()
            .AddSingleton<PlayerCharacterCommands>()
            .AddSingleton<Styles>()
            .BuildServiceProvider());

        //builder.ConfigureServices((c, x) => { });// .Services.AddSingleton<StorageService>();
        return builder.Build();

    }
}
