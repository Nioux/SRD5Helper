using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class ProficienciesView : ContentView
{
	public ProficienciesView()
	{
		Content = new StackLayout
		{
			Children = {
				new Label { Text = "Welcome to .NET MAUI!" }
			}
		};
	}
}