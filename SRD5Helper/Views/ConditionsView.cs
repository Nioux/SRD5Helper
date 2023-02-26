using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;



public class ConditionsView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty ConditionsProperty =
        BindableProperty.Create(nameof(Conditions), typeof(Conditions), typeof(ConditionsView), null);

    public Conditions Conditions
    {
        get => (Conditions)GetValue(ConditionsProperty);
        set => SetValue(ConditionsProperty, value);
    }

    public ConditionsView()
    {
        Content = ContentView;
    }

    private View _contentView = null;

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(Conditions))
        {
            BindableLayout.SetItemsSource(ContentView, Conditions.ToList());
        }
    }

    public View ContentView
    {
        get
        {
            if (_contentView != null) return _contentView;
            _contentView ??= new FlexLayout
            {
                JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
                AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
                AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start,
                Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
                Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
            };
            BindableLayout.SetItemTemplate(_contentView,
                new DataTemplate(() => new ConditionView()
                .Bind(ConditionView.ConditionProperty)));
            return _contentView;
        }
    }
}


public class ConditionView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();

    public static readonly BindableProperty ConditionProperty =
        BindableProperty.Create(nameof(Condition), typeof(ViewModels.Condition), typeof(ConditionView), null);

    public ViewModels.Condition Condition
    {
        get => (ViewModels.Condition)GetValue(ConditionProperty);
        set => SetValue(ConditionProperty, value);
    }

    public ConditionView()
    {
        Content = new VerticalStackLayout
        {
            WidthRequest = Settings.MainColumnWidth,
            HorizontalOptions = LayoutOptions.Start,
            Children =
            {
                new HorizontalStackLayout
                {
                    HorizontalOptions = LayoutOptions.Start,
                    Children =
                    {
                        EnabledView,
                        NameView,
                    },
                },
                DescriptionView,
            },
        };
        /*Content = new Grid
        {
            WidthRequest = Settings.MainColumnWidth,
            //Padding = new Thickness(50, 0, 0, 50),
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
                new RowDefinition(new GridLength(1, GridUnitType.Auto)),
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition(new GridLength(5)),
                new ColumnDefinition(new GridLength(40)),
                new ColumnDefinition(new GridLength(1, GridUnitType.Star)),
                //new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
                new ColumnDefinition(new GridLength(5)),
            },
            ColumnSpacing = 5,
            RowSpacing = 10,
            Children =
            {
                //new CheckBox { VerticalOptions = LayoutOptions.CenterAndExpand, WidthRequest = 40 }.Column(1)
                //.Bind(CheckBox.IsCheckedProperty, path: nameof(Condition.IsEnabled), mode: BindingMode.TwoWay),
				//new Label { Padding = new Thickness(20,0,0,0), Text = "À terre" }.Column(0),
                //new ImageButton { WidthRequest = 16, HeightRequest = 16,VerticalOptions = LayoutOptions.CenterAndExpand, Source = ImageSource.FromFile("question_solid.png") }.Column(3),

                EnabledView.Column(1),
                NameView.Column(2),
                DescriptionView.Row(1).Column(1).ColumnSpan(3),
            }

        };*/
        //DescriptionView.PropertyChanged += DescriptionView_PropertyChanged;
    }
    /*
    private void DescriptionView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.PropertyName) || e.PropertyName == nameof(View.IsVisible))
        {
            (Parent as IView).InvalidateMeasure();
        }
    }*/

    private View _enabledView = null;
    public View EnabledView =>
                _enabledView ??= new Switch { OnColor = Colors.Black, ThumbColor = Colors.DarkBlue, WidthRequest = 40 }
                .Bind(Switch.IsToggledProperty, source: this, path: NameOf(() => Condition.IsEnabled), mode: BindingMode.TwoWay);

    private View _nameView = null;
    public View NameView =>
                _nameView ??= new Label { FontSize = 16, TextColor = Colors.Black, VerticalOptions = LayoutOptions.Start, }
                .Bind(Label.TextProperty, source: this, path: NameOf(() => Condition.Name));

    private View _descriptionView = null;
    public View DescriptionView =>
                _descriptionView ??= 
        new Grid {
            //new Label { FontSize = 16, TextColor = Colors.Black, VerticalOptions = LayoutOptions.Start, }
            //    .Bind(Label.IsVisibleProperty, source: this, path: nameof(Condition) + "." + nameof(Condition.IsEnabled))
            //    .Bind(Label.TextProperty, source: this, path: nameof(Condition) + "." + nameof(Condition.Datum) + "." + nameof(Condition.Datum.Description))
            new Xam.Forms.Markdown.MarkdownView { BackgroundColor = Colors.Red, WidthRequest = Settings.MainColumnWidth, VerticalOptions = LayoutOptions.Start, }
                .Bind(View.IsVisibleProperty, source: this, path: NameOf(() => Condition.IsEnabled))
                .Bind(Xam.Forms.Markdown.MarkdownView.MarkdownProperty, source: this, path: NameOf(() => Condition.Description))
        };
}
