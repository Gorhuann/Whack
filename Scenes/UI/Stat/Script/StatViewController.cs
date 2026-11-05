using Godot;
using Whack.Managers;

namespace Whack.Scenes.UI.Stat.Script;

public partial class StatViewController : Node
{
    [Export] private Label Money { get; set; }
    [Export] private Label MoleKilled { get; set; }
    [Export] private Label BestCombo { get; set; }
    [Export] private Label LastCombo { get; set; }
    [Export] private Label BaseMultiplier { get; set; }
    [Export] private Label HammerMultiplier { get; set; }
    [Export] private Label MoleMultiplier { get; set; }

    private StatManager StatManager => StatManager.Instance;
    
    public override void _Ready()
    {
        base._Ready();
        
        Money.SetText(StatManager.StatResource.Money.ToString());
        MoleKilled.SetText(StatManager.StatResource.MoleKilled.ToString());
        BestCombo.SetText(StatManager.StatResource.BestCombo.ToString());
        LastCombo.SetText(StatManager.StatResource.LastCombo.ToString());
        BaseMultiplier.SetText(StatManager.StatResource.BaseMultiplier.ToString());
        HammerMultiplier.SetText(StatManager.StatResource.HammerMultiplier.ToString());
        MoleMultiplier.SetText(StatManager.StatResource.MoleMultiplier.ToString());
        
        StatManager.OnMoneyChanged += HandleMoneyChanged;
        StatManager.OnMoleKilledChanged += HandleMoleKilledChanged;
    }

    private void HandleMoneyChanged() => Money.SetText(StatManager.StatResource.Money.ToString());
    
    private void HandleMoleKilledChanged() => MoleKilled.SetText(StatManager.StatResource.MoleKilled.ToString());
}