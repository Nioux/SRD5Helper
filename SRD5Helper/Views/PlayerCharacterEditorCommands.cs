using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using SRD5Helper.DataModels;
using SRD5Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRD5Helper.Views;

public class PlayerCharacterEditorCommands
{
    PlayerCharacter PC => Ioc.Default.GetRequiredService<Settings>().CurrentPlayerCharacter;

    public AsyncRelayCommand<OriginDatum> SetOriginCommand => new AsyncRelayCommand<OriginDatum>(ExecuteSetOriginCommandAsync);
    protected async Task ExecuteSetOriginCommandAsync(OriginDatum datum)
    {
        PC.Origin = PC.Factory.CreateOrigin(id: datum.ID);

        //await App.Current.MainPage.DisplayAlert("test", "test", "fermer");
    }

}
