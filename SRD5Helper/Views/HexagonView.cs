using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Maui.Controls.Shapes;
using Path = Microsoft.Maui.Controls.Shapes.Path;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

//
// Summary:
//     Grid Extensions
public static class ColumnRowGridExtensions
{
    public static TView ColumnRow<TView>(this TView view, int? column = null, int? row = null, int? columnSpan = null, int? rowSpan = null) where TView : View
    {
        if(column != null) view.SetValue(Grid.ColumnProperty, column);
        if(row != null) view.SetValue(Grid.ColumnSpanProperty, columnSpan);
        if(columnSpan != null) view.SetValue(Grid.RowProperty, row);
        if(rowSpan != null) view.SetValue(Grid.RowSpanProperty, rowSpan);
        return view;
    }
}
public class HexagonNameValueView : HexagonView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(HexagonNameValueView), string.Empty);
    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(string), typeof(HexagonNameValueView), string.Empty);
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public HexagonNameValueView()
    {
        //HexagonStroke = Color.FromArgb("849098");
        //HexagonStrokeThickness = 4;
        //Background = Color.FromArgb("E8E4E0");
        //BackgroundColor = Colors.Red;
        
        var grid = new Grid()
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
            }
        };

        grid.Children.Add(
            new Label
            {
                ZIndex = 3,
                TextColor = Colors.Black,
                FontFamily = Styles.BasicFontFamily, // "LiberationSansRegular",
                HorizontalTextAlignment = TextAlignment.Center,
            }//.Row(0)//.ColumnRow(0,0,1,1)
            .Bind(Label.WidthRequestProperty, source: this, path: nameof(WidthRequest))
            .Bind(Label.PaddingProperty, source: this, path: nameof(HeightRequest), convert: (double h) => new Thickness(0, h / 8, 0, 0))
            .Bind(Label.FontSizeProperty, source: this, path: nameof(HeightRequest), convert: (double h) => h / 8)
            .Bind(Label.TextProperty, source: this, path: nameof(Name))
        );
        grid.Children.Add(
            new Label
            {
                //BackgroundColor = Colors.Red,
                ZIndex = 2,
                TextColor = Colors.Black,
                FontFamily = Styles.ScriptFontFamily, // "WolgastTwoBold",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
            }//.Row(1).RowSpan(2)//.ColumnRow(0,0,1,1)
            .Bind(Label.PaddingProperty, source: this, path: nameof(HeightRequest), convert: (double h) => new Thickness(0, h / 4, 0, 0))
            .Bind(Label.FontSizeProperty, source: this, path: nameof(HeightRequest), convert: (double h) => h / 2)
            .Bind(Label.HeightRequestProperty, source: this, path: nameof(HeightRequest))
            .Bind(Label.WidthRequestProperty, source: this, path: nameof(WidthRequest))
            .Bind(Label.TextProperty, source: this, path: nameof(Value))
            );
        Children.Insert(0, grid);
    }
}

public class HexagonBullet : CheckBox
{
    public static readonly BindableProperty HexagonHeightProperty =
        BindableProperty.Create(nameof(HexagonHeight), typeof(double), typeof(HexagonView), (double)0);

    public static readonly BindableProperty HexagonStrokeProperty =
        BindableProperty.Create(nameof(HexagonStroke), typeof(Brush), typeof(HexagonView), null);

    public static readonly BindableProperty HexagonStrokeThicknessProperty =
        BindableProperty.Create(nameof(HexagonStrokeThickness), typeof(double), typeof(HexagonView), (double)0);
    public double HexagonHeight
    {
        get => (double)GetValue(HexagonHeightProperty);
        set => SetValue(HexagonHeightProperty, value);
    }

    public Brush HexagonStroke
    {
        get => (Brush)GetValue(HexagonStrokeProperty);
        set => SetValue(HexagonStrokeProperty, value);
    }
    public double HexagonStrokeThickness
    {
        get => (double)GetValue(HexagonStrokeThicknessProperty);
        set => SetValue(HexagonStrokeThicknessProperty, value);
    }
    public HexagonBullet()
    {
        /*
        <ImageButton Source="XamarinLogo.png"
         ...>
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup x:Name="CommonStates">
        <VisualState x:Name="Normal">
            <VisualState.Setters>
                <Setter Property="Scale"
                        Value="1" />
            </VisualState.Setters>
        </VisualState>

        <VisualState x:Name="Pressed">
            <VisualState.Setters>
                <Setter Property="Scale"
                        Value="0.8" />
            </VisualState.Setters>
        </VisualState>

    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>
</ImageButton> 
        */
        //this.XAML
        //SetValue(VisualElement.NameProperty, "HexagonButton");
        //HexagonHeight = 30;
        //HeightRequest = 100;
        //BackgroundColor = Colors.Red;
        //this.Color = Colors.Green;
        //this.TranslationY = -20;
        
#if WINDOWS
			double density = 1.0;
#else
        double density = DeviceDisplay.MainDisplayInfo.Density;
#endif
        this.Bind(Grid.HeightRequestProperty, source: this, path: nameof(HexagonHeight));
        this.Bind(Grid.WidthRequestProperty, source: this, path: nameof(HexagonHeight), convert: (double h) => HexagonGeometry.GetRegularHexagonWidth(h ));
        this.Bind(Grid.ClipProperty, source: this, path: nameof(HexagonHeight), convert: (double h) => HexagonGeometry.GetRegularHexagonPathGeometry(h ));
        //this.Bind(Grid.BackgroundColorProperty, source: this, path: nameof(Color));
        //Color = Colors.Red;
        //BackgroundColor = Colors.Red;

        /*var button = new CheckBox { };
        /*var vsgl = new VisualStateGroupList();
        var vsg = new VisualStateGroup();
        vsgl.Add(vsg);*/
        VisualStateManager.SetVisualStateGroups(this, new VisualStateGroupList
        {
            new VisualStateGroup
            {
                Name = "CommonStates",
                States = 
                {
                    new VisualState
                    {
                        Name = "Normal",
                        Setters =
                        {
                            new Setter { Property = CheckBox.ScaleProperty, Value = 1 },
                            //new Setter { Property = CheckBox.ColorProperty, Value = Colors.Red },
                            //new Setter { Property = CheckBox.BackgroundColorProperty, Value = Colors.Red },
                            //new Setter { Property = Button.BorderColorProperty, Value = Colors.ButtonText },
                            //new Setter { Property = Button.PaddingProperty, Value = new Thickness(5,0) },
                            //new Setter { Property = Button.MarginProperty, Value = new Thickness(0, 0) }
                        },
                    },
                    new VisualState
                    {
                        Name = "IsChecked",
                        Setters =
                        {
                            new Setter { Property = CheckBox.ScaleProperty, Value = 1 },
                            //new Setter { Property = CheckBox.ColorProperty, Value = Colors.Green },
                            //new Setter { Property = CheckBox.BackgroundColorProperty, Value = Colors.Green },
                            //new Setter { Property = Button.BorderColorProperty, Value = Colors.ButtonText },
                            //new Setter { Property = Button.PaddingProperty, Value = new Thickness(5,0) },
                            //new Setter { Property = Button.MarginProperty, Value = new Thickness(0, 0) }
                        },
                    },
                    new VisualState
                    {
                        Name = "Selected",
                        Setters =
                        {
                            new Setter { Property = CheckBox.ScaleProperty, Value = 0.8 },
                            //new Setter { Property = CheckBox.ColorProperty, Value = Colors.Yellow },
                            //new Setter { Property = Button.BorderColorProperty, Value = Colors.ButtonText },
                            //new Setter { Property = Button.PaddingProperty, Value = new Thickness(5,0) },
                            //new Setter { Property = Button.MarginProperty, Value = new Thickness(0, 0) }
                        },
                    },
                    new VisualState
                    {
                        Name = "Intermediate",
                        Setters =
                        {
                            new Setter { Property = CheckBox.ScaleProperty, Value = 0.8 },
                            //new Setter { Property = CheckBox.ColorProperty, Value = Colors.Blue },
                            //new Setter { Property = Button.BorderColorProperty, Value = Colors.ButtonText },
                            //new Setter { Property = Button.PaddingProperty, Value = new Thickness(5,0) },
                            //new Setter { Property = Button.MarginProperty, Value = new Thickness(0, 0) }
                        },
                    },
                }
            }
        });
        //Children.Insert(0, button);
    }
    
}

public class HexagonView : Grid
{
    public static readonly BindableProperty HexagonHeightProperty =
        BindableProperty.Create(nameof(HexagonHeight), typeof(double), typeof(HexagonView), (double)0);

    public static readonly BindableProperty HexagonStrokeProperty =
        BindableProperty.Create(nameof(HexagonStroke), typeof(Brush), typeof(HexagonView), null);

    public static readonly BindableProperty HexagonStrokeThicknessProperty =
        BindableProperty.Create(nameof(HexagonStrokeThickness), typeof(double), typeof(HexagonView), (double)0);

    public double HexagonHeight
    {
        get => (double)GetValue(HexagonHeightProperty);
        set => SetValue(HexagonHeightProperty, value);
    }

    public Brush HexagonStroke
    {
        get => (Brush)GetValue(HexagonStrokeProperty);
        set => SetValue(HexagonStrokeProperty, value);
    }
    public double HexagonStrokeThickness
    {
        get => (double)GetValue(HexagonStrokeThicknessProperty);
        set => SetValue(HexagonStrokeThicknessProperty, value);
    }

    double HexagonHeightForPathGeometry = 0;
    PathGeometry ClipPathGeometry = null;
    PathGeometry BorderPathGeometry = null;

//        double DeviceDisplayDensity
//        {
//            get
//            {
//#if WINDOWS
//			    return 1.0;
//#else
//                return 1; // return DeviceDisplay.MainDisplayInfo.Density;
//#endif
//            }
//        }

    public HexagonView()
    {
        BackgroundColor = Colors.Red;
        this.Bind(Grid.HeightRequestProperty, source: this, path: nameof(HexagonHeight));
        this.Bind(Grid.WidthRequestProperty, source: this, path: nameof(HexagonHeight), convert: (double h) => HexagonGeometry.GetRegularHexagonWidth(h));
        this.Bind(Grid.ClipProperty, source: this, path: nameof(HexagonHeight), convert:
            (double h) =>
            {
                return HexagonGeometry.GetRegularHexagonPathGeometry(h);
            }
            );
        Children.Add(
            new Path() { Fill = Brush.Transparent }
                .Bind(Path.HeightRequestProperty, source: this, path: nameof(HexagonHeight))
                .Bind(Path.WidthRequestProperty, source: this, path: nameof(HexagonHeight), convert: (double h) => HexagonGeometry.GetRegularHexagonWidth(h))
                .Bind(Path.StrokeProperty, source: this, path: nameof(HexagonStroke))
                .Bind(Path.StrokeThicknessProperty, source: this, path: nameof(HexagonStrokeThickness))
                .Bind(Path.DataProperty, source: this, path: nameof(HexagonHeight), convert:
                (double h) =>
                {
                    return HexagonGeometry.GetRegularHexagonPathGeometry(h);
                })
        );
    }
}

public class HexagonGeometry
{
    // https://www.redblobgames.com/grids/hexagons/
    public static double GetRegularHexagonWidth(double heigth)
    {
        return Math.Sqrt(3) * heigth / 2;
    }
    public static double GetRegularHexagonHeight(double width)
    {
        return width * 2 / Math.Sqrt(3);
    }
    public static PathGeometry GetRegularHexagonPathGeometry(double h, double x = 0, double y = 0)
    {
        return GetHexagonPathGeometry(GetRegularHexagonWidth(h), h, x, y);
    }

    public static PathGeometry GetHexagonPathGeometry(double w, double h, double x = 0, double y = 0)
    {
        return new PathGeometry
        {
            Figures = new PathFigureCollection {
                    new PathFigure() {
                        StartPoint = new Point(x + w/2, y),
                        IsFilled = true,
                        IsClosed = true,
                        Segments = new PathSegmentCollection {
                            new LineSegment() {
                                Point = new Point(x + w/2, y)
                            },
                            new LineSegment() {
                                Point = new Point(x + w, y + h/4)
                            },
                            new LineSegment() {
                                Point = new Point(x + w, y + 3*h/4)
                            },
                            new LineSegment() {
                                Point = new Point(x + w/2, y + h)
                            },
                            new LineSegment() {
                                Point = new Point(x, y + 3*h/4)
                            },
                            new LineSegment() {
                                Point = new Point(x, y + h/4)
                            },
                            /*new LineSegment() {
                                Point = new Point(x + w/2, y)
                            }*/
                        }
                    }
                },
        };
    }
    /*
		Tuple<Point, Size> GetPathGeometrySize(PathGeometry pg)
    {
			Point start = new Point();
			Size size = new Size();
			foreach(var figure in pg.Figures)
        {
				foreach(var segment in figure.Segments)
            {
					if(segment is LineSegment)
                {
						var point = (segment as LineSegment).Point;
						start.X = Math.Min(start.X, point.X);
						start.Y = Math.Min(start.Y, point.Y);
						size.Width = Math.Max(size.Width, point.X);
						size.Height = Math.Max(size.Height, point.Y);
					}
				}
        }
			return new Tuple<Point, Size>(start, size);
    }
		*/
}
