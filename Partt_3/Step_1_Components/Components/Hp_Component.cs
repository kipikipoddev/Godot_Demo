using Core;

namespace Components_Namespace;

public class Hp_Component : Component
{
    public Ranged_Value<int> Hp { get; set; }
    public bool Is_alive => Hp.Value > 0;

    public Hp_Component(int hp)
    {
        Hp = new(hp, 0, hp);
    }
}