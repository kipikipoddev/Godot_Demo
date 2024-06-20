using Godot;

namespace Resources;

[GlobalClass]
public partial class Type_Resource : Named_Resource
{
    [Export]
    public Type_Resource Parent;

    [Export]
    public Color Color;
}
