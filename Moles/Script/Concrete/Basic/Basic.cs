using Godot;

namespace Whack.Moles.Script.Concrete.Basic;

public partial class Basic : AbstractMole
{
    public override void _Ready()
    {
        base._Ready();
        Type = MoleType.Basic;
    }

    protected override void OnHit(Node viewport, InputEvent evt, int shapeId)
    {
        if (Input.IsActionPressed("mouse_left"))
            Die();
    }
}