using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace Whack.Moles.Script;

[GlobalClass]
public partial class MoleList : Resource
{
    [Export] public Array<MoleResource> ConcreteMole;

    public MoleList() : this(new Array<MoleResource>())
    {
    }

    public MoleList(Array<MoleResource> newConcreteMole)
    {
        ConcreteMole = newConcreteMole;
    }
}