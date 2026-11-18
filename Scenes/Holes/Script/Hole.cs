using System;
using Godot;
using Whack.Moles.Script;

namespace Whack.Scenes.Holes.Script;

public partial class Hole : Node
{
    [Export] private Node2D _spawnPoint;
    [Export] private MoleResource _moleResource;

    public override void _Ready()
    {
        base._Ready();
        CreateRandomMole();
    }

    public void CreateRandomMole()
    {
        var randomMole = GD.RandRange(0, Enum.GetNames(typeof(MoleType)).Length - 1);
        var moleType = (MoleType)randomMole;

        var moleScene = _moleResource.ConcreteMole[moleType].Instantiate();
        AddChild(moleScene);
        moleScene.TreeExited += HandleMoleDied;
    }

    private void HandleMoleDied()
    {
        CreateRandomMole();
    }
}