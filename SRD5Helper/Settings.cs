using CommunityToolkit.Mvvm.ComponentModel;
using SRD5Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRD5Helper;

[Flags]
public enum UserMode
{
    Beginner = 0,
    Normal = 1,
    Advanced = 2,
    Debug = 3,
}
public class Settings : ObservableObject
{
    public Style GlobalStyles { get; set; }
    private UserMode _userMode;
    public UserMode UserMode { 
        get => _userMode; 
        set => SetProperty(ref _userMode, value); 
    }

    private PlayerCharacter _currentPlayerCharacter = null;
    public PlayerCharacter CurrentPlayerCharacter { get => _currentPlayerCharacter; set => SetProperty(ref _currentPlayerCharacter, value); }

    //public Size ScreenSize => new Size(DeviceDisplay.MainDisplayInfo.Width * DeviceDisplay.MainDisplayInfo.Density, DeviceDisplay.MainDisplayInfo.Height * DeviceDisplay.MainDisplayInfo.Density);

#if WINDOWS
    public Size ScreenSize => new Size(1024, 768);
    public double MainColumnWidth => 400;
#else
    public Size ScreenSize => new Size(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density, DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);

    public double MinScreenRatio => Math.Min(ScreenSize.Width / ScreenSize.Height, ScreenSize.Height / ScreenSize.Width);
    public double MinScreenDimension => Math.Min(ScreenSize.Width, ScreenSize.Height);
    public double MaxScreenDimension => Math.Max(ScreenSize.Width, ScreenSize.Height);
    public double MainColumnWidth => (MinScreenRatio > 0.75 ? MinScreenDimension : MaxScreenDimension / 2) - 30;
#endif
}
