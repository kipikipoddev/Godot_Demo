using Godot;

namespace Resources;

[GlobalClass]
public partial class Hot_Resource : Heal_Resource
{
	[Export(PropertyHint.Range, "1,10")]
	public int Time_Between;

	[Export(PropertyHint.Range, "2,10")]
	public int Times;
}
