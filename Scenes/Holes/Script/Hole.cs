using System.Collections.Generic;
using Godot;
using Whack.Moles.Script;

namespace Whack.Scenes.Holes.Script;

public partial class Hole : Node
{
    [Export] private Node2D _spawnPoint;
    [Export] private MoleList _moleList;

    private RandomNumberGenerator _randomNumberGenerator;
    private readonly List<float> _moleWeights = [];
    public AbstractMole Mole { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        _randomNumberGenerator = new RandomNumberGenerator();
        foreach (var concreteMole in _moleList.ConcreteMole)
        {
            _moleWeights.Add(concreteMole.Weight);
        }

        CreateRandomMole();
    }

    private void CreateRandomMole()
    {
        var array = _moleWeights.ToArray();
        var index = (int)_randomNumberGenerator.RandWeighted(array);

        Mole = _moleList.ConcreteMole[index].Scene.Instantiate<AbstractMole>();
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