using Godot;
using Godot.Collections;
using Whack.Scenes.Holes.Script;

namespace Whack.Scenes.MoleMachine;

public partial class MoleMachine : Node
{
    [Export] public Dictionary<int, Hole> Holes { get; set; } = new();
}