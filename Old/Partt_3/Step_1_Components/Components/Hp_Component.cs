using Core;

namespace Components_Namespace;

public record Hp_Component : Component
{
    public Ranged_Value<int> Hp { get; set; }

    public Hp_Component(int hp)
    {
        Hp = new(hp, 0, hp);
    }
}

public static class Components_Hp_Extension
{
    public static Ranged_Value<int> Hp(this Components components)
    {
        return components.Get_Or_Defualt<Hp_Component>()?.Hp;
    }
}