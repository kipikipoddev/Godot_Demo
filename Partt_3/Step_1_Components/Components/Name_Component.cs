using Core;

namespace Components_Namespace;

public class Name_Component : Component
{
    public string Name { get; }

    public Name_Component(string name)
    {
        Name = name;
    }
}