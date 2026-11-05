using System;
using System.Security.Cryptography;
using Godot;
using Whack.Scenes.Bootstrap.Camera;

namespace Whack.Moles.Script;

public partial class Mole : Area2D
{
    [Export] private Node2D SpawnPoint { get; set; }
    [Export] private Node2D EndPoint { get; set; }

    private Tween _dyingTween;
    private Tween _ascendingTween;

    [Export] public PackedScene HitEffectScene { get; set; }
    [Export] public Scenes.Bootstrap.Camera.MainCamera Camera { get; set; }
    
    public override void _Ready(double delta)
    {
        base._Ready();
        Ascend();
    }

    private void Ascend()
    {
        if (_ascendingTween != null) return;
        _ascendingTween = GetTree().CreateTween();
        _ascendingTween.TweenProperty(this, "position", EndPoint.Position, 1.5).SetTrans(Tween.TransitionType.Elastic);
    }

    private void OnHit(Node viewport, InputEvent evt, int shapeId)
    {
        if (Input.IsActionPressed("mouse_left"))
            Die();
    }

    private void Die()
    {
        if (_dyingTween != null) return;
        _dyingTween = GetTree().CreateTween();
        _dyingTween.TweenProperty(this, "position", SpawnPoint.Position, 1).SetTrans(Tween.TransitionType.Bounce);
        {
            if (_isDying) return;
            _isDying = true;
            this.AddChild(HitEffectScene.Instantiate());
            (GetTree().GetFirstNodeInGroup("Camera") as MainCamera)?.Shake();
        }
    }
}