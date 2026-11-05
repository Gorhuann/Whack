using Godot;

namespace Whack.Managers;

public partial class CameraManager : Node
{
    public static CameraManager Instance;

    private Camera2D _mainCamera;
    private Tween _shakeTween;
    
    public override void _Ready()
    {
        base._Ready();
        Instance = this;
    }
    
    public void SetupCamera(Camera2D camera)
    {
        _mainCamera = camera;
    }

    public void Shake(float strength = 6f, float duration = 0.15f)
    {
        _shakeTween?.Kill();
        _shakeTween = CreateTween();
		
        _shakeTween.TweenMethod(Callable.From<float>(t =>
        {
            var s = strength * t;
            _mainCamera.Offset = new Vector2(
                (float)GD.RandRange(-s, s),
                (float)GD.RandRange(-s, s)
            );
        }), 1f, 0f, duration);

        _shakeTween.TweenCallback(Callable.From(() => _mainCamera.Offset = Vector2.Zero));
    }
}