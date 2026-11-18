using Godot;

namespace Whack.Moles.Script.Concrete.Knight;

public partial class Knight : AbstractMole
{
    private bool _isShieldOn = true;
    
    protected override void OnHit(Node viewport, InputEvent evt, int shapeId)
    {
        if (!Input.IsActionPressed("mouse_left")) return;
        
        if(_isShieldOn)
            _isShieldOn = !_isShieldOn;
        else
        {
            _isShieldOn = true;
            Die();
        }
    }
}