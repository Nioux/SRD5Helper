namespace SRD5Helper.Views;

public class BackgroundView : ContentView
{
	public BackgroundView()
	{
        Content = new Image
        {
            Source = "background_light.png",
            Aspect = Aspect.Center,
        };
	}
}