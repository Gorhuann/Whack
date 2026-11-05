using Godot;
using Whack.Managers;
using Whack.Scenes.UI.Stat.Script;

namespace Whack.Scenes.Bootstrap;

public partial class Bootstrap : Node2D
{
    [Export]
    public Node RootNode { get; set; }

    [Export]
    public PackedScene StarterScene { get; set; }
    
    [Export]
    private StatResource StatResource { get; set; }
    
    public override void _Ready()
    {
        base._Ready();
        NavigationManager.instance.rootScene = RootNode;
        NavigationManager.instance.GoToScene(StarterScene);
        StatManager.Instance.SetupStatResource(StatResource);
    }
}