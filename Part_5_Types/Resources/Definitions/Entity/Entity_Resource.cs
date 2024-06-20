using Godot;

namespace Resources;

[GlobalClass]
public partial class Entity_Resource : Named_Resource
{
    [Export(PropertyHint.Range, "1,10")]
    public int Hp;

    [Export]
    public Armor_Resource[] Armor;

    [Export]
    public Action_Resource[] Actions;
}
