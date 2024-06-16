using Core;

namespace Components_Namespace;

public record Is_Positive_Component(bool Is_Positive) : Component
{
}

public static class Is_Positive_Extensions
{
    public static bool Is_Positive(this Components components)
    {
        return components.Get<Is_Positive_Component>().Is_Positive;
    }
}