using Godot;

namespace Whack.Moles.Script;

public partial class Mole : Node2D
{
    public bool _isAlive;
    public bool _isAscending = true;
    public bool _isDying = false;

    [Export] private Node2D SpawnPoint { get; set; }
    [Export] private Node2D EndPoint { get; set; }
    
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!_isAscending) return;
        
        SetPosition(new Vector2(Position.X, float.Lerp(Position.Y, EndPoint.Position.Y, (float)delta / 0.4f)));
    }
}