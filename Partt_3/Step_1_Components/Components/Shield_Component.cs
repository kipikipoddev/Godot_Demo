using Core;

namespace Components_Namespace;

public class Shield_Component : Component
{
    public Ranged_Value<int> Shield { get; set; }

    public Shield_Component(int amount)
    {
        Shield = new(amount, 0, amount);
    }
}