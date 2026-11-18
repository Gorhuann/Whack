using Godot;
using Godot.Collections;

namespace Whack.Moles.Script;

[GlobalClass]
public partial class MoleResource : Resource
{
    [Export] public Dictionary<MoleType, PackedScene> ConcreteMole;
    
    public MoleResource() : this(new Dictionary<MoleType, PackedScene>()) { }

    public MoleResource(Dictionary<MoleType, PackedScene> newConcreteMole)
    {
        ConcreteMole = newConcreteMole;
    }
}