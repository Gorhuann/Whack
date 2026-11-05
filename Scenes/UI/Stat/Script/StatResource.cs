using Godot;

namespace Whack.Scenes.UI.Stat.Script;

[GlobalClass]
public partial class StatResource : Resource
{
    [Export] public float Money { get; set; } 
    [Export] public int MoleKilled { get; set; }
    [Export] public int BestCombo { get; set; }
    [Export] public int LastCombo { get; set; }
    [Export] public float BaseMultiplier { get; set; }
    [Export] public float HammerMultiplier { get; set; }
    [Export] public float MoleMultiplier { get; set; }
    
    public StatResource() : this(0, 0, 0, 0, 0, 0, 0) {}

    public StatResource(int money, int moleKilled, int bestCombo, int lastCombo, float baseMultiplier, float hammerMultiplier, float moleMultiplier)
    {
        Money = money;
        MoleKilled = moleKilled;
        BestCombo = bestCombo;
        LastCombo = lastCombo;
        BaseMultiplier = baseMultiplier;
        HammerMultiplier = hammerMultiplier;
        MoleMultiplier = moleMultiplier;
    }
}