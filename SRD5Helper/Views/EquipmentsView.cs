using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using SRD5Helper.DataModels;
using SRD5Helper.Tools;
using SRD5Helper.ViewModels;
using System.Collections;
using System.Runtime.CompilerServices;
using static SRD5Helper.Tools.Helpers;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Views;

public class EquipmentsView : ContentView
{
    public static readonly BindableProperty EquipmentSlotsProperty =
        BindableProperty.Create(nameof(EquipmentSlots), typeof(EquipmentRefs), typeof(EquipmentsView), null);

    public EquipmentRefs EquipmentSlots
    {
        get => (EquipmentRefs)GetValue(EquipmentSlotsProperty);
        set
        {
            SetValue(EquipmentSlotsProperty, value);
        }
    }
    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();
    /*
    public EquipmentsView()
    {
        //Background = Color.FromArgb("D1D5DD");
        // bindable layouts
        // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/bindable-layouts

        var collectionView = new CollectionView { }
                .Bind(CollectionView.ItemsSourceProperty, source: this, path: nameof(EquipmentSlots));


        var template1 = new DataTemplate(
                () =>
                {
                    var grid = new Grid
                    {
                        //Background = Color.FromArgb("CDD1D9"),
                        //ColumnSpacing = 10,
                        //RowSpacing = 10,
                        //RowSpacing = 10,
                        ColumnDefinitions = new ColumnDefinitionCollection
                        {
                            new ColumnDefinition { Width = new GridLength(40) },
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                            new ColumnDefinition { Width = new GridLength(30) },
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
                            new ColumnDefinition { Width = 10 },
                        },
                        RowDefinitions = new RowDefinitionCollection
                        {
                            new RowDefinition { Height = new GridLength(40) },
                        },
                        Children =
                        {
                            new CheckBox { WidthRequest = 40, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center }
                                .Bind(CheckBox.IsVisibleProperty, path: $"{nameof(Equipment.Datum)}.{nameof(Equipment.Datum.IsEquippable)}")
                                .Bind(CheckBox.IsCheckedProperty, path: nameof(Equipment.IsEquipped), mode: BindingMode.TwoWay),
                            //new HexagonView { HeightRequest = 30, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center }
                            //    .Bind(HexagonView.HexagonHeightProperty, path: $"{nameof(Equipment.Datum)}.{nameof(Equipment.Datum.IsEquippable)}", convert: (bool isEquippable) => isEquippable ? 30 : 0)
                            //    .Bind(HexagonView.BackgroundProperty, path: nameof(Equipment.IsEquipped), convert: (bool isEquipped) => isEquipped ? Color.FromArgb("586573") : Color.FromArgb("B1A89F")),

                            new Label { FontFamily = "LiberationSansRegular", HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center }
                                .ColumnRow(column: 1)
                                .Bind(Label.TextProperty, path: $"{nameof(Equipment.Datum)}.{nameof(Equipment.Datum.Name)}", convert: (string name) => $"{name}"),

                            new Label { FontFamily = "WolgastTwoBold", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center }
                                .ColumnRow(column: 2)
                                .Bind(Label.TextProperty, path: $"{nameof(Equipment.Quantity)}", convert: (int quantity) => $"{quantity}"),

                            new Button { Text = "\uf059", TextColor = Colors.DarkBlue, FontFamily = "FontAwesome6FreeRegular", FontSize = 25, BackgroundColor = Colors.Transparent, BorderColor = Colors.Transparent }
                                .ColumnRow(column: 3)
                                .BindCommand(source: this, path: $"{nameof(PlayerCharacterCommands)}.{nameof(PlayerCharacterCommands.ShowEquipmentDescriptionCommand)}", parameterPath: ".")
                                //.BindCommand(path: nameof(Equipment.ShowDescriptionCommand)),
                        }
                    };
                    return grid;
                }
            );
        collectionView.ItemTemplate = template1;
        Content = collectionView;
    }

    async Task ExecuteEquipmentSlotTappedAsync(Equipment slot)
    {
        slot.IsEquipped = !slot.IsEquipped;
    }
    */





    public static readonly BindableProperty EquipmentsByTypeProperty =
        BindableProperty.Create(nameof(EquipmentsByType), typeof(IEnumerable), typeof(EquipmentsView), null);

    public IEnumerable<IGrouping<EquipmentType, Equipment>> EquipmentsByType
    {
        get => (IEnumerable<IGrouping<EquipmentType, Equipment>>)GetValue(EquipmentsByTypeProperty);
        set => SetValue(EquipmentsByTypeProperty, value);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(EquipmentSlots))
        {
            EquipmentsByType = EquipmentSlots.GroupBy(slot => 
                EquipmentType.Weapon.HasFlag(slot.Type) ? EquipmentType.Weapon :
                EquipmentType.Armor.HasFlag(slot.Type) ? EquipmentType.Armor :
                slot.Type);
        }
        if (propertyName == nameof(EquipmentsByType))
        {
            BindableLayout.SetItemsSource(EquipmentListView, EquipmentsByType);
        }
    }

    private View _equipmentListView = null;
    public View EquipmentListView => _equipmentListView ??= new FlexLayout
    {
        JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
        AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
        AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start,
        Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
        Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
    };

    public EquipmentsView()
    {
        Content = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
            },
            Children =
            {
                new Button
                {
                    Text = "Ajouter",
                    Command = new AsyncRelayCommand(async() =>
                    {
                        var pc = Ioc.Default.GetRequiredService<Settings>().CurrentPlayerCharacter;
                        await Ioc.Default.GetRequiredService<PlayerCharacterCommands>().ExportPDFPlayerCharacterCommand.ExecuteAsync(pc);
                        //var items = Ioc.Default.GetRequiredService<DataService>().EquipmentsData.Values.ToList();
                        //var result = await EquipmentsPicker.PickAsync(items);
                    }),
                },
                EquipmentListView.Row(1),
            },
        };
        BindableLayout.SetItemTemplate(EquipmentListView,
            new DataTemplate(() =>
            new GroupedEquipmentsView { }
            .Bind(GroupedEquipmentsView.GroupedEquipmentsProperty)));
    }

}




public class GroupedEquipmentsDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate EvenTemplate { get; set; }
    public DataTemplate UnevenTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var spells = (BindableLayout.GetItemsSource(container) as IGrouping<EquipmentType, Equipment>).ToList();
        return spells.IndexOf(item as Equipment) % 2 == 0 ? EvenTemplate : UnevenTemplate;
    }
}

public class GroupedEquipmentsView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty GroupedEquipmentsProperty =
        BindableProperty.Create(nameof(GroupedEquipments), typeof(IGrouping<EquipmentType, Equipment>), typeof(GroupedEquipmentsView), null);

    public IGrouping<EquipmentType, Equipment> GroupedEquipments
    {
        get => (IGrouping<EquipmentType, Equipment>)GetValue(GroupedEquipmentsProperty);
        set => SetValue(GroupedEquipmentsProperty, value);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(GroupedEquipments))
        {
            BindableLayout.SetItemsSource(EquipmentsView, GroupedEquipments);
        }
    }

    private View _header = null;
    public View Header => _header ??=
        new Grid
        {
            Style = Styles.SpellsHeaderView,
            Children =
            {
                new Label { /*WidthRequest = 300, */Style = Styles.SpellsHeaderLabel, Margin = 15 }
                .Bind(Label.TextProperty, source: this, path: nameof(GroupedEquipments), convert: (IGrouping<EquipmentType, Equipment> group) => Library.EquipmentTypes.ResourceManager.GetName(group?.Key.ToString()))
            }
        };

    private View _equimentsView = null;
    public View EquipmentsView => _equimentsView ??= new VerticalStackLayout { /*WidthRequest = 300, */BackgroundColor = Styles.TableTitleBackgroundColor, };

    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();
    public GroupedEquipmentsView()
    {
        Content = new Grid
        {
            WidthRequest = Settings.MainColumnWidth,
            RowDefinitions =
            {
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto),
            },
            Children =
            {
                Header,
                EquipmentsView.Row(1),
            },
        };
        BindableLayout.SetItemTemplateSelector(EquipmentsView, new GroupedEquipmentsDataTemplateSelector { EvenTemplate = GetItemTemplate(Styles.AlternateEven), UnevenTemplate = GetItemTemplate(Styles.AlternateUneven) });
    }

    DataTemplate GetItemTemplate(Style style) => new DataTemplate(
    () => new EquipmentView { Style = style }.Bind(EquipmentView.EquipmentProperty)
    /*new Grid
    {
        Style = style,
        ColumnDefinitions = new ColumnDefinitionCollection
        {
            new ColumnDefinition(GridLength.Auto),
            new ColumnDefinition(GridLength.Star),
        },
        Children = 
        {
            new CheckBox { WidthRequest = 40, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center }
                .Column(0)
                //.Bind(CheckBox.IsVisibleProperty, path: $"{nameof(Equipment.IsEquippable)}")
                //.Bind(CheckBox.IsCheckedProperty, path: nameof(Equipment.IsEquipped), mode: BindingMode.TwoWay),
                .Bind(CheckBox.IsVisibleProperty, path: $"{nameof(Equipment.IsEquippable)}")
                .Bind(CheckBox.IsCheckedProperty, path: nameof(Equipment.IsEquipped), mode: BindingMode.TwoWay),
            new Label { Style = Styles.DefaultListBasicLabel, Margin = 15, }
                .Column(1)
                .Bind(Label.TextProperty, convert: (Equipment equipment) => equipment?.Name )
        }
    }*/);
}

public class EquipmentView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty EquipmentProperty =
        BindableProperty.Create(nameof(Equipment), typeof(Equipment), typeof(EquipmentView), null);

    public Equipment Equipment
    {
        get => (Equipment)GetValue(EquipmentProperty);
        set => SetValue(EquipmentProperty, value);
    }

    public EquipmentView()
    {
        Content = new Grid
        {
            //Style = style,
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition(GridLength.Auto),
                new ColumnDefinition(GridLength.Star),
            },
            Children =
            {
                new CheckBox { WidthRequest = 40, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center }
                    .Column(0)
                    //.Bind(CheckBox.IsVisibleProperty, path: $"{nameof(Equipment.IsEquippable)}")
                    //.Bind(CheckBox.IsCheckedProperty, path: nameof(Equipment.IsEquipped), mode: BindingMode.TwoWay),
                    .Bind(CheckBox.IsVisibleProperty, path: NameOf(() => Equipment.IsEquippable))
                    .Bind(CheckBox.IsCheckedProperty, path: NameOf(() => Equipment.IsEquipped), mode: BindingMode.TwoWay),
                new Label { Style = Styles.DefaultListBasicLabel, Margin = 15, }
                    .Column(1)
                    .Bind(Label.TextProperty, convert: (Equipment equipment) => equipment?.Name )
            }
        };
    }
}