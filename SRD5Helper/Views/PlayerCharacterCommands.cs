using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using iTextSharp.text.pdf;
using Markdig;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Storage;
using SRD5Helper.Tools;
using SRD5Helper.Units;
using SRD5Helper.ViewModels;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace SRD5Helper.Views;

public class PlayerCharacterCommands
{
    public RelayCommand TestCommand => new RelayCommand(ExecuteTestCommand);
    protected void ExecuteTestCommand()
    {
        SRD5Helper.App.Current.MainPage.DisplayAlert("test", "test", "fermer");
    }
    #region PlayerCharacter
    /// <summary>
    /// Repos court
    /// </summary>
    public RelayCommand<PlayerCharacter> ShortRestComand { get => new RelayCommand<PlayerCharacter>(ExecuteShortRestCommand); }
    protected void ExecuteShortRestCommand(PlayerCharacter pc)
    {
    }

    /// <summary>
    /// Repos long
    /// </summary>
    public RelayCommand<PlayerCharacter> LongRestComand { get => new RelayCommand<PlayerCharacter>(ExecuteLongRestCommand); }
    protected void ExecuteLongRestCommand(PlayerCharacter pc)
    {
        pc.TemporaryHitPoints = pc.CurrentHitPoints;
    }

    /// <summary>
    /// Montée de niveau
    /// </summary>
    public AsyncRelayCommand<PlayerCharacter> UpLevelCommand => new AsyncRelayCommand<PlayerCharacter>(ExecuteUpLevelCommandAsync);

    protected async Task ExecuteUpLevelCommandAsync(PlayerCharacter pc)
    {
        if (pc.PrimaryClass.Level < 20)
        {
            pc.PrimaryClass.UpLevel();
        }
        pc.Refresh();
    }
    #endregion PlayerCharacter

    #region Ability
    public AsyncRelayCommand<Ability> AbilityScoreCommand => new AsyncRelayCommand<Ability>(ExecuteAbilityScoreCommandAsync);
    private async Task ExecuteAbilityScoreCommandAsync(Ability ability)
    {
        switch (Ioc.Default.GetRequiredService<Settings>().UserMode)
        {
            case UserMode.Beginner:
                await ExecuteRollAbilityModCommandAsync(ability);
                break;
            case UserMode.Advanced:
                //await ExecuteEditAbilityScoreCommandAsync(ability);
                break;
            case UserMode.Debug:
                //await ExecuteIncrementAbilityScoreCommandAsync(ability);
                break;
        }
    }

    public AsyncRelayCommand<Ability> AbilityModCommand => new AsyncRelayCommand<Ability>(ExecuteAbilityModCommandAsync);
    private async Task ExecuteAbilityModCommandAsync(Ability ability)
    {
        switch (Ioc.Default.GetRequiredService<Settings>().UserMode)
        {
            case UserMode.Beginner:
                await ExecuteRollAbilityModCommandAsync(ability);
                break;
            case UserMode.Normal:
                //await ExecuteAbilityChooseModCommandAsync(ability);
                break;
            /*case UserMode.Advanced:
                await ExecuteEditAbilityModCommandAsync(ability);
                break;
            case UserMode.Debug:
                await ExecuteIncrementAbilityModCommandAsync(ability);
                break;*/
        }
    }

    public AsyncRelayCommand<Ability> AbilitySaveCommand => new AsyncRelayCommand<Ability>(ExecuteAbilitySaveCommandAsync);
    private async Task ExecuteAbilitySaveCommandAsync(Ability ability)
    {
        switch (Ioc.Default.GetRequiredService<Settings>().UserMode)
        {
            case UserMode.Beginner:
                await ExecuteRollAbilitySaveCommandAsync(ability);
                break;
            case UserMode.Normal:
                //await ExecuteChooseSaveCommandAsync(ability);
                break;
            case UserMode.Advanced:
                //await ExecuteEditAbilitySaveCommandAsync(ability);
                break;
            case UserMode.Debug:
                //await ExecuteIncrementAbilitySaveCommandAsync(ability);
                break;
        }
    }

    public AsyncRelayCommand<Ability> AbilityProficiencyCommand => new AsyncRelayCommand<Ability>(ExecuteAbilityProficiencyCommandAsync);
    private async Task ExecuteAbilityProficiencyCommandAsync(Ability ability)
    {
        switch (Ioc.Default.GetRequiredService<Settings>().UserMode)
        {
            case UserMode.Beginner:
                //await ExecuteRollSaveCommandAsync(ability);
                break;
            case UserMode.Normal:
                //await ExecuteChooseSaveCommandAsync(ability);
                break;
            case UserMode.Advanced:
                await ExecuteEditAbilityProficiencyCommandAsync(ability);
                break;
            case UserMode.Debug:
                await ExecuteToggleAbilityProficiencyCommandAsync(ability);
                break;
        }
    }

    public AsyncRelayCommand<Ability> ChooseAbilityScoreCommand => new AsyncRelayCommand<Ability>(ExecuteChooseAbilityScoreCommandAsync);
    private async Task ExecuteChooseAbilityScoreCommandAsync(Ability ability)
    {
        //await App.Current.MainPage.Navigation.PushModalAsync(new ContentPage { Background = Color.FromArgb("BB445566") /*Colors.Transparent*/, Content = new Label { Text = "yes !" } }, true);
        //return;
        var choiceEditScore = $"/!\\ Modifier score /!\\";
        var choiceEditMod = $"/!\\ Modifier mod /!\\";
        var choiceEditSave = $"/!\\ Modifier sauvegarde /!\\";
        var choiceEditProficiency = $"/!\\ Modifier maitrise /!\\";
        var choiceRollMod = $"Test de caractéristique";
        var choiceRollSave = $"Jet de sauvegarde";
        var choice = await SRD5Helper.App.Current.MainPage.DisplayActionSheet($"Caractéristique : {ability.Name}", "Annuler", null, new string[]
        {
        choiceEditScore,
        choiceEditMod,
        choiceEditSave,
        choiceEditProficiency,
        choiceRollMod,
        choiceRollSave,
        });

        if (choice == choiceEditScore)
        {
            //await ExecuteEditAbilityScoreCommandAsync(ability);
        }
        else if (choice == choiceEditMod)
        {
            //await ExecuteEditAbilityModCommandAsync(ability);
        }
        else if (choice == choiceEditSave)
        {
            //await ExecuteEditAbilitySaveCommandAsync(ability);
        }
        else if (choice == choiceEditProficiency)
        {
            //ability.SaveProficiency = !ability.SaveProficiency;
        }
        else if (choice == choiceRollMod)
        {
            await ExecuteRollAbilityModCommandAsync(ability);
        }
        else if (choice == choiceRollSave)
        {
            await ExecuteRollAbilitySaveCommandAsync(ability);
        }
    }

    //public AsyncRelayCommand<Ability> EditAbilityScoreCommand => new AsyncRelayCommand<Ability>(ExecuteEditAbilityScoreCommandAsync);
    //private async Task ExecuteEditAbilityScoreCommandAsync(Ability ability)
    //{
    //    var values = Enumerable.Range(1, 20).Reverse().Select(i => i.ToString()).ToArray();
    //    var score = await App.Current.MainPage.DisplayActionSheet($"Caractéristique : {ability.Name} ({ability.Score})", "Annuler", "Restaurer", values);

    //    if (score == "Restaurer")
    //    {
    //        ability.Score = null;
    //    }
    //    else if (score != "Annuler")
    //    {
    //        ability.Score = int.Parse(score);
    //    }
    //}

    /*public AsyncRelayCommand<Ability> EditAbilityModCommand => new AsyncRelayCommand<Ability>(ExecuteEditAbilityModCommandAsync);
    private async Task ExecuteEditAbilityModCommandAsync(Ability ability)
    {
        var values = Enumerable.Range(-7, 14).Reverse().Select(i => i.ToString("+0;-#")).ToArray();
        var mod = await App.Current.MainPage.DisplayActionSheet($"Mod : {ability.Name} ({ability.Mod:+0;-#})", "Annuler", "Restaurer", values);

        if (mod == "Restaurer")
        {
            ability.Mod = null;
        }
        else if (mod != "Annuler")
        {
            ability.Mod = int.Parse(mod);
        }
    }*/

    //public AsyncRelayCommand<Ability> EditAbilitySaveCommand => new AsyncRelayCommand<Ability>(ExecuteEditAbilitySaveCommandAsync);
    //private async Task ExecuteEditAbilitySaveCommandAsync(Ability ability)
    //{
    //    var values = Enumerable.Range(-7, 14).Reverse().Select(i => i.ToString("+0;-#")).ToArray();
    //    var save = await App.Current.MainPage.DisplayActionSheet($"Sauv. : {ability.Name} ({ability.Save:+0;-#})", "Annuler", "Restaurer", values);

    //    if (save == "Restaurer")
    //    {
    //        ability.Save = null;
    //    }
    //    else if (save != "Annuler")
    //    {
    //        ability.Save = int.Parse(save);
    //    }
    //}

    public AsyncRelayCommand<Ability> EditAbilityProficiencyCommand => new AsyncRelayCommand<Ability>(ExecuteEditAbilityProficiencyCommandAsync);
    private async Task ExecuteEditAbilityProficiencyCommandAsync(Ability ability)
    {
        var choiceRevert = "Inverser";
        var choiceDelete = "Supprimer";
        var values = new string[] { choiceRevert };
        var save = await SRD5Helper.App.Current.MainPage.DisplayActionSheet($"Sauv. : {ability.Name} ({ability.Save})", "Annuler", "Restaurer", values);

        if (save == "Restaurer")
        {
            //ability.SaveProficiency = null;
        }
        else if (save == "Inverser")
        {
            //ability.SaveProficiency = !ability.SaveProficiency;
        }
    }

    public AsyncRelayCommand<Ability> ToggleAbilityProficiencyCommand => new AsyncRelayCommand<Ability>(ExecuteToggleAbilityProficiencyCommandAsync);
    private async Task ExecuteToggleAbilityProficiencyCommandAsync(Ability ability)
    {
        //ability.SaveProficiency = !ability.SaveProficiency;
    }


    public static class GameIconsFont
    {
        public static string D4 => "\uf446";
        public static string D6 => "\ufa80";
        public static string D8 => "\uf47f";
        public static string D10 => "\uf444";
        public static string D12 => "\uf445";
        public static string D20 => "\uf48a";

        public static Dictionary<int, string> Dice => new Dictionary<int, string>
        {
            [4] = D4,
            [6] = D6,
            [8] = D8,
            [10] = D10,
            [12] = D12,
            [20] = D20,
        };
    }

    public Styles Styles => Ioc.Default.GetRequiredService<Styles>();
    public AsyncRelayCommand<Ability> RollAbilityModCommand => new AsyncRelayCommand<Ability>(ExecuteRollAbilityModCommandAsync);
    private async Task ExecuteRollAbilityModCommandAsync(Ability ability)
    {

        var choiceNormal = "Normal";
        var choiceAdvantage = "Avantage";
        var choiceDisadvantage = "Désavantage";
        var values = new string[] { choiceNormal, choiceAdvantage, choiceDisadvantage };
        var choice = await SRD5Helper.App.Current.MainPage.DisplayActionSheet($"Test de caractéristique ({ability.Name})", "Annuler", null, values);

        AdvantageDisadvantage advantageDisadvantage = AdvantageDisadvantage.Null;
        if (choice == choiceNormal)
        {
            advantageDisadvantage = AdvantageDisadvantage.Null;
        }
        else if (choice == choiceAdvantage)
        {
            advantageDisadvantage = AdvantageDisadvantage.Advantage;
        }
        else if (choice == choiceDisadvantage)
        {
            advantageDisadvantage = AdvantageDisadvantage.Disadvantage;
        }
        else
        {
            return;
        }



        // https://www.andreasnesheim.no/playing-audio-in-a-net-maui-app/
        // https://freesound.org/people/dermotte/sounds/220744/
        var audioPlayer = Plugin.Maui.Audio.AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("220744__dermotte__dice_06.wav"));
        //var audioPlayer = Plugin.Maui.Audio.AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("alfur_male_1_1.mp3"));
        audioPlayer.Play();

        var d20 = Random.Shared.Next(20) + 1;
        //var text = $"# Test de caractéristique ({ability.Datum.Name})\n\n## ![image](d20.png) 1d20 + Mod ({ability.Datum.Name})\n\n## = {d20} {ability.Mod:+0;-#}\n\n## = {d20 + ability.Mod}\n\n# {d20 + ability.Mod}";
        //var text = $"# Test de caractéristique ({ability.Datum.Name})\n\n![image](fonts:FontAwesome?text=&#xf6cf; \uf6cf;&amp;size=30&amp;color=000000) + Mod ({ability.Datum.Name}) = {d20} {ability.Mod:+0;-#} = {d20 + ability.Mod}\n\n# {d20 + ability.Mod}";
        //var text = $"# Test de caractéristique ({ability.Datum.Name})\n\n![image](fonts:GameIcons?text={GameIconsFont.D20}&amp;size=30&amp;color=000000) + Mod ({ability.Datum.Name}) = {d20} {ability.Mod:+0;-#} = {d20 + ability.Mod}\n\n# {d20 + ability.Mod}";


        /*var formattedText = new FormattedString
        {
            Spans =
            {
                new Span { Text = $"Test de caractéristique ({ability.Name})\n\n", FontFamily = Styles.BasicFontFamily, FontSize = Styles.TitleLabelFontSize * 2, },
                new Span { Text = GameIconsFont.D20, FontFamily = "GameIcons", FontSize = Styles.SubtitleLabelFontSize * 2, },
                new Span { Text = $" + Mod ({ability.Name}) = {d20} {ability.Mod:+0;-#} = {d20 + ability.Mod}\n\n", FontSize = Styles.SubtitleLabelFontSize * 2, },
                new Span { Text = $"{d20 + ability.Mod}", FontFamily = Styles.BasicFontFamily, FontSize = Styles.TitleLabelFontSize * 2, },
            }
        };
        var label = new Label { LineBreakMode = LineBreakMode.WordWrap, BackgroundColor = Colors.White, TextColor = Colors.Black, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FormattedText = formattedText };*/


        //var bottomSheet = new BottomSheet.BottomSheet
        //{
        //    HeaderText = "test",
        //    BottomSheetContent = new AbilityDiceRollView { Ability = ability },
        //};


        var popup = new Popup
        {
            //HorizontalOptions = Microsoft.Maui.Primitives.LayoutAlignment,
            //VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.End,
            CanBeDismissedByTappingOutsideOfPopup = true,
            Content = new AbilityDiceRollView { Ability = ability }, // new Grid { MaximumWidthRequest = 400,  Children = { label } },
            /*Content = new Xam.Forms.Markdown.MarkdownView 
            { 
                Markdown = text 
            } */
        };
        var _ = Task.Delay(5000).ContinueWith(async (t) =>
        SRD5Helper.App.Current.Dispatcher.Dispatch(() =>
        {
            try
            {
                popup?.Close();
            }
            catch (Exception)
            { }
        }
        )).ConfigureAwait(false);
        //label.RotateTo(360, 2000, Easing.SinInOut);
        //label.ScaleTo(1, 2000, Easing.SinInOut);
        await SRD5Helper.App.Current.MainPage.ShowPopupAsync(popup);
        popup = null;
        /*CommunityToolkit.Maui.Alerts.Snackbar snack = null;
        snack = new CommunityToolkit.Maui.Alerts.Snackbar()
        {
            Text = text,
            ActionButtonText = $"{d20 + ability.Mod}",
            Action = () => snack.Dismiss(), // async () => await ExecuteRollModCommandAsync(),
            Duration = new TimeSpan(0, 0, 10),
            VisualOptions = new CommunityToolkit.Maui.Core.SnackbarOptions
            {
                Font = Microsoft.Maui.Font.SystemFontOfSize(20),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(60),
                ActionButtonTextColor = Colors.Red,
                BackgroundColor = Color.FromArgb("DDFFFFFF"),
                CornerRadius = new CornerRadius(20, 20, 20, 20),
            }
        };
        await snack.Show();*/
    }

    public AsyncRelayCommand<Ability> RollAbilitySaveCommand => new AsyncRelayCommand<Ability>(ExecuteRollAbilitySaveCommandAsync);
    private async Task ExecuteRollAbilitySaveCommandAsync(Ability ability)
    {
        var d20 = Random.Shared.Next(20) + 1;
        var text = $"Jet de sauvegarde ({ability.Name})\n\n1d20 + Sauv. ({ability.Name})\n\n= {d20} {ability.Save:+0;-#}\n\n= {d20 + ability.Save}";
        CommunityToolkit.Maui.Alerts.Snackbar snack = null;
        snack = new CommunityToolkit.Maui.Alerts.Snackbar()
        {
            Text = text,
            ActionButtonText = $"{d20 + ability.Save}",
            Action = () => snack.Dismiss(), // async () => await ExecuteRollSaveCommandAsync(),
            Duration = new TimeSpan(0, 0, 10),
            VisualOptions = new CommunityToolkit.Maui.Core.SnackbarOptions
            {
                Font = Microsoft.Maui.Font.SystemFontOfSize(20),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(60),
                ActionButtonTextColor = Colors.Red,
                BackgroundColor = Color.FromArgb("DDFFFFFF"),
                CornerRadius = new CornerRadius(20, 20, 20, 20),
            }
        };
        await snack.Show();
    }



    //public AsyncRelayCommand<Ability> IncrementAbilityScoreCommand => new AsyncRelayCommand<Ability>(ExecuteIncrementAbilityScoreCommandAsync);
    //private async Task ExecuteIncrementAbilityScoreCommandAsync(Ability ability)
    //{
    //    ability.Score = ability.Score + 1;
    //}

    /*public AsyncRelayCommand<Ability> IncrementAbilityModCommand => new AsyncRelayCommand<Ability>(ExecuteIncrementAbilityModCommandAsync);
    private async Task ExecuteIncrementAbilityModCommandAsync(Ability ability)
    {
        ability.Mod = ability.Mod + 1;
    }*/

    //public AsyncRelayCommand<Ability> IncrementAbilitySaveCommand => new AsyncRelayCommand<Ability>(ExecuteIncrementAbilitySaveCommandAsync);
    //private async Task ExecuteIncrementAbilitySaveCommandAsync(Ability ability)
    //{
    //    ability.Save = ability.Save + 1;
    //}

    /*public AsyncRelayCommand<Ability> DecrementAbilityModCommand => new AsyncRelayCommand<Ability>(ExecuteDecrementAbilityModCommandAsync);
    private async Task ExecuteDecrementAbilityModCommandAsync(Ability ability)
    {
        ability.Mod = ability.Mod - 1;
    }*/

    /*public AsyncRelayCommand<Ability> ResetAbilityModCommand => new AsyncRelayCommand<Ability>(ExecuteResetAbilityModCommandAsync);
    private async Task ExecuteResetAbilityModCommandAsync(Ability ability)
    {
        //await App.Current.MainPage.DisplayPromptAsync("ok", "ok");
        ability.Mod = null;
    }*/
    #endregion Ability


    #region Equipment
    public AsyncRelayCommand<Equipment> ShowEquipmentDescriptionCommand => new AsyncRelayCommand<Equipment>(ExecuteShowEquipmentDescriptionCommandAsync);
    private async Task ExecuteShowEquipmentDescriptionCommandAsync(Equipment equipment)
    {

        var popup = new Popup
        {
            //Size = new Size(600, 500),
            CanBeDismissedByTappingOutsideOfPopup = true,
            Content = new ScrollView
            {
                Content = new Xam.Forms.Markdown.MarkdownView
                {
                    Markdown = equipment.ToMarkdown() + "\n\n[lien](tototata)",
                    NavigateToLinkCommand = NavigateToLinkCommand
                },
            }
        };
        await SRD5Helper.App.Current.MainPage.ShowPopupAsync(popup);
        //var stream = await FileSystem.OpenAppPackageFileAsync("Raw/alfur.mp3");
        //Debug.WriteLine(stream.Length);
        //stream.Close();
        //var media = new Xamarin.CommunityToolkit.UI.Views.MediaElement();
        //media.Source = Xamarin.CommunityToolkit.Core.MediaSource.FromFile("alfur.mp3");
        //media.Play();
    }
    public AsyncRelayCommand<string> NavigateToLinkCommand => new AsyncRelayCommand<string>(ExecuteNavigateToLinkCommandAsync);
    private async Task ExecuteNavigateToLinkCommandAsync(string link)
    {

        var popup = new Popup
        {
            //Size = new Size(600, 500),
            CanBeDismissedByTappingOutsideOfPopup = true,
            Content = new ScrollView
            {
                Content = new Xam.Forms.Markdown.MarkdownView
                {
                    Markdown = link,
                    NavigateToLinkCommand = NavigateToLinkCommand
                },
            }
        };
        await SRD5Helper.App.Current.MainPage.ShowPopupAsync(popup);
        //var stream = await FileSystem.OpenAppPackageFileAsync("Raw/alfur.mp3");
        //Debug.WriteLine(stream.Length);
        //stream.Close();
        //var media = new Xamarin.CommunityToolkit.UI.Views.MediaElement();
        //media.Source = Xamarin.CommunityToolkit.Core.MediaSource.FromFile("alfur.mp3");
        //media.Play();
    }
    #endregion Equipment


    #region Skill
    public AsyncRelayCommand<Skill> SkillModCommand => new AsyncRelayCommand<Skill>(ExecuteSkillModCommandAsync);
    private async Task ExecuteSkillModCommandAsync(Skill skill)
    {
        switch (Ioc.Default.GetRequiredService<Settings>().UserMode)
        {
            case UserMode.Beginner:
                await ExecuteRollSkillModCommandAsync(skill);
                break;
            case UserMode.Normal:
                //await ExecuteChooseModCommandAsync(skill);
                break;
            case UserMode.Advanced:
                //await ExecuteEditSkillModCommandAsync(skill);
                break;
            case UserMode.Debug:
                //await ExecuteIncrementSkillModCommandAsync(skill);
                break;
        }
    }

    public AsyncRelayCommand<Skill> RollSkillModCommand => new AsyncRelayCommand<Skill>(ExecuteRollSkillModCommandAsync);
    private async Task ExecuteRollSkillModCommandAsync(Skill skill)
    {
        var d20 = Random.Shared.Next(20) + 1;
        var text = $"Test de compétence : {skill.Name} ({skill.Ability.Name})\n\n1d20 + {skill.Name} ({skill.Ability.Name})\n\n= {d20} {skill.Mod:+0;-#}\n\n= {d20 + skill.Mod}";
        CommunityToolkit.Maui.Alerts.Snackbar snack = null;
        snack = new CommunityToolkit.Maui.Alerts.Snackbar()
        {
            Text = text,
            ActionButtonText = $"{d20 + skill.Mod}",
            Action = () => snack.Dismiss(), // async () => await ExecuteRollModCommandAsync(),
            Duration = new TimeSpan(0, 0, 10),
            VisualOptions = new CommunityToolkit.Maui.Core.SnackbarOptions
            {
                Font = Microsoft.Maui.Font.SystemFontOfSize(20),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(60),
                ActionButtonTextColor = Colors.Red,
                BackgroundColor = Color.FromArgb("DDFFFFFF"),
                CornerRadius = new CornerRadius(20, 20, 20, 20),
            }
        };
        await snack.Show();
    }

    /*
    public AsyncRelayCommand<Skill> EditSkillModCommand => new AsyncRelayCommand<Skill>(ExecuteEditSkillModCommandAsync);
    private async Task ExecuteEditSkillModCommandAsync(Skill skill)
    {
        var values = Enumerable.Range(-7, 14).Reverse().Select(i => i.ToString("+0;-#")).ToArray();
        var mod = await App.Current.MainPage.DisplayActionSheet($"Mod : {skill.Name} ({skill.Mod:+0;-#})", "Annuler", "Restaurer", values);

        if (mod == "Restaurer")
        {
            skill.ModHack = null;
        }
        else if (mod != "Annuler")
        {
            skill.ModHack = int.Parse(mod);
        }
    }*/

    /*
    public AsyncRelayCommand<Skill> IncrementSkillModCommand => new AsyncRelayCommand<Skill>(ExecuteIncrementSkillModCommandAsync);
    private async Task ExecuteIncrementSkillModCommandAsync(Skill skill)
    {
        skill.ModHack = skill.ModHack + 1;
    }*/

    //public AsyncRelayCommand<Skill> ToggleSkillProficiencyCommand => new AsyncRelayCommand<Skill>(ExecuteToggleSkillProficiencyCommandAsync);
    //private async Task ExecuteToggleSkillProficiencyCommandAsync(Skill skill)
    //{
    //    skill.Proficiency = !skill.Proficiency;
    //}
    #endregion Skill

    #region Feature
    public AsyncRelayCommand<Feature> ChooseFeatureCommand => new AsyncRelayCommand<Feature>(ExecuteChooseFeatureCommandAsync);
    private async Task ExecuteChooseFeatureCommandAsync(Feature feature)
    {
        await SRD5Helper.App.Current.MainPage.DisplayAlert(feature?.Name, feature?.Description, "Fermer");

    }
    #endregion Feature


    public AsyncRelayCommand<PlayerCharacter> SetPlayerCharacterCommand => new AsyncRelayCommand<PlayerCharacter>(ExecuteSetPlayerCharacterCommandAsync);
    private async Task ExecuteSetPlayerCharacterCommandAsync(PlayerCharacter pc)
    {
        //MainThread.BeginInvokeOnMainThread(() =>
        //{
        Ioc.Default.GetRequiredService<Settings>().CurrentPlayerCharacter = pc;
        await Shell.Current.GoToAsync("//pc/abilities");
    }

    public AsyncRelayCommand<PlayerCharacter> ExportPDFPlayerCharacterCommand => new AsyncRelayCommand<PlayerCharacter>(ExecuteExportPDFPlayerCharacterCommandAsync);
    private async Task ExecuteExportPDFPlayerCharacterCommandAsync(PlayerCharacter pc)
    {
        await ExecuteSavePlayerCharacterCommandAsync(pc);
        var outfilename = await GeneratePdfAsync(pc);
        await OpenPdfAsync(outfilename);
    }



    public AsyncRelayCommand<Spell> ToggleSpellIsKnownCommand => new AsyncRelayCommand<Spell>(ExecuteToggleSpellIsKnownCommandAsync);
    private async Task ExecuteToggleSpellIsKnownCommandAsync(Spell spell)
    {
        if(spell.Class.KnownSpells.Contains(spell.ID))
        {
            spell.Class.KnownSpells.Remove(spell.ID);
        }
        else
        {
            spell.Class.KnownSpells.Add(spell.ID);
        }
    }

    public AsyncRelayCommand<Spell> ToggleSpellIsPreparedCommand => new AsyncRelayCommand<Spell>(ExecuteToggleSpellIsPreparedCommandAsync);
    private async Task ExecuteToggleSpellIsPreparedCommandAsync(Spell spell)
    {
        if (spell.Class.PreparedSpells.Contains(spell.ID))
        {
            spell.Class.PreparedSpells.Remove(spell.ID);
        }
        else
        {
            spell.Class.PreparedSpells.Add(spell.ID);
        }
    }





    public async Task<string> GeneratePdfAsync(PlayerCharacter playerCharacter)
    {
        return await Task.Run(async () =>
        {
            //var basePath = BasePdfDirectory;
            //Directory.CreateDirectory(basePath);
            var now = DateTime.Now;
            var fileName = string.Format("PJ_{0:yyyyMMddHHmmss}.pdf", now);
            var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                await GeneratePdfToStreamAsync(playerCharacter, stream);
                return filePath;
            }
        });
    }
    public async Task GeneratePdfToStreamAsync(PlayerCharacter playerCharacter, Stream stream)
    {
        PdfReader reader = null;
        try
        {
            reader = new PdfReader(await FileSystem.Current.OpenAppPackageFileAsync("RNP_FdP_interactive_PDF.pdf"));// AideDeJeu.Tools.Helpers.GetResourceStream("AideDeJeu.Pdf.feuille_de_personnage_editable.pdf"));
            PdfStamper stamper = null;
            try
            {
                stamper = new PdfStamper(reader, stream);
                var form = stamper.AcroFields;
                var fields = form.Fields;
#if DEBUG
                foreach (DictionaryEntry field in fields)
                {
                    var item = field.Value as AcroFields.Item;
                    System.Diagnostics.Debug.WriteLine(field.Key);
                    if (field.Key.ToString().Equals("Portrait"))
                    {
                        System.Diagnostics.Debug.WriteLine("Portrait");
                    }
                    form.SetField(field.Key.ToString(), field.Key.ToString());
                    var states = form.GetAppearanceStates(field.Key.ToString());
                    foreach (var state in states)
                    {
                        System.Diagnostics.Debug.WriteLine($"  {state}");
                    }
                }
#endif // DEBUG
                
                form.SetField("Nom du personnage", playerCharacter?.CharacterName ?? string.Empty);

                form.SetField("Force - Valeur", playerCharacter?.Abilities?.Strength?.Score.ToString() ?? string.Empty);
                form.SetField("Force - Modificateur", playerCharacter?.Abilities?.Strength?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Force - Sauvegarde", playerCharacter?.Abilities?.Strength?.Save.ToString("+0;-#") ?? string.Empty);
                form.SetField("Force - Maitrise", playerCharacter?.Abilities?.Strength?.SaveProficiency == true ? "Oui" : "Off");
                form.SetField("Dextérité - Valeur", playerCharacter?.Abilities?.Dexterity?.Score.ToString() ?? string.Empty);
                form.SetField("Dextérité - Modificateur", playerCharacter?.Abilities?.Dexterity?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Dextérité - Sauvegarde", playerCharacter?.Abilities?.Dexterity?.Save.ToString("+0;-#") ?? string.Empty);
                form.SetField("Dextérité - Maitrise", playerCharacter?.Abilities?.Dexterity?.SaveProficiency == true ? "Oui" : "Off");
                form.SetField("Constitution - Valeur", playerCharacter?.Abilities?.Constitution?.Score.ToString() ?? string.Empty);
                form.SetField("Constitution - Modificateur", playerCharacter?.Abilities?.Constitution?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Constitution - Sauvegarde", playerCharacter?.Abilities?.Constitution?.Save.ToString("+0;-#") ?? string.Empty);
                form.SetField("Constitution - Maitrise", playerCharacter?.Abilities?.Constitution?.SaveProficiency == true ? "Oui" : "Off");
                form.SetField("Intelligence - Valeur", playerCharacter?.Abilities?.Intelligence?.Score.ToString() ?? string.Empty);
                form.SetField("Intelligence - Modificateur", playerCharacter?.Abilities?.Intelligence?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Intelligence - Sauvegarde", playerCharacter?.Abilities?.Intelligence?.Save.ToString("+0;-#") ?? string.Empty);
                form.SetField("Intelligence - Maitrise", playerCharacter?.Abilities?.Intelligence?.SaveProficiency == true ? "Oui" : "Off");
                form.SetField("Sagesse - Valeur", playerCharacter?.Abilities?.Wisdom?.Score.ToString() ?? string.Empty);
                form.SetField("Sagesse - Modificateur", playerCharacter?.Abilities?.Wisdom?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Sagesse - Sauvegarde", playerCharacter?.Abilities?.Wisdom?.Save.ToString("+0;-#") ?? string.Empty);
                form.SetField("Sagesse - Maitrise", playerCharacter?.Abilities?.Wisdom?.SaveProficiency == true ? "Oui" : "Off");
                form.SetField("Charisme - Valeur", playerCharacter?.Abilities?.Charisma?.Score.ToString() ?? string.Empty);
                form.SetField("Charisme - Modificateur", playerCharacter?.Abilities?.Charisma?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Charisme - Sauvegarde", playerCharacter?.Abilities?.Charisma?.Save.ToString("+0;-#") ?? string.Empty);
                form.SetField("Charisme - Maitrise", playerCharacter?.Abilities?.Charisma?.SaveProficiency == true ? "Oui" : "Off");

                form.SetField("1", playerCharacter?.Skills?.Acrobatics?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Acrobaties - Maitrise", playerCharacter?.Skills?.Acrobatics?.Proficiency == true ? "Oui" : "Off");
                form.SetField("2", playerCharacter?.Skills?.Arcana?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Arcanes - Maitrise", playerCharacter?.Skills?.Arcana?.Proficiency == true ? "Oui" : "Off");
                form.SetField("3", playerCharacter?.Skills?.Athletics?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Athlétisme - Maitrise", playerCharacter?.Skills?.Athletics?.Proficiency == true ? "Oui" : "Off");
                form.SetField("4", playerCharacter?.Skills?.Stealth?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Discrétion - Maitrise", playerCharacter?.Skills?.Stealth?.Proficiency == true ? "Oui" : "Off");
                form.SetField("5", playerCharacter?.Skills?.AnimalHandling?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Dressage - Maitrise", playerCharacter?.Skills?.AnimalHandling?.Proficiency == true ? "Oui" : "Off");
                form.SetField("6", playerCharacter?.Skills?.SleightOfHand?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Escamotage - Maitrise", playerCharacter?.Skills?.SleightOfHand?.Proficiency == true ? "Oui" : "Off");
                form.SetField("7", playerCharacter?.Skills?.History?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Histoire - Maitrise", playerCharacter?.Skills?.History?.Proficiency == true ? "Oui" : "Off");
                form.SetField("8", playerCharacter?.Skills?.Intimidation?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Intimidation - Maitrise", playerCharacter?.Skills?.Intimidation?.Proficiency == true ? "Oui" : "Off");
                form.SetField("9", playerCharacter?.Skills?.Investigation?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Investigation - Maitrise", playerCharacter?.Skills?.Investigation?.Proficiency == true ? "Oui" : "Off");
                form.SetField("10", playerCharacter?.Skills?.Medicine?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Médecine - Maitrise", playerCharacter?.Skills?.Medicine?.Proficiency == true ? "Oui" : "Off");
                form.SetField("11", playerCharacter?.Skills?.Nature?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Nature - Maitrise", playerCharacter?.Skills?.Nature?.Proficiency == true ? "Oui" : "Off");
                form.SetField("12", playerCharacter?.Skills?.Perception?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Perception - Maitrise", playerCharacter?.Skills?.Perception?.Proficiency == true ? "Oui" : "Off");
                form.SetField("13", playerCharacter?.Skills?.Insight?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Perspicacité - Maitrise", playerCharacter?.Skills?.Insight?.Proficiency == true ? "Oui" : "Off");
                form.SetField("14", playerCharacter?.Skills?.Persuasion?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Persuasion - Maitrise", playerCharacter?.Skills?.Persuasion?.Proficiency == true ? "Oui" : "Off");
                form.SetField("15", playerCharacter?.Skills?.Religion?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Religion - Maitrise", playerCharacter?.Skills?.Religion?.Proficiency == true ? "Oui" : "Off");
                form.SetField("16", playerCharacter?.Skills?.Performance?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Représentation - Maitrise", playerCharacter?.Skills?.Performance?.Proficiency == true ? "Oui" : "Off");
                form.SetField("17", playerCharacter?.Skills?.Deception?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Supercherie - Maitrise", playerCharacter?.Skills?.Deception?.Proficiency == true ? "Oui" : "Off");
                form.SetField("18", playerCharacter?.Skills?.Survival?.Mod.ToString("+0;-#") ?? string.Empty);
                form.SetField("Survie - Maitrise", playerCharacter?.Skills?.Survival?.Proficiency == true ? "Oui" : "Off");


                
                var imageStream = await FileSystem.OpenAppPackageFileAsync("selmays.png"); 

                PushbuttonField ad = form.GetNewPushbuttonFromField("Portrait");
                ad.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                ad.ProportionalIcon = true;
                ad.Image = iTextSharp.text.Image.GetInstance(imageStream);
                form.ReplacePushbuttonField("Portrait", ad.Field);





                form.SetField("Classe", playerCharacter?.PrimaryClass.Name ?? string.Empty);
                //form.SetField("Spécialisation", playerCharacter?.CharacterName ?? string.Empty);
                form.SetField("Niveau", playerCharacter?.Level.ToString() ?? string.Empty);
                //form.SetField("Points dexpérience", playerCharacter?.CharacterName ?? string.Empty);
                form.SetField("Origine", playerCharacter?.Origin.Name ?? string.Empty);
                //form.SetField("Peuple", playerCharacter?.CharacterName ?? string.Empty);
                //form.SetField("Sociale", playerCharacter?.CharacterName ?? string.Empty);
                //form.SetField("Morale", playerCharacter?.CharacterName ?? string.Empty);
                //form.SetField("Historique", playerCharacter?.Background.Name ?? string.Empty);
                //form.SetField("Trait de personnalité", playerCharacter?.CharacterName ?? string.Empty);
                //form.SetField("Idéal", playerCharacter?.CharacterName ?? string.Empty);
                //form.SetField("Lien", playerCharacter?.CharacterName ?? string.Empty);
                //form.SetField("Défaut", playerCharacter?.CharacterName ?? string.Empty);
                
                //form.SetField("Niveau", "1");
                //form.SetField("Race", SelectedPlayerCharacter?.Race?.Name ?? string.Empty);
                //form.SetField("Classe", SelectedPlayerCharacter?.Class?.Name ?? string.Empty);
                //form.SetField("Alignement", SelectedPlayerCharacter?.Alignment?.Name ?? string.Empty);
                //form.SetField("Historique", SelectedPlayerCharacter?.Background?.Background?.Name ?? string.Empty);
                //form.SetField("Trait de personnalité",
                //    (SelectedPlayerCharacter.Background.PersonalityTrait ?? string.Empty) + "\n\n" +
                //    (SelectedPlayerCharacter.Background.PersonalityIdeal ?? string.Empty) + "\n\n" +
                //    (SelectedPlayerCharacter.Background.PersonalityLink ?? string.Empty) + "\n\n" +
                //    (SelectedPlayerCharacter.Background.PersonalityDefect ?? string.Empty)
                //    );
                //form.SetField("For Valeur", SelectedPlayerCharacter?.Abilities?.Strength?.Value?.ToString());
                //form.SetField("For MOD", SelectedPlayerCharacter?.Abilities?.Strength?.ModString);
                //form.SetField("Dex Valeur", SelectedPlayerCharacter?.Abilities?.Dexterity?.Value?.ToString());
                //form.SetField("Dex MOD", SelectedPlayerCharacter?.Abilities?.Dexterity?.ModString);
                //form.SetField("Con Valeur", SelectedPlayerCharacter?.Abilities?.Constitution?.Value?.ToString());
                //form.SetField("Con MOD", SelectedPlayerCharacter?.Abilities?.Constitution?.ModString);
                //form.SetField("Int Valeur", SelectedPlayerCharacter?.Abilities?.Intelligence?.Value?.ToString());
                //form.SetField("Int MOD", SelectedPlayerCharacter?.Abilities?.Intelligence?.ModString);
                //form.SetField("Sag Valeur", SelectedPlayerCharacter?.Abilities?.Wisdom?.Value?.ToString());
                //form.SetField("Sag MOD", SelectedPlayerCharacter?.Abilities?.Wisdom?.ModString);
                //form.SetField("Cha Valeur", SelectedPlayerCharacter?.Abilities?.Charisma?.Value?.ToString());
                //form.SetField("Cha MOD", SelectedPlayerCharacter?.Abilities?.Charisma?.ModString);
            }
            finally
            {
                stamper?.Close();
            }
        }
        finally
        {
            reader?.Close();
        }
    }

    public async Task OpenPdfAsync(string filename)
    {
        //var filepath = Path.Combine(BasePdfDirectory, filename);
        //await DependencyService.Get<INativeAPI>().LaunchFileAsync("hophop", "coucou", filepath);
        await Launcher.Default.OpenAsync(new OpenFileRequest("Feuille de personnage", new ReadOnlyFile(filename)));
    }

    public AsyncRelayCommand<PlayerCharacter> SavePlayerCharacterCommand => new AsyncRelayCommand<PlayerCharacter>(ExecuteSavePlayerCharacterCommandAsync);
    private async Task ExecuteSavePlayerCharacterCommandAsync(PlayerCharacter pc)
    {
        var jsonString = JsonSerializer.Serialize(pc);
        var jsonpc = JsonSerializer.Deserialize<PlayerCharacter>(jsonString);

        var yaml = Serializers.ClassToYaml(pc);

        var now = DateTime.Now;
        var fileName = string.Format(pc.CharacterName + "_{0:yyyyMMddHHmmss}", now);
        await SaveStringToFile(yaml, fileName + ".yaml");
        await SaveStringToFile(jsonString, fileName + ".json");


        //var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
        //using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
        //{
        //    using (var sr = new StreamWriter(stream))
        //    {
        //        await sr.WriteAsync(yaml);
        //    }
        //}

        var newpc = Serializers.YamlToClass<PlayerCharacter>(yaml);

    }

    private async Task SaveStringToFile(string text, string filename)
    {
        var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, filename);
        using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
        {
            using (var sr = new StreamWriter(stream))
            {
                await sr.WriteAsync(text);
            }
        }
    }
}