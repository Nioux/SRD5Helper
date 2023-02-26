//using Xamarin.CommunityToolkit.UI.Views;

using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.ViewModels;
using System.Runtime.CompilerServices;
//using Xamarin.CommunityToolkit.UI.Views;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class HealthView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty PlayerCharacterProperty =
    BindableProperty.Create(nameof(PlayerCharacter), typeof(PlayerCharacter), typeof(HealthView), null);

    public PlayerCharacter PlayerCharacter
    {
        get => (PlayerCharacter)GetValue(PlayerCharacterProperty);
        set => SetValue(PlayerCharacterProperty, value);
    }

    //public static readonly BindableProperty ConditionsProperty =
    //    BindableProperty.Create(nameof(Conditions), typeof(Conditions), typeof(HealthView), null);

    //public Conditions Conditions
    //{
    //    get => (Conditions)GetValue(ConditionsProperty);
    //    set => SetValue(ConditionsProperty, value);
    //}

    public HealthView()
	{
		Content = new Grid
		{
			ColumnDefinitions = new()
			{
				new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Star),
            },
			RowDefinitions = new()
			{
				new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto),
            },
			Children =
			{
				new Button { Text = "Repos court" }.Column(0).Row(0),
				new Button { Text = "Repos long" }.Column(1).Row(0),
				new ConditionsView().ColumnSpan(2).Row(1)
                .Bind(ConditionsView.ConditionsProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Conditions)),
			}
		};
    }
    /*
	private View _conditionsView = null;

    //public View ConditionsView => _conditionsView ??= new CollectionView
    //{
    //    ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical),
    //    SelectionMode = SelectionMode.None,
    //    //ItemTemplate = new AlternateColorDataTemplateSelector { EvenTemplate = GetDataTemplate(Styles.AlternateEven), UnevenTemplate = GetDataTemplate(Styles.AlternateUneven) }
    //    ItemTemplate = GetConditionDataTemplate(Styles.AlternateEven)
    //}
    //.Bind(CollectionView.ItemsSourceProperty, source: this, path: nameof(Conditions));

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(Conditions))
        {
            BindableLayout.SetItemsSource(ConditionsView, Conditions);
        }
    }

    public View ConditionsView
    {
        get
        {
            if (_conditionsView != null) return _conditionsView;
            _conditionsView ??= new FlexLayout
            {
                JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
                AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
                AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start,
                Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
                Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
            };
            BindableLayout.SetItemTemplate(_conditionsView,
                new DataTemplate(() => new ConditionView()
                .Bind(ConditionView.ConditionProperty)));
            //new DataTemplate(() => GetConditionDataTemplate(Styles.AlternateEven)));
            //new GroupedSpellsView { }
            //.Bind(GroupedSpellsView.GroupedSpellsProperty, convert: (IGrouping<int, Spell> group) => group)));
            return _conditionsView;
        }
    }
    private DataTemplate GetConditionDataTemplate(Style style)
	{
        return new DataTemplate(() =>
            new ConditionView()
            //.Bind(ConditionView.ConditionProperty)
            /*new Grid
			{
				//Padding = new Thickness(50, 0, 0, 50),
				RowDefinitions = new RowDefinitionCollection
				{
					new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                    new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                },
				ColumnDefinitions = new ColumnDefinitionCollection
				{
                    new ColumnDefinition(new GridLength(5)),
                    new ColumnDefinition(new GridLength(20)),
					new ColumnDefinition(new GridLength(1, GridUnitType.Star)),
					new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
                    new ColumnDefinition(new GridLength(5)),
                },
				ColumnSpacing = 5,
				RowSpacing = 10,
				Children =
				{
					new Switch { BackgroundColor = Colors.Black, VerticalOptions = LayoutOptions.CenterAndExpand, WidthRequest = 40 }.Column(1)
					.Bind(Switch.IsToggledProperty, path: nameof(Condition.IsEnabled), mode: BindingMode.TwoWay),
                    //new CheckBox { VerticalOptions = LayoutOptions.CenterAndExpand, WidthRequest = 40 }.Column(1)
                    //.Bind(CheckBox.IsCheckedProperty, path: nameof(Condition.IsEnabled), mode: BindingMode.TwoWay),
					//new Label { Padding = new Thickness(20,0,0,0), Text = "À terre" }.Column(0),
					new Label { FontSize = 16, TextColor = Colors.Black,VerticalOptions = LayoutOptions.CenterAndExpand,}.Column(2)
					.Bind(Label.TextProperty, path: nameof(Condition.Datum) + "." + nameof(Condition.Datum.Name)),
					new ImageButton { WidthRequest = 16, HeightRequest = 16,VerticalOptions = LayoutOptions.CenterAndExpand, Source = ImageSource.FromFile("question_solid.png") }.Column(3),
                    new Label { FontSize = 16, TextColor = Colors.Black, VerticalOptions = LayoutOptions.CenterAndExpand,}.Row(1).Column(1).ColumnSpan(3)
                    .Bind(Label.TextProperty, path: nameof(Condition.Datum) + "." + nameof(Condition.Datum.Description)),
                }
            }*/
            //)/;
	//}
}

