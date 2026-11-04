using System;
using Godot;

namespace Whack.Moles.Script;

public partial class Mole : Area2D
{
    public bool _isAscending = true;
    public bool _isDying = false;

    [Export] private Node2D SpawnPoint { get; set; }
    [Export] private Node2D EndPoint { get; set; }
    
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (_isDying)
        {
            _isAscending = false;
            SetPosition(new Vector2(Position.X, float.Lerp(Position.Y, SpawnPoint.Position.Y, (float)delta / 0.4f)));
        }
        if (_isAscending)
        {
            SetPosition(new Vector2(Position.X, float.Lerp(Position.Y, EndPoint.Position.Y, (float)delta / 0.4f)));
            _isAscending = Position.Y >= EndPoint.Position.Y;
        }
    }

    private void OnHit(Node viewport, InputEvent evt, int shapeId)
    {
        if (Input.IsActionPressed("mouse_left"))
        {
            if (_isDying) return;
            _isDying = true;
        }
    }
}