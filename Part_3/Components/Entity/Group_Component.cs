using Core;

namespace Components_Namespace;

public record Group_Component(int Group) : Component
{

}

public static class Group_Extensions
{
    public static int Group(this Components components)
    {
        return components.Get<Group_Component>().Group;
    }
}