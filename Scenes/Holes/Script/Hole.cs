using System;
using Godot;
using Whack.Moles.Script;

namespace Whack.Scenes.Holes.Script;

public partial class Hole : Node
{
    [Export] private Node2D _spawnPoint;
    [Export] private MoleResource _moleResource;

    public AbstractMole Mole { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        CreateRandomMole();
    }

    private void CreateRandomMole()
    {
        var randomMole = GD.RandRange(0, Enum.GetNames(typeof(MoleType)).Length - 1);
        var moleType = (MoleType)randomMole;

        Mole = _moleResource.ConcreteMole[moleType].Instantiate<AbstractMole>();
        AddChild(Mole);
        MoveChild(Mole, 1);
        Mole.TreeExited += HandleMoleDied;
    }

    private void HandleMoleDied()
    {
        Mole.TreeExited -= HandleMoleDied;
        Mole.QueueFree();
        CreateRandomMole();
    }
}