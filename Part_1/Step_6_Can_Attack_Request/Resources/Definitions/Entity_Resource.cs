using Godot;

namespace Resources;

[GlobalClass]
public partial class Entity_Resource : Resource
{
    [Export]
    public int Hp;

    [Export]
    public int Damage;
}
