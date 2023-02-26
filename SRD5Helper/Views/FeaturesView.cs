using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.Resources.Library;
using SRD5Helper.ViewModels;
using System.Collections;
using System.Runtime.CompilerServices;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class FeaturesView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty PlayerCharacterProperty =
        BindableProperty.Create(nameof(PlayerCharacter), typeof(PlayerCharacter), typeof(FeaturesView), null);

    public PlayerCharacter PlayerCharacter
    {
        get => (PlayerCharacter)GetValue(PlayerCharacterProperty);
        set => SetValue(PlayerCharacterProperty, value);
    }
 
    public static readonly BindableProperty FeaturesByLevelProperty =
        BindableProperty.Create(nameof(FeaturesByLevel), typeof(IEnumerable), typeof(FeaturesView), null);

    public IEnumerable<IGrouping<int, Feature>> FeaturesByLevel
    {
        get => (IEnumerable<IGrouping<int, Feature>>)GetValue(FeaturesByLevelProperty);
        set { SetValue(FeaturesByLevelProperty, value); }
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        //if (propertyName == nameof(PlayerCharacter))
        //{
        //    FeaturesByLevel = PlayerCharacter.Features.GroupBy(feature => feature.MinimumLevel ?? 0);
        //}
        if (propertyName == nameof(FeaturesByLevel))
        {
            BindableLayout.SetItemsSource(Content, FeaturesByLevel);
        }
    }

    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();

    public FeaturesView()
    {
        BackgroundColor = Styles.PageBackgroundColor;

        //this.Bind(FeaturesByLevelProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Features), convert: (IReadOnlyList<Feature> features) => features.GroupBy(feature => 0));
        this.Bind(FeaturesByLevelProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Features), convert: (IReadOnlyList<Feature> features) => features.GroupBy(feature => feature.Level ?? 0));

        //var groupFeatures = PlayerCharacter.Features.GroupBy(feature => feature.MinimumLevel);

        //Content = GetFeaturesView()
        //    .Bind(CollectionView.ItemsSourceProperty, source: this, path: nameof(PlayerCharacter) + "." + nameof(PlayerCharacter.Features));
        Content = new FlexLayout
        {
            JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
            AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
            AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start,
            Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
            Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
        };
        BindableLayout.SetItemTemplate(Content,
            new DataTemplate(() =>
            new GroupedFeaturesView { }
            .Bind(GroupedFeaturesView.GroupedFeaturesProperty, convert: (IGrouping<int, Feature> group) => group)));
    }
    /*
    DataTemplate GetFeatureTemplate()
    {
        return new DataTemplate(
            () =>
            new Grid
            {
                Margin = new Thickness(10, 0, 0, 0),
                RowDefinitions =
                {
                    new RowDefinition(GridLength.Auto),
                    new RowDefinition(GridLength.Auto),
                },
                Children = {
                    new Label { Style = Styles.FeatureName, Margin = 5 }
                    .Row(0)
                    .Bind(Label.TextProperty, convert: (Feature feature) => feature?.Datum.Name),
                    
                    GetFeaturesView()
                    .Row(1)
                    .Bind(CollectionView.ItemsSourceProperty, path: nameof(Feature.SelectedFeatures)),
                }
            }.BindTapGesture(
                commandPath: $"{nameof(PlayerCharacterCommands)}.{nameof(PlayerCharacterCommands.ChooseFeatureCommand)}",
                commandSource: this,
                parameterPath: ".")
            );
    }

    View GetFeaturesView()
    {
        return new CollectionView {
            SelectionMode = SelectionMode.None,
            ItemSizingStrategy = ItemSizingStrategy.MeasureAllItems,
            ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical),
            ItemTemplate = GetFeatureTemplate()
        };
    }*/
}

public class GroupedFeaturesDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate EvenTemplate { get; set; }
    public DataTemplate UnevenTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var features = (BindableLayout.GetItemsSource(container) as IGrouping<int, Feature>).ToList();
        return features.IndexOf(item as Feature) % 2 == 0 ? EvenTemplate : UnevenTemplate;
    }
}

public class GroupedFeaturesView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty GroupedFeaturesProperty =
        BindableProperty.Create(nameof(GroupedFeatures), typeof(IGrouping<int, Feature>), typeof(GroupedFeaturesView), null);

    public IGrouping<int, Feature> GroupedFeatures
    {
        get => (IGrouping<int, Feature>)GetValue(GroupedFeaturesProperty);
        set => SetValue(GroupedFeaturesProperty, value);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(GroupedFeatures))
        {
            BindableLayout.SetItemsSource(FeaturesView, GroupedFeatures);
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
                .Bind(Label.TextProperty, source: this, path: nameof(GroupedFeatures), convert: (IGrouping<int, Feature> group) => group?.Key == 0 ? "ORIGINE" : $"NIVEAU {group?.Key}")
            }
        };

    private View _featuresView = null;
    public View FeaturesView => _featuresView ??= new VerticalStackLayout { /*WidthRequest = 300, */BackgroundColor = Styles.TableTitleBackgroundColor, };

    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();
    public GroupedFeaturesView()
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
                FeaturesView.Row(1),
            },
        };
        BindableLayout.SetItemTemplateSelector(FeaturesView, new GroupedFeaturesDataTemplateSelector { EvenTemplate = GetItemTemplate(Styles.AlternateEven), UnevenTemplate = GetItemTemplate(Styles.AlternateUneven) });
    }

    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();

    DataTemplate GetItemTemplate(Style style) => new DataTemplate(
    () =>
    new Grid
    {
        Style = style,
        Children = {
            new Label { Style = Styles.DefaultListBasicLabel, Margin = 15, }
                .BindTapGesture(commandPath: $"{nameof(PlayerCharacterCommands)}.{nameof(PlayerCharacterCommands.ChooseFeatureCommand)}", commandSource: this, parameterPath: ".")
                .Bind(Label.TextProperty, convert: (Feature feature) => feature?.Name )
        }
    });
}
