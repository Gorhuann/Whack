using System;
using System.Security.Cryptography;
using Godot;
using Whack.Managers;
using Whack.Scenes.Bootstrap.Camera;

namespace Whack.Moles.Script;

public partial class Mole : Area2D
{
    [Export] private Node2D SpawnPoint { get; set; }
    [Export] private Node2D EndPoint { get; set; }

    private StatManager StatManager => StatManager.Instance;
    
    private bool _isDying;
    private Tween _dyingTween;
    private Tween _ascendingTween;

    [Export] public PackedScene HitEffectScene { get; set; }
    [Export] public Scenes.Bootstrap.Camera.MainCamera Camera { get; set; }
    
    public override void _Ready(double delta)
    {
        Position = SpawnPoint.Position;
        var startingTween = CreateTween();
        startingTween.TweenInterval(GD.RandRange(0.0, 5.0));
        startingTween.TweenCallback(Callable.From(Ascend));
    }

    private void OnHit(Node viewport, InputEvent evt, int shapeId)
    {
        if (Input.IsActionPressed("mouse_left"))
            Die();
    }

    private void Ascend()
    {
        _isDying = false;
        _ascendingTween?.Kill();
        _ascendingTween = CreateTween();
        _ascendingTween.TweenProperty(this, "position", EndPoint.Position, 1.5).SetTrans(Tween.TransitionType.Elastic).SetEase(Tween.EaseType.Out);
    }

    private void Die()
    {
        if (_isDying) return;
        _isDying = true;
        this.AddChild(HitEffectScene.Instantiate());
        (GetTree().GetFirstNodeInGroup("Camera") as MainCamera)?.Shake();

        StatManager.IncreaseMoney();
        StatManager.IncreaseMoleKilled();        
        
        _ascendingTween?.Kill();
        _dyingTween?.Kill();
        _dyingTween = CreateTween();
        _dyingTween.TweenProperty(this, "position", SpawnPoint.Position, 1).SetTrans(Tween.TransitionType.Bounce).SetEase(Tween.EaseType.Out);
        _dyingTween.TweenInterval(GD.RandRange(0.0, 5.0));
        _dyingTween.TweenCallback(Callable.From(Ascend));
    }
}