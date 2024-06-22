using Godot;

namespace Resources;

[GlobalClass]
public partial class Named_Resource : Resource
{
	private string name;

	public string Name
	{
		get
		{
			if (name == null)
			{
				var slash = ResourcePath.LastIndexOf('/') + 1;
				var dot = ResourcePath.LastIndexOf('.');
				name = ResourcePath.Substring(slash, dot - slash);
				name = name.Replace("_", " ");
			}
			return name;
		}
	}
}
