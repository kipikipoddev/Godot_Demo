using Godot;

namespace Resources;

[GlobalClass]
public partial class Armor_Resource : Resource
{
    [Export(PropertyHint.Range, "1,10")]
    public int Amount;

    [Export]
    public Type_Resource Type;
}
