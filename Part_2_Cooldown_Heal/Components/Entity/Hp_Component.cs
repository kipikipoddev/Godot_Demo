using Core;

namespace Components_Namespace;

public record Hp_Component : Component
{
    public int Value { get; set; }
    public int Max { get; set; }
    public bool Is_Alive => Value > 0;

    public Hp_Component(int hp)
    {
        Value = hp;
        Max = hp;
    }
}

public static class Hp_Extensions
{
    public static Hp_Component Hp(this Components components)
    {
        return components.Get<Hp_Component>();
    }
}