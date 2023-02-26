using CommunityToolkit.Maui.Markup;

namespace SRD5Helper.Views; 
public class Styles
{
    #region Colors

    public Color PageBackgroundColor => Color.FromArgb("AAF5F5F5");
    public Color PageTextColor => Color.FromArgb("000000");
    public Color LightGreyFrameBackgroundColor => Color.FromArgb("CCFFFFFF");
    //public Color LightGreyFrameBackgroundColor => Color.FromArgb("AAE1E1E6");
    public Color LightGreyFrameBorderColor => Color.FromArgb("D5CFCA");
    public Color DarkGreyFrameBackgroundColor => Color.FromArgb("AAFFFFFF");
    //public Color DarkGreyFrameBackgroundColor => Color.FromArgb("AAB3C4D6");
    public Color DarkGreyFrameBorderColor => Color.FromArgb("A1A9B4");

    public Color TableTitleBackgroundColor => Color.FromArgb("99566371");
    //public Color TableTitleBackgroundColor => Color.FromArgb("AA566371");
    public Color TableTitleTextColor => Color.FromArgb("F9F9F9");

    public Color HexagonBulletLightColor => Color.FromArgb("ACA39B");
    public Color HexagonBulletDarkColor => Color.FromArgb("565371");

    #endregion Colors

    #region Fonts
    public double XXXMicroLabelFontSize => XMicroLabelFontSize / 2;
    public double XXMicroLabelFontSize => MicroLabelFontSize / 2;
    public double XMicroLabelFontSize => SmallLabelFontSize / 2;
    public double MicroLabelFontSize => Device.GetNamedSize(NamedSize.Micro, typeof(Label));
    public double SmallLabelFontSize => Device.GetNamedSize(NamedSize.Small, typeof(Label));
    public double MediumLabelFontSize => Device.GetNamedSize(NamedSize.Medium, typeof(Label));
    public double LargeLabelFontSize => Device.GetNamedSize(NamedSize.Large, typeof(Label));

    public double TitleLabelFontSize => Device.GetNamedSize(NamedSize.Title, typeof(Label));
    public double SubtitleLabelFontSize => Device.GetNamedSize(NamedSize.Subtitle, typeof(Label));
    public double HeaderLabelFontSize => Device.GetNamedSize(NamedSize.Header, typeof(Label));
    public double CaptionLabelFontSize => Device.GetNamedSize(NamedSize.Caption, typeof(Label));
    public double BodyLabelFontSize => Device.GetNamedSize(NamedSize.Body, typeof(Label));
    public double DefaultLabelFontSize => Device.GetNamedSize(NamedSize.Default, typeof(Label));

    public string BasicFontFamily => "LiberationSansRegular";
    public string ScriptFontFamily => "WolgastTwoBold";
    public string TitleFontFamily => "CapitalisTypOasis";
    public string ButtonFontFamily => "Florencesans";

    public Color DefaultTextColor => Colors.Black;
    public Color DefaultBackgroundColor => Colors.Transparent;

    #endregion Fonts


    #region SkillsView
    private Style<ContentView> _skills = null;
    public Style<ContentView> Skills => _skills ??= new Style<ContentView>(
        (ContentView.BackgroundProperty, DefaultBackgroundColor)
    );

    private Style<HexagonView> _skillProficiency = null;
    public Style<HexagonView> SkillProficiency => _skillProficiency ??= new Style<HexagonView>(
    ).BasedOn(DefaultListBullet);

    private Style<HexagonView> _skillProficiencyTrue = null;
    public Style<HexagonView> SkillProficiencyTrue => _skillProficiencyTrue ??= new Style<HexagonView>(
    ).BasedOn(DefaultListBulletTrue);

    private Style<HexagonView> _skillProficiencyFalse = null;
    public Style<HexagonView> SkillProficiencyFalse => _skillProficiencyFalse ??= new Style<HexagonView>(
    ).BasedOn(DefaultListBulletFalse);

    private Style<Label> _skillID = null;
    public Style<Label> SkillID => _skillID ??= new Style<Label>(
    ).BasedOn(DefaultListBasicLabel);

    private Style<Label> _skillAbilityID = null;
    public Style<Label> SkillAbilityID => _skillAbilityID ??= new Style<Label>(
        (Span.FontSizeProperty, MicroLabelFontSize),
        (Span.TextTransformProperty, TextTransform.Uppercase)
    ).BasedOn(DefaultListBasicLabel);

    private Style<Label> _skillMod = null;
    public Style<Label> SkillMod => _skillMod ??= new Style<Label>(
        (Label.FontSizeProperty, LargeLabelFontSize)
    ).BasedOn(DefaultListScriptLabel);

    private Style<Label> _skillModDescription = null;
    public Style<Label> SkillModDescription => _skillModDescription ??= new Style<Label>(
        (Label.FontFamilyProperty, BasicFontFamily),
        (Label.TextColorProperty, DefaultTextColor),
        (Label.BackgroundColorProperty, DefaultBackgroundColor),
        (Label.FontSizeProperty, AbilityHexagonHeight / 6)
    );

    #endregion SkillsView





    #region FeaturesView
    private Style<Label> _featureName = null;
    public Style<Label> FeatureName => _featureName ??= new Style<Label>(
        (Label.FontFamilyProperty, BasicFontFamily),
        (Label.FontSizeProperty, SmallLabelFontSize),
        (Label.TextColorProperty, DefaultTextColor)
    );
    #endregion FeaturesView





    #region AbilitiesView
#if ANDROID
    public double AbilityHexagonHeight => DeviceDisplay.MainDisplayInfo.Height / (14 * DeviceDisplay.MainDisplayInfo.Density); // LargeLabelFontSize * 2;
#else
    public double AbilityHexagonHeight => LargeLabelFontSize * 2;
#endif

    private Style<StackLayout> _abilities = null;
    public Style<StackLayout> Abilities => _abilities ??= new Style<StackLayout>(
        (StackLayout.SpacingProperty, -AbilityHexagonHeight/4)
    );

    private Style<HexagonView> _abilityScore = null;
    public Style<HexagonView> AbilityScore => _abilityScore ??= new Style<HexagonView>(
        (HexagonView.HexagonHeightProperty, AbilityHexagonHeight),
        (HexagonView.HexagonStrokeProperty, Color.FromArgb("849098")),
        (HexagonView.HexagonStrokeThicknessProperty, 4),
        (HexagonView.BackgroundProperty, Color.FromArgb("E8E4E0"))
    );
    private Style<HexagonView> _abilitySave = null;
    public Style<HexagonView> AbilitySave => _abilitySave ??= new Style<HexagonView>(
        //(HexagonView.HexagonHeightProperty, AbilityHexagonHeight),
        (HexagonView.HexagonStrokeProperty, Color.FromArgb("849098")),
        (HexagonView.HexagonStrokeThicknessProperty, 4),
        (HexagonView.BackgroundProperty, Color.FromArgb("E8E4E0"))
    );


    private Style<Label> _abilityMod = null;
    public Style<Label> AbilityMod => _abilityMod ??= new Style<Label>(
        (Label.FontFamilyProperty, ScriptFontFamily),
        (Label.TextColorProperty, DefaultTextColor),
        (Label.BackgroundColorProperty, DefaultBackgroundColor)
        //(Label.FontSizeProperty, AbilityHexagonHeight / 2) 
        //(Label.PaddingProperty, new Thickness(AbilityHexagonHeight / 2, 0, 0, 0))
    );

    private Style<Label> _abilityModHeader = null;
    public Style<Label> AbilityModHeader => _abilityModHeader ??= new Style<Label>(
        (Label.FontFamilyProperty, BasicFontFamily),
        (Label.TextColorProperty, DefaultTextColor),
        (Label.BackgroundColorProperty, DefaultBackgroundColor),
        //(Label.FontSizeProperty, AbilityHexagonHeight / 6), 
        (Label.TextTransformProperty, TextTransform.Uppercase)
        //(Label.PaddingProperty, new Thickness(AbilityHexagonHeight / 4, AbilityHexagonHeight / 8, 0, 0))
    );

    private Style<HexagonBullet> _abilitySaveProficiency = null;
    public Style<HexagonBullet> AbilitySaveProficiency => _abilitySaveProficiency ??= new Style<HexagonBullet>(
        (HexagonBullet.HexagonHeightProperty, AbilityHexagonHeight / 3)
    );
    private Style<HexagonBullet> _abilitySaveProficiencyTrue = null;
    public Style<HexagonBullet> AbilitySaveProficiencyTrue => _abilitySaveProficiencyTrue ??= new Style<HexagonBullet>(
        (HexagonBullet.ColorProperty, HexagonBulletDarkColor),
        (HexagonBullet.BackgroundProperty, HexagonBulletDarkColor)
    ).BasedOn(AbilitySaveProficiency);
    private Style<HexagonBullet> _abilitySaveProficiencyFalse = null;
    public Style<HexagonBullet> AbilitySaveProficiencyFalse => _abilitySaveProficiencyFalse ??= new Style<HexagonBullet>(
        (HexagonBullet.ColorProperty, HexagonBulletLightColor),
        (HexagonBullet.BackgroundProperty, HexagonBulletLightColor) // HexagonBulletLightColor)
    ).BasedOn(AbilitySaveProficiency);
#endregion AblitiesView


#region SpellsView
    Style<Label> _spellsHeaderLabel;
    public Style<Label> SpellsHeaderLabel => _spellsHeaderLabel ??= new Style<Label>(
        (Label.TextColorProperty, TableTitleTextColor),
        (Label.FontFamilyProperty, BasicFontFamily),
        (Label.FontSizeProperty, MediumLabelFontSize),
        (Label.FontAttributesProperty, FontAttributes.Bold),
        (Label.TextTransformProperty, TextTransform.Uppercase)
    );
    Style<VisualElement> _spellsHeaderView;
    public Style<VisualElement> SpellsHeaderView => _spellsHeaderView ??= new Style<VisualElement>(
        (VisualElement.BackgroundColorProperty, TableTitleBackgroundColor)
    ).CanCascade(true);
#endregion SpellsView










#region Alternate lists

    public double DefaultListFontSize => SmallLabelFontSize;

    private Style<HexagonView> _defaultListBullet = null;
    public Style<HexagonView> DefaultListBullet => _defaultListBullet ??= new Style<HexagonView>(
        (HexagonView.HexagonHeightProperty, DefaultListFontSize * 1.5)
    );
    private Style<HexagonView> _defaultListBulletTrue = null;
    public Style<HexagonView> DefaultListBulletTrue => _defaultListBulletTrue ??= new Style<HexagonView>(
        (HexagonView.BackgroundProperty, HexagonBulletDarkColor)
    ).BasedOn(DefaultListBullet);
    private Style<HexagonView> _defaultListBulletFalse = null;
    public Style<HexagonView> DefaultListBulletFalse => _defaultListBulletFalse ??= new Style<HexagonView>(
        (HexagonView.BackgroundProperty, HexagonBulletLightColor)
    ).BasedOn(DefaultListBullet);

    private Style<Label> _defaultListBasicLabel = null;
    public Style<Label> DefaultListBasicLabel => _defaultListBasicLabel ??= new Style<Label>(
        (Label.FontFamilyProperty, BasicFontFamily),
        (Label.FontSizeProperty, DefaultListFontSize),
        (Label.TextColorProperty, DefaultTextColor),
        (Label.FontAttributesProperty, FontAttributes.Bold)
    );

    private Style<Label> _defaultListScriptLabel = null;
    public Style<Label> DefaultListScriptLabel => _defaultListScriptLabel ??= new Style<Label>(
        (Label.FontFamilyProperty, ScriptFontFamily),
        (Label.FontSizeProperty, DefaultListFontSize),
        (Label.TextColorProperty, DefaultTextColor),
        (Label.FontAttributesProperty, FontAttributes.Bold)
    );

    Style<VisualElement> _alternateEven = null;
    public Style<VisualElement> AlternateEven => _alternateEven ??= new Style<VisualElement>
    (
        (VisualElement.BackgroundProperty, DarkGreyFrameBackgroundColor)//  Color.FromArgb("CDD1D9"))
    );
    Style<VisualElement> _alternateUneven = null;
    public Style<VisualElement> AlternateUneven => _alternateUneven ??= new Style<VisualElement>
    (
        (VisualElement.BackgroundProperty, LightGreyFrameBackgroundColor) // Color.FromArgb("E8E5E2"))
    );

#endregion Alternate lists


#region Implicit styles
    public ResourceDictionary Implicit => new()
    {
        //Labels,
        //CollectionViews,
        //ContentViews
    };

    Style<Label> labels;
    public Style<Label> Labels => labels ??= new Style<Label>(
        (Label.FontSizeProperty, 13),
        (Label.TextColorProperty, Colors.Black)
    );

    Style<ContentView> contentViews;
    public Style<ContentView> ContentViews => contentViews ??= new Style<ContentView>(
        (ContentView.BackgroundProperty, PageBackgroundColor)
    );

    Style<CollectionView> collectionViews;
    public Style<CollectionView> CollectionViews => collectionViews ??= new Style<CollectionView>(
        (CollectionView.BackgroundProperty, Colors.White)
    );

#endregion Implicit styles

}
