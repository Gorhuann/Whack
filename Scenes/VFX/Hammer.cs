using Godot;
using System;

public partial class Hammer : Node2D
{
	[Export] public float AnimBaseAngle = 0f;
	[Export] public float AnimHitAngle = 45f;
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

	private void Hit()
	{
		_tween?.Kill();

		_tween = CreateTween();
		_tween.TweenProperty(this, "Rotation", AnimHitAngle, AnimSpeed).SetTrans(Tween.TransitionType.Quad).SetEase(Tween.EaseType.In);
		_tween.TweenProperty(this, "rotation", AnimBaseAngle, AnimRecoverSpeed).SetTrans(Tween.TransitionType.Back).SetEase(Tween.EaseType.Out);
	}
}
