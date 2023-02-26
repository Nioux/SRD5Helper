
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.ViewModels;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using static SRD5Helper.Tools.Helpers;

namespace SRD5Helper.Views; 
public class SecondBoardView : ContentView
{
    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();

    public static readonly BindableProperty PlayerCharacterProperty =
        BindableProperty.Create(nameof(PlayerCharacter), typeof(PlayerCharacter), typeof(BoardView), null);

    public PlayerCharacter PlayerCharacter
    {
        get => (PlayerCharacter)GetValue(PlayerCharacterProperty);
        set => SetValue(PlayerCharacterProperty, value);
    }

    //protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //{
    //    base.OnPropertyChanged(propertyName);
    //    if (propertyName == nameof(PlayerCharacter))
    //    {
    //        InitContent();
    //    }
    //}

    public PlayerCharacterCommands PlayerCharacterCommands => Ioc.Default.GetRequiredService<PlayerCharacterCommands>();

    public SecondBoardView()
    {
        BackgroundColor = Styles.PageBackgroundColor;

        InitContent();
    }

    public void InitContent()
    { 
        Content = new StackLayout
        {
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.ProficiencyBonus)}", convert: (int val) => $"Bonus de Maîtrise = {val:+0;-#}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.Initiative)}", convert: (int val) => $"Initiative = {val:+0;-#}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.ArmorClass)}", convert: (int val) => $"Classe d'Armure = {val}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.TotalTemporaryHitPoints)}", convert: (int val) => $"Total PV actuels (+bonus) = {val}"),

            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.PassiveWisdom)}", convert: (int val) => $"Perception Passive = {val}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.MeleeAttackBonus)}", convert: (int val) => $"Bonus Attaque corps à corps = {val:+0;-#}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.RangedAttackBonus)}", convert: (int val) => $"Bonus Attaque à distance = {val:+0;-#}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.SpellAttackBonus)}", convert: (int? val) => $"Bonus Attaque Magique = " + (val != null ? $"{val:+0;-#}" : "-")),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.SpellSaveDC)}", convert: (int? val) => $"DD des Jets de sauv. sorts = " + (val != null ? $"{val}" : "-")),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.CurrentHitPoints)}", convert: (int val) => $"PV max = {val}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.TotalCurrentHitPoints)}", convert: (int val) => $"Total PV max (+bonus) = {val}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.TemporaryHitPoints)}", convert: (int val) => $"PV actuels = {val}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.TotalTemporaryHitPoints)}", convert: (int val) => $"Total PV actuels (+bonus) = {val}"),
            new Label { Style = Styles.DefaultListBasicLabel }
                .Bind(Label.TextProperty, source: this, path: $"{nameof(PlayerCharacter)}.{nameof(PlayerCharacter.HitDice)}", convert: (int val) => $"Dés de Vie = d{val}"),                
        };
    }
}
