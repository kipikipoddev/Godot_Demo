using Godot;

namespace Resources;

[GlobalClass]
public partial class Action_Resource : Named_Resource
{
	[Export(PropertyHint.Range, "1,10")]
	public int Cooldown;
}
