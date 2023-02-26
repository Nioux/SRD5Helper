using CommunityToolkit.Mvvm.Input;
using SRD5Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRD5Helper.ViewModels;

public class AttackRoll : BaseModel
{
    public Roll Roll { get; init; }
    
    private int _advantage = 0;
    public int Advantage { get => _advantage + SumRules(); set => SetProperty(ref _advantage, value); }

    private int _disadvantage = 0;
    public int Disadvantage { get => _disadvantage + SumRules(); set => SetProperty(ref _disadvantage, value); }
}
