using Core;

namespace Components_Namespace;

public record Group_Component : Component
{
    public int Group { get; set; }
    public Group_Component(int group)
    {
        Group = group;
    }
}

public static class Group_Extensions
{
    public static int Group(this Components components)
    {
        return components.Get<Group_Component>()?.Group ?? 0;
    }
}