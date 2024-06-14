using Core;

namespace Components_Namespace;

public class Armor_Component : Component
{
    public int Armor { get; set; }

    public Armor_Component(int armor = 0)
    {
        Armor = armor;
    }
}