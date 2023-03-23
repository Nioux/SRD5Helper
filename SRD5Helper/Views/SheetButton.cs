using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using SRD5Helper.DataModels;
using System.Diagnostics;
using System.Windows.Input;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class TestButton : CheckBox
{
    public TestButton()
    {
        
    }
}
public class SheetButton : Border
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SheetButton), null);
    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(SheetButton), null);

    public ICommand Command { get => (ICommand)GetValue(CommandProperty); set => SetValue(CommandProperty, value); }
    public object CommandParameter { get => GetValue(CommandParameterProperty); set => SetValue(CommandParameterProperty, value); }

    public SheetButton()
    {
        Stroke = Color.FromArgb("#000000");
        Background = Color.FromArgb("#ffffff");
        StrokeThickness = 1;
        Shadow = new Shadow { Brush = Brush.DarkBlue, Opacity = 0.5f, Offset = new Point(10, 10), };
        Margin = new Thickness(0);
        Padding = new Thickness(0);
        VerticalOptions = LayoutOptions.Center;
        HorizontalOptions = LayoutOptions.Center;

        //.ShadowClickEffect();
        var gesture = new TapGestureRecognizer() { }
            .BindCommand(source: this, path: nameof(Command), parameterSource: this, parameterPath: nameof(CommandParameter));
        gesture.Tapped += async(truc, bidule) => {
            //Background = Color.FromArgb("#ff0000");
            //this.Opacity = 0.5;
            //this.FadeTo(1.0);
            await this.TranslateTo(10, 10, 10);
            this.Shadow.Offset = new Point(10, 10);
            this.TranslateTo(0, 0, 100);
            this.Animate("In", new Animation((d) => this.Shadow.Offset = new Point(10 - d, 10 - d)), 1, 10);
        };
        this.GestureRecognizers.Add(gesture);
    }
}

public class SheetCheckbox : SheetButton
{
    public static readonly BindableProperty IsCheckedProperty =
        BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(SheetCheckbox), null);
    public bool IsChecked { get => (bool)GetValue(IsCheckedProperty); set => SetValue(IsCheckedProperty, value); }

    public SheetCheckbox()
    {
        //Command = new RelayCommand(() => IsChecked = !IsChecked );
        Content = new BoxView /*Grid*/ { }.Bind(BoxView.ColorProperty, source: this, path: nameof(IsChecked), convert: (bool check) => check ? Colors.Red : Colors.Green);
    }
}

public class TextSheetButton : SheetButton
{
    public static readonly BindableProperty ValueProperty =
    BindableProperty.Create(nameof(Value), typeof(string), typeof(BoardAttributeButton), null);

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly BindableProperty ValueFontSizeProperty =
    BindableProperty.Create(nameof(ValueFontSize), typeof(double), typeof(BoardAttributeButton), (double)0);

    public double ValueFontSize
    {
        get => (double)GetValue(ValueFontSizeProperty);
        set => SetValue(ValueFontSizeProperty, value);
    }

    public TextSheetButton()
    {
        Content = new Grid
        {
            //BackgroundColor = Colors.Red,
            Children = { new Label
        {
            //BackgroundColor = Colors.Red,
            //BackgroundColor = Colors.White,
            FontFamily = Styles.ButtonFontFamily,
            //FontSize = Styles.MicroLabelFontSize,
            TextColor = Colors.Black,
            Padding = new Thickness(0),
            Margin = new Thickness(0),
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalTextAlignment = TextAlignment.Center,
            FormattedText = new FormattedString
            {
                Spans =
                {
                    //new Span { FontFamily = Styles.BasicFontFamily }
                    //.Bind(Span.TextProperty, source: this, path: nameof(Name)),
                    //new Span { Text = "\n", FontFamily = Styles.BasicFontFamily, },
                    new Span { /*FontSize = Styles.TitleLabelFontSize,*/ FontFamily = Styles.ButtonFontFamily, }
                    .Bind(Span.TextProperty, source: this, path: nameof(Value))
                    .Bind(Span.FontSizeProperty, source: this, path: nameof(ValueFontSize))
                    //,
                    //new Span { Text = "\n", FontFamily = Styles.BasicFontFamily, },
                    //new Span { Text = " ", FontFamily = Styles.BasicFontFamily },
                },
            },
        }
        .Bind(Label.FontSizeProperty, source: this, path: nameof(ValueFontSize)) }
        };
        //HeightRequest = Styles.TitleLabelFontSize * 3;
        //WidthRequest = Styles.TitleLabelFontSize * 3;
        //this.Bind(HeightRequestProperty, source: this, path: nameof(ValueFontSize), convert: (double size) => size * 3);
        ////this.Bind(WidthRequestProperty, source: this, path: nameof(ValueFontSize), convert: (double size) => size * 3 / SizeRatio);
        //this.SetBinding(WidthRequestProperty, new MultiBinding
        //{
        //    Bindings =
        //    {
        //        new Binding(source: this, path: nameof(ValueFontSize)),
        //        new Binding(source: this, path: nameof(SizeRatio)),
        //    },
        //    Converter = new FuncMultiConverter<double, double, double>(convert: ((double fontSize, double ratio) values) => values.fontSize * 3 * values.ratio),
        //});
    }

}
public class BoardAttributeButton : TextSheetButton
{
    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(BoardAttributeButton), null);

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public static readonly BindableProperty NameFontSizeProperty =
    BindableProperty.Create(nameof(NameFontSize), typeof(double), typeof(BoardAttributeButton), (double)0);

    public double NameFontSize
    {
        get => (double)GetValue(NameFontSizeProperty);
        set => SetValue(NameFontSizeProperty, value);
    }
    /*
    public static readonly BindableProperty ValueProperty =
    BindableProperty.Create(nameof(Value), typeof(string), typeof(BoardAttributeButton), null);

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly BindableProperty ValueFontSizeProperty =
    BindableProperty.Create(nameof(ValueFontSize), typeof(double), typeof(BoardAttributeButton), (double)0);

    public double ValueFontSize
    {
        get => (double)GetValue(ValueFontSizeProperty);
        set => SetValue(ValueFontSizeProperty, value);
    }
    */
    public static readonly BindableProperty SizeRatioProperty =
    BindableProperty.Create(nameof(SizeRatio), typeof(double), typeof(BoardAttributeButton), (double)1.0);

    public double SizeRatio
    {
        get => (double)GetValue(SizeRatioProperty);
        set => SetValue(SizeRatioProperty, value);
    }
    public BoardAttributeButton()
    {
        StrokeThickness = 1.0;
        /*Stroke = new LinearGradientBrush
        {
            EndPoint = new Point(0, 3),
            GradientStops = new GradientStopCollection
            {
                new GradientStop { Color = Colors.Red, Offset = 1.0f },
                new GradientStop { Color = Colors.Blue, Offset = 1.0f }
            },
        };*/
        Content = new Grid
        {
            //BackgroundColor = Colors.Red,
            Children = { new Label
            {
                //BackgroundColor = Colors.Red,
                //BackgroundColor = Colors.White,
                FontFamily = Styles.ButtonFontFamily,
                //FontSize = Styles.MicroLabelFontSize,
                TextColor = Colors.Black,
                Padding = new Thickness(0),
                Margin = new Thickness(0),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FormattedText = new FormattedString
                {
                    Spans =
                    {
                        new Span { FontFamily = Styles.BasicFontFamily }
                        .Bind(Span.TextProperty, source: this, path: nameof(Name)),
                        new Span { Text = "\n", FontFamily = Styles.BasicFontFamily, },
                        new Span { /*FontSize = Styles.TitleLabelFontSize,*/ FontFamily = Styles.ButtonFontFamily, }
                        .Bind(Span.TextProperty, source: this, path: nameof(Value))
                        .Bind(Span.FontSizeProperty, source: this, path: nameof(ValueFontSize))
                        ,
                        new Span { Text = "\n", FontFamily = Styles.BasicFontFamily, },
                        new Span { Text = " ", FontFamily = Styles.BasicFontFamily },
                    },
                },
            }
            .Bind(Label.FontSizeProperty, source: this, path: nameof(NameFontSize)) }
        };
        //}.Bind<Border, IShape, IShape>(Border.StrokeShapeProperty, source: this, path: nameof(StrokeShape), convert:
        //(IShape ishape) =>
        //{
        //    if(ishape is Microsoft.Maui.Controls.Shapes.Rectangle)
        //    {
               
        //        var shape = ishape as Microsoft.Maui.Controls.Shapes.Rectangle;
        //        return new Microsoft.Maui.Controls.Shapes.Rectangle() { Stroke = Colors.Red, Background = Colors.Green, Aspect = shape.Aspect, };
        //    }
        //    else if (ishape is Microsoft.Maui.Controls.Shapes.RoundRectangle)
        //    {

        //        var shape = ishape as Microsoft.Maui.Controls.Shapes.RoundRectangle;
        //        return new Microsoft.Maui.Controls.Shapes.RoundRectangle() { Stroke = Colors.Red, Background = Colors.Green, Aspect = shape.Aspect, CornerRadius = shape.CornerRadius };
        //    }
        //    else
        //    {
        //        var shape = ishape as Microsoft.Maui.Controls.Shapes.Path;
        //        return new Microsoft.Maui.Controls.Shapes.Path() { Stroke = Colors.Red, Background = Colors.Green, Aspect = shape.Aspect, Data = shape.Data, };
        //    }
        //}

        //HeightRequest = Styles.TitleLabelFontSize * 3;
        //WidthRequest = Styles.TitleLabelFontSize * 3;
        this.Bind(HeightRequestProperty, source: this, path: nameof(ValueFontSize), convert: (double size) => size * 3);
        //this.Bind(WidthRequestProperty, source: this, path: nameof(ValueFontSize), convert: (double size) => size * 3 / SizeRatio);
        this.SetBinding(WidthRequestProperty, new MultiBinding
        {
            Bindings =
            {
                new Binding(source: this, path: nameof(ValueFontSize)),
                new Binding(source: this, path: nameof(SizeRatio)),
            },
            Converter = new FuncMultiConverter<double, double, double>(convert: ((double fontSize, double ratio) values) => values.fontSize * 3 * values.ratio ),
        });
    }
}

public class DamageButton : SheetButton
{
    public static readonly BindableProperty DiceCountProperty =
        BindableProperty.Create(nameof(DiceCount), typeof(int), typeof(DamageButton), 1);

    public int DiceCount
    {
        get => (int)GetValue(DiceCountProperty);
        set => SetValue(DiceCountProperty, value);
    }

    public static readonly BindableProperty DieTypeProperty =
        BindableProperty.Create(nameof(DieType), typeof(int), typeof(DamageButton), 0);

    public int DieType
    {
        get => (int)GetValue(DieTypeProperty);
        set => SetValue(DieTypeProperty, value);
    }

    public static readonly BindableProperty ModifierProperty =
        BindableProperty.Create(nameof(Modifier), typeof(int), typeof(DamageButton), 0);

    public int Modifier
    {
        get => (int)GetValue(ModifierProperty);
        set => SetValue(ModifierProperty, value);
    }

    public static readonly BindableProperty DamageTypeProperty =
        BindableProperty.Create(nameof(DamageType), typeof(DamageType), typeof(DamageButton), null);

    public DamageType DamageType
    {
        get => (DamageType)GetValue(DamageTypeProperty);
        set => SetValue(DamageTypeProperty, value);
    }

    public static readonly BindableProperty TwoHandledProperty =
        BindableProperty.Create(nameof(TwoHandled), typeof(bool), typeof(DamageButton), false);

    public bool TwoHandled
    {
        get => (bool)GetValue(TwoHandledProperty);
        set => SetValue(TwoHandledProperty, value);
    }

    public DamageButton()
    {
        Padding = new Thickness(10);
        StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(10, 10, 10, 10)
        };
        Content = new HorizontalStackLayout
        {
            //new Image { Margin = new Thickness(0, 0, 0, 0), WidthRequest = 30, HeightRequest = 30, Source = "two_hands.png", }.Bind(Image.IsVisibleProperty, source: this, path: nameof(TwoHandled)),
            //new Image { Margin = new Thickness(0, 0, 10, 0), WidthRequest = 30, HeightRequest = 30 }.Bind(Image.SourceProperty, source: this, path: nameof(DamageType), convert: (DamageType type) => $"{type.ToString().ToLower()}.png"),
            new Label { TextColor = Colors.Black, FontSize = Styles.TitleLabelFontSize, FontFamily = Styles.ButtonFontFamily/* Styles.BasicFontFamily*/, VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center,}.Bind(Label.TextProperty, source: this, path: nameof(DiceCount), convert: (int count) => (count > 1) ? count.ToString() : ""),
            new Image { WidthRequest = Styles.TitleLabelFontSize, HeightRequest = Styles.TitleLabelFontSize }.Bind(Image.SourceProperty, source: this, path: nameof(DieType), convert: (int die) => $"d{die}.png"),
            new Label { TextColor = Colors.Black, FontSize = Styles.TitleLabelFontSize, FontFamily = Styles.ButtonFontFamily /*Styles.BasicFontFamily*/, VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center,}.Bind(Label.TextProperty, source: this, path: nameof(Modifier), convert: (int mod) => mod.ToString("+0;-#")),
            new Image { Margin = new Thickness(10, 0, 0, 0), WidthRequest = Styles.TitleLabelFontSize, HeightRequest = Styles.TitleLabelFontSize, Source = "broken_heart.png" },
        };
    }

}

public class Roll20Button : SheetButton
{
    public static readonly BindableProperty ModifierProperty =
        BindableProperty.Create(nameof(Modifier), typeof(int), typeof(AttackRollButton), 0);

    public int Modifier
    {
        get => (int)GetValue(ModifierProperty);
        set => SetValue(ModifierProperty, value);
    }

    public Roll20Button()
    {
        Padding = new Thickness(10);
        StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(10, 10, 10, 10)
        };
        Content = new HorizontalStackLayout
        {
            //new Image { Margin = new Thickness(0, 0, 10, 0), WidthRequest = 30, HeightRequest = 30, }.Bind(Image.SourceProperty, source: this, path: nameof(MeleeRange), convert: (MeleeRangeEnum mr) => $"{mr.ToString().ToLower()}.png"),

            DiceImage,
            ModifierView,
            VSView,
            TargetImage,
            //new Image { Margin = new Thickness(0, 0, 0, 0), WidthRequest = Styles.TitleLabelFontSize, HeightRequest = Styles.TitleLabelFontSize, Source = "d20.png", },
            //new Label { TextColor = Colors.Black, FontSize = Styles.TitleLabelFontSize, FontFamily = "Florencesans" /*Styles.BasicFontFamily*/, VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center, }.Bind(Label.TextProperty, source: this, path: nameof(Modifier), convert: (int mod) => mod.ToString("+0;-#")),
            //new Label { Margin = new Thickness(10, 0, 0, 0), TextColor = Colors.Black, FontSize = Styles.SubtitleLabelFontSize, FontFamily = "Florencesans" /*Styles.BasicFontFamily*/, Text = "VS", VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center,},
            //new Image { Margin = new Thickness(10, 0, 0, 0), WidthRequest = Styles.TitleLabelFontSize, HeightRequest = Styles.TitleLabelFontSize, Source = "shield.png" },
        };
    }

    public View DiceImage => new Image { Margin = new Thickness(0, 0, 0, 0), WidthRequest = Styles.TitleLabelFontSize, HeightRequest = Styles.TitleLabelFontSize, Source = "d20.png", };

    public View ModifierView => new Label { TextColor = Colors.Black, FontSize = Styles.TitleLabelFontSize, FontFamily = "Florencesans" /*Styles.BasicFontFamily*/, VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center, }.Bind(Label.TextProperty, source: this, path: nameof(Modifier), convert: (int mod) => mod.ToString("+0;-#"));

    public View VSView => new Label { Margin = new Thickness(10, 0, 0, 0), TextColor = Colors.Black, FontSize = Styles.SubtitleLabelFontSize, FontFamily = "Florencesans" /*Styles.BasicFontFamily*/, Text = "VS", VerticalOptions = LayoutOptions.Center, VerticalTextAlignment = TextAlignment.Center, };

    public virtual View TargetImage => new Image { Margin = new Thickness(10, 0, 0, 0), WidthRequest = Styles.TitleLabelFontSize, HeightRequest = Styles.TitleLabelFontSize, Source = "shield.png" };

}
public class AbilityCheckButton : Roll20Button
{
    public override View TargetImage => new Image { Margin = new Thickness(10, 0, 0, 0), WidthRequest = Styles.TitleLabelFontSize, HeightRequest = Styles.TitleLabelFontSize, Source = "target.png" };
}

public enum MeleeRangeEnum
{
    Melee,
    Range,
}
public class AttackRollButton : Roll20Button
{
    public static readonly BindableProperty MeleeRangeProperty =
    BindableProperty.Create(nameof(MeleeRange), typeof(MeleeRangeEnum), typeof(AttackRollButton), MeleeRangeEnum.Melee);

    public MeleeRangeEnum MeleeRange
    {
        get => (MeleeRangeEnum)GetValue(MeleeRangeProperty);
        set => SetValue(MeleeRangeProperty, value);
    }

    public override View TargetImage => new Image { Margin = new Thickness(10, 0, 0, 0), WidthRequest = Styles.TitleLabelFontSize, HeightRequest = Styles.TitleLabelFontSize, Source = "shield.png" };
}