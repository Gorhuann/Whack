using System;
using Godot;
using Whack.Scenes.UI.Stat.Script;

namespace Whack.Managers;

public partial class StatManager : Node
{
    public static StatManager Instance;

    public StatResource StatResource { get; private set; }

    public event Action OnMoneyChanged;
    public event Action OnMoleKilledChanged;
    
    public override void _Ready()
    {
        base._Ready();
        Instance = this;
    }
    public void SetupStatResource(StatResource newStatResource)
    {
        StatResource = newStatResource;
    }

    public void IncreaseMoney()
    {
        StatResource.Money = (float)Math.Round(StatResource.Money + StatResource.BaseMultiplier * StatResource.HammerMultiplier * StatResource.MoleMultiplier, 2);
        OnMoneyChanged?.Invoke();
    }

    public void IncreaseMoleKilled()
    {
        StatResource.MoleKilled++;
        OnMoleKilledChanged?.Invoke();
    }
}