using Godot;

namespace Resources;

[GlobalClass]
public partial class Entity_Resource : Named_Resource
{
    [Export]
    public int Hp;

    [Export]
    public Attack_Resource Attack;
}
