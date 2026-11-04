using Godot;
using Whack.Managers;

namespace Whack.Scenes.Bootstrap;

public partial class Bootstrap : Node2D
{
    [Export]
    public Node rootNode { get; set; }

    [Export]
    public PackedScene starterScene { get; set; }
    
    public override void _Ready()
    {
        base._Ready();
        NavigationManager.instance.rootScene = rootNode;
        NavigationManager.instance.GoToScene(starterScene);
    }
}