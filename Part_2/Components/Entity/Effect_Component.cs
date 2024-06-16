using Core;

namespace Components_Namespace;

public record Effect_Component(Command Action, int Times) : Component
{
    public int Happend { get; set; }
}

public static class Effect_Extensions
{
    public static Effect_Component Effect(this Components components)
    {
        return components.Get<Effect_Component>();
    }
}