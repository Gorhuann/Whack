using Godot;

namespace Whack.Managers;

public partial class NavigationManager : Node
{
    public static NavigationManager instance;

    public Node rootScene { get; set; }
    public string previousScene {get; private set;}
    public Node currentScene {get; private set;}
    private Vector2 _previousPosition;
    
    public override void _Ready()
    {
        base._Ready();
        instance = this;
    }

    public void GoToScene(PackedScene scene, Vector2 previousPosition = default)
    {
        _previousPosition = previousPosition;
        instance.CallDeferred(MethodName.NavigateToScene, scene.GetPath());
    }

    private void NavigateToScene(string path)
    {
        previousScene = currentScene?.SceneFilePath;
        currentScene?.QueueFree();
        var nextScene = GD.Load<PackedScene>(path);
        currentScene = nextScene.Instantiate();
        rootScene.AddChild(currentScene);
    }

    public void NavigateToPrevious()
    {
        NavigateToScene(previousScene);
    }
    

    public void NavigateToRoot() => GetTree().ChangeSceneToNode(rootScene);
}