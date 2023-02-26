using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui.Views;
using SRD5Helper.DataModels;
using SRD5Helper.Resources.Library;
using SRD5Helper.ViewModels;
using System.Collections;

namespace SRD5Helper.Views;

public class EquipmentsPicker : ContentView
{
	public static async Task<IEnumerable<Tuple<int, Equipment>>> PickAsync(IReadOnlyList<EquipmentDatum> equipmentList)
	{
        var popup = new Popup
        {
            //HorizontalOptions = Microsoft.Maui.Primitives.LayoutAlignment,
            //VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.End,
            CanBeDismissedByTappingOutsideOfPopup = true,
            Content = new EquipmentsPicker
            { 
                Equipments = equipmentList,
				//ItemsSource = equipmentList, 
				//ItemTemplate = new DataTemplate(() => new Equi { }.Bind(Label.TextProperty, convert: (Equipment equipment) => equipment.Name)),
                //ItemTemplate = new DataTemplate(() => new Label { }.Bind(Label.TextProperty, convert: (Equipment equipment) => equipment.Name)),
            }, 
        };
        var result = await SRD5Helper.App.Current.MainPage.ShowPopupAsync(popup);
        return result as IEnumerable<Tuple<int, Equipment>>;
    }

    public static readonly BindableProperty EquipmentsProperty =
    BindableProperty.Create(nameof(Equipments), typeof(IList), typeof(EquipmentsPicker), null);

    public IReadOnlyList<EquipmentDatum> Equipments
    {
        get => (IReadOnlyList<EquipmentDatum>)GetValue(EquipmentsProperty);
        set => SetValue(EquipmentsProperty, value);
    }

    public EquipmentsPicker()
	{
        Content = new CollectionView
        {
            //ItemsSource = equipmentList,
            ItemTemplate = new DataTemplate(() => 
            new EquipmentPickerItemView { }.Bind(EquipmentPickerItemView.EquipmentProperty)),
            //ItemTemplate = new DataTemplate(() => new Label { }.Bind(Label.TextProperty, convert: (Equipment equipment) => equipment.Name)),
        }.Bind(CollectionView.ItemsSourceProperty, source: this, path: nameof(Equipments));
		//Content = new VerticalStackLayout
		//{
		//	Children = {
		//		new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
		//		}
		//	}
		//};
	}
}

public class EquipmentPickerItemView : ContentView
{

    public static readonly BindableProperty EquipmentProperty =
        BindableProperty.Create(nameof(Equipment), typeof(EquipmentDatum), typeof(EquipmentPickerItemView), null);

    public EquipmentDatum Equipment
    {
        get => (EquipmentDatum)GetValue(EquipmentProperty);
        set => SetValue(EquipmentProperty, value);
    }

    public EquipmentPickerItemView()
    {
        Content = new Label { }.Bind(Label.TextProperty, source: this, path: nameof(Equipment), convert: (EquipmentDatum equipment) => equipment.Name);
    }
}