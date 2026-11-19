using Godot;
using Whack.Managers;

namespace Whack.Moles.Script;

public abstract partial class AbstractMole : Area2D
{
    private StatManager StatManager => StatManager.Instance;
    private CameraManager CameraManager => CameraManager.Instance;

    private bool _isDying;
    private Tween _dyingTween;
    private Tween _ascendingTween;

    private Vector2 _startPosition;
    private float _jumpDistance = 175f;

    protected MoleType Type;

    [Export] public PackedScene HitEffectScene { get; set; }
    [Export] public CollisionShape2D CollisionShape { get; set; }

    protected abstract void OnHit(Node viewport, InputEvent evt, int shapeId);

    public override void _Ready()
    {
        _startPosition = Position;
        CollisionShape.Disabled = true;
        var startingTween = CreateTween();
        startingTween.TweenInterval(GD.RandRange(0.0, 5.0));
        startingTween.TweenCallback(Callable.From(Ascend));
    }

    private void Ascend()
    {
        _isDying = false;
        _ascendingTween?.Kill();
        _ascendingTween = CreateTween();
        _ascendingTween.TweenProperty(this, "position", new Vector2(_startPosition.X, _startPosition.Y - _jumpDistance), 1.5).SetTrans(Tween.TransitionType.Elastic).SetEase(Tween.EaseType.Out);

        var enableHitTween = CreateTween();
        enableHitTween.TweenInterval(1);
        enableHitTween.TweenCallback(Callable.From(ToggleCollision));
    }

    private void ToggleCollision() => CollisionShape.Disabled = false;

    protected void Die()
    {
        if (_isDying) return;
        _isDying = true;
        this.AddChild(HitEffectScene.Instantiate());

        CameraManager.Shake();
        StatManager.IncreaseMoney();
        StatManager.IncreaseMoleKilled();

        _ascendingTween?.Kill();
        _dyingTween?.Kill();
        _dyingTween = CreateTween();
        _dyingTween.TweenProperty(this, "position", new Vector2(_startPosition.X, _startPosition.Y + _jumpDistance), 1).SetTrans(Tween.TransitionType.Bounce).SetEase(Tween.EaseType.Out);
        _dyingTween.TweenInterval(GD.RandRange(0.0, 5.0));
        _dyingTween.TweenCallback(Callable.From(QueueFree));
    }
}