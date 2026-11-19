using System;
using Godot;
using Whack.Moles.Script;

namespace Whack.Scenes.Holes.Script;

public partial class Hole : Node
{
    [Export] private Node2D _spawnPoint;
    [Export] private MoleResource _moleResource;

    private Node _moleScene;

    public override void _Ready()
    {
        base._Ready();
        CreateRandomMole();
    }

    public void CreateRandomMole()
    {
        var randomMole = GD.RandRange(0, Enum.GetNames(typeof(MoleType)).Length - 1);
        var moleType = (MoleType)randomMole;

        _moleScene = _moleResource.ConcreteMole[moleType].Instantiate();
        AddChild(_moleScene);
        MoveChild(_moleScene, 1);
        _moleScene.TreeExited += HandleMoleDied;
    }

    private void HandleMoleDied()
    {
        _moleScene.TreeExited -= HandleMoleDied;
        _moleScene.QueueFree();
        CreateRandomMole();
    }
}