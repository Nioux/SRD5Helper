using CommunityToolkit.Mvvm.DependencyInjection;
using System.Runtime.CompilerServices;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class SlotsView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty SlotCountProperty =
	BindableProperty.Create(nameof(SlotCount), typeof(int), typeof(SlotsView), -1);

	public int SlotCount
	{
		get => (int)GetValue(SlotCountProperty);
		set { SetValue(SlotCountProperty, value); SetSlotsView(); }
	}

	public static readonly BindableProperty MaxSlotCountProperty =
	BindableProperty.Create(nameof(MaxSlotCount), typeof(int), typeof(SlotsView), -1);

	private static void SlotCountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var slotsView = bindable as SlotsView;
		slotsView.SetSlotsView();
    }

	public int MaxSlotCount
	{
		get => (int)GetValue(MaxSlotCountProperty);
		set { SetValue(MaxSlotCountProperty, value); SetSlotsView(); }
	}

  //  protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
  //  {
  //      base.OnPropertyChanged(propertyName);
		//if(propertyName == nameof(SlotCount) || propertyName == nameof(MaxSlotCount))
  //      {
		//	SetSlotsView();
		//}
  //  }

	public void SetSlotsView()
	{
		var stack = new StackLayout
		{
			Spacing = 5,
			Orientation = StackOrientation.Horizontal,
		};
		for (int i = 0; i < SlotCount; i++)
		{
			stack.Children.Add(new HexagonView { HexagonHeight = 20, Style = Styles.DefaultListBulletTrue });
		}
		for (int i = SlotCount; i < MaxSlotCount; i++)
		{
			stack.Children.Add(new HexagonView { HexagonHeight = 20, Style = Styles.DefaultListBulletFalse });
		}
		Content = stack;
	}
}