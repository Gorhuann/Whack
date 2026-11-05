using Godot;

namespace Whack.Scenes.Bootstrap.Camera;

public partial class MainCamera : Camera2D
{
	private Tween _tween;

	public void Shake(float strength = 6f, float duration = 0.15f)
	{
		_tween?.Kill();
		_tween = CreateTween();
		
		_tween.TweenMethod(Callable.From<float>(t =>
		{
			float s = strength * t;
			Offset = new Vector2(
				(float)GD.RandRange(-s, s),
				(float)GD.RandRange(-s, s)
			);
		}), 1f, 0f, duration);

		_tween.TweenCallback(Callable.From(() => Offset = Vector2.Zero));
	}

}