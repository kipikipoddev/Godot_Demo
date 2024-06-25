using Godot;

namespace Resources;

[GlobalClass]
public partial class Revive_Resource : Action_Resource
{
	[Export(PropertyHint.Range, "1,10")]
	public int To_Hp;
}
