using Godot;

namespace Whack.Moles.Script;

[GlobalClass]
public partial class MoleResource : Resource
{
    [Export] public PackedScene Scene;
    [Export] public float Weight;

    public MoleResource() : this(new PackedScene(), 0f)
    {
    }

    public MoleResource(PackedScene newScene, float newWeight)
    {
        Scene = newScene;
        Weight = newWeight;
    }
}