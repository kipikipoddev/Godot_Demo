using Core;

namespace Components_Namespace;

public class Amount_Component : Component
{
    public int Amount { get; }

    public Amount_Component(int amount)
    {
        Amount = amount;
    }
}