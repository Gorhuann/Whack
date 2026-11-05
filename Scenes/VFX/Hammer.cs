using Godot;
using System;

namespace Whack.Scenes.VFX;

public partial class Hammer : Node2D
{
	[Export] public float AnimBaseAngle = 0f;
	[Export] public float AnimHitAngle = -90f;
	[Export] public float AnimSpeed = 0.05f;
	[Export] public float AnimRecoverSpeed = 0.15f;
	
	private Tween _tween;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Hidden;
		Rotation = AnimBaseAngle;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition = GetGlobalMousePosition();
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (Input.IsActionPressed("mouse_left"))
		{
			Hit();
		}
	}

	private void Hit()
	{
		_tween?.Kill();

		_tween = CreateTween();
		_tween.TweenProperty(this, "rotation_degrees", AnimHitAngle, AnimSpeed).SetTrans(Tween.TransitionType.Quad).SetEase(Tween.EaseType.In);
		_tween.TweenProperty(this, "rotation_degrees", AnimBaseAngle, AnimRecoverSpeed).SetTrans(Tween.TransitionType.Back).SetEase(Tween.EaseType.Out);
	}
}
