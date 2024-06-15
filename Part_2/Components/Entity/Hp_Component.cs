using Core;

namespace Components_Namespace;

public record Hp_Component : Component
{
    public Ranged_Value<int> Hp { get; }
    public bool Is_Alive => Hp.Not_Min;

    public Hp_Component(int hp)
    {
        Hp = new Ranged_Value<int>(hp, 0, hp);
    }
}

public static class Hp_Extensions
{
    public static Ranged_Value<int> Hp(this Components components)
    {
        return components.Get<Hp_Component>().Hp;
    }
}