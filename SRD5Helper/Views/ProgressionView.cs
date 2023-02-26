using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.Data;
using SRD5Helper.DataModels;
using SRD5Helper.ViewModels;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views;

public class ProgressionView : ContentView
{
    public Settings Settings => Ioc.Default.GetRequiredService<Settings>();

    public static readonly BindableProperty PlayerCharacterProperty =
        BindableProperty.Create(nameof(PlayerCharacter), typeof(PlayerCharacter), typeof(BoardView), null);

    public PlayerCharacter PlayerCharacter
    {
        get => (PlayerCharacter)GetValue(PlayerCharacterProperty);
        set => SetValue(PlayerCharacterProperty, value);
    }
    public PlayerCharacter PC => PlayerCharacter;

    private DataService _storageService = null;
    private DataService StorageService => _storageService ??= Ioc.Default.GetRequiredService<DataService>();
    private PlayerCharacterEditorCommands Editor => Ioc.Default.GetRequiredService<PlayerCharacterEditorCommands>();

    protected IReadOnlyDictionary<string, OriginDatum> OriginsData => StorageService.OriginsData;
    protected IReadOnlyDictionary<string, BackgroundDatum> BackgroundsData => StorageService.BackgroundsData;
    protected IReadOnlyDictionary<string, ClassDatum> ClassesData => StorageService.ClassesData;



    private Picker _originPicker = null;

	public Picker OriginPicker => _originPicker ??= new Picker
	{
		Title = "Origine",
		TextColor = Colors.Black,
		TitleColor = Colors.Black,
		BackgroundColor = Colors.Red,
		ItemsSource = OriginsData.Values.ToArray(),
		ItemDisplayBinding = new Binding(nameof(OriginDatum.GenderedName)),		
	}.Invoke(picker => picker.SelectedIndexChanged += OriginView_SelectedIndexChanged);

    private VerticalStackLayout _originView = null;
    public VerticalStackLayout OriginView => _originView ??= new VerticalStackLayout
    {
        WidthRequest = Settings.MainColumnWidth,
        Children =
        {
            OriginPicker,
            new Label { TextColor = Colors.Green }
                //.Bind(Label.TextProperty, source: this, path: "PC.Origin", convert: (Origin origin) => origin.Datum.Description + "toto"),
                .Bind(Label.TextProperty, source: this, path: NameOf(() => PlayerCharacter.Origin), convert: (Origin origin) => origin?.Datum.Description + "toto"),
        },
    };

    private Picker _backgroundView = null;

    public Picker BackgroundView => _backgroundView ??= new Picker
    {
        Title = "Historique",
        TextColor = Colors.Black,
        TitleColor = Colors.Black,
        BackgroundColor = Colors.Red,
        ItemsSource = BackgroundsData.Values.ToArray(),
        ItemDisplayBinding = new Binding(nameof(BackgroundDatum.Name)),
    }.Invoke(picker => picker.SelectedIndexChanged += BackgroundView_SelectedIndexChanged);

    private Picker _classView = null;

    public Picker ClassView => _classView ??= new Picker
    {
        Title = "Classe",
        TextColor = Colors.Black,
        TitleColor = Colors.Black,
        BackgroundColor = Colors.Red,
        ItemsSource = ClassesData.Values.ToArray(),
        ItemDisplayBinding = new Binding(nameof(ClassDatum.GenderedName)),
    }.Invoke(picker => picker.SelectedIndexChanged += ClassView_SelectedIndexChanged);

    public View GetAbilityView(string title, string path)
    {
        return new Picker
        {
            Title = title,
            TextColor = Colors.Black,
            TitleColor = Colors.Black,
            BackgroundColor = Colors.Red,
            ItemsSource = new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 },
        }.Bind(Picker.SelectedIndexProperty, source: this, path: path,
            convert: (int score) => score - 3,
            convertBack: (int index) => index + 3);
    }
    private Grid _abilitiesView = null;
    public Grid AbilitiesView => _abilitiesView ??= new Grid
    {
        ColumnDefinitions = new()
        {
            new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
            new ColumnDefinition(new GridLength(1, GridUnitType.Auto)),
        },
        RowDefinitions = new()
        {
            new RowDefinition(new GridLength(0, GridUnitType.Auto)),
            new RowDefinition(new GridLength(0, GridUnitType.Auto)),
            new RowDefinition(new GridLength(0, GridUnitType.Auto)),
        },
        Children =
        {
            GetAbilityView("Force", NameOf(() => PlayerCharacter.Abilities.Strength.BaseScore)).Column(0).Row(0),
            GetAbilityView("Dextérité", NameOf(() => PlayerCharacter.Abilities.Dexterity.BaseScore)).Column(0).Row(1),
            GetAbilityView("Constitution", NameOf(() => PlayerCharacter.Abilities.Constitution.BaseScore)).Column(0).Row(2),
            GetAbilityView("Intelligence", NameOf(() => PlayerCharacter.Abilities.Intelligence.BaseScore)).Column(1).Row(0),
            GetAbilityView("Sagesse", NameOf(() => PlayerCharacter.Abilities.Wisdom.BaseScore)).Column(1).Row(1),
            GetAbilityView("Charisme", NameOf(() => PlayerCharacter.Abilities.Charisma.BaseScore)).Column(1).Row(2),
        },
    };

    public ProgressionView()
	{
        //Content = new TableView
        //{
        //	HasUnevenRows = true,
        //	Root = new TableRoot("Création de PJ")
        //	{				
        //		new TableSection("Classe")
        //		{
        //			new ViewCell
        //			{
        //				View = ClassView,
        //			},
        //                  //new ViewCell
        //                  //{
        //                  //    View = ClassView,
        //                  //}
        //              },
        //		new TableSection("Origine")
        //		{

        //		}
        //	}
        //};

        Content = new FlexLayout
        {
            JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly,
            AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Start,
            AlignContent = Microsoft.Maui.Layouts.FlexAlignContent.Start,
            Direction = Microsoft.Maui.Layouts.FlexDirection.Row,
            Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap,
            Children =
            {
                OriginView,
                BackgroundView,
                ClassView,
                AbilitiesView,
            }
        };
  //      Content = new StackLayout
		//{
  //          OriginView,
		//	BackgroundView,
  //          ClassView,
  //      };


		//OriginPicker.SelectedIndexChanged += OriginView_SelectedIndexChanged;
        //BackgroundView.SelectedIndexChanged += BackgroundView_SelectedIndexChanged;
        //ClassView.SelectedIndexChanged += ClassView_SelectedIndexChanged;
    }

    private void BackgroundView_SelectedIndexChanged(object sender, EventArgs e)
    {
        var pc = Ioc.Default.GetRequiredService<Settings>().CurrentPlayerCharacter;
        var datum = (BackgroundDatum)BackgroundView.SelectedItem;
        pc.Background = pc.Factory.CreateBackground(id: datum.ID);
        pc.Refresh();
    }

    private void OriginView_SelectedIndexChanged(object sender, EventArgs e)
	{
        var pc = Ioc.Default.GetRequiredService<Settings>().CurrentPlayerCharacter;
		var datum = (OriginDatum)OriginPicker.SelectedItem;
		pc.Origin = pc.Factory.CreateOrigin(id: datum.ID);
        pc.Refresh();

        //OriginView.ItemsSource = OriginView.GetItemsAsArray();
    }

    private void ClassView_SelectedIndexChanged(object sender, EventArgs e)
	{
		var pc = Ioc.Default.GetRequiredService<Settings>().CurrentPlayerCharacter;
		//pc.Classes.Clear();
		var datum = (ClassDatum)ClassView.SelectedItem;
		pc.Classes.Clear();
        var cl = pc.Factory.CreateClass(id: datum.ID, 1);
        pc.Classes.Add(cl);
        cl.HitPointsPerLevel.Add(cl.HitDice);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;
        //pc.Classes.Remove(pc.PrimaryClass);
        pc.Refresh();
        //ClassView.SelectedItem = ClassView.Items[ClassView.SelectedIndex];
    }
}