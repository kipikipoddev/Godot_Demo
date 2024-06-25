using Interfaces;
using Resources;

namespace Models;

public class Amount_Model : IAmount_Model
{
    public int Amount { get; }
    public bool Is_Positive { get; }
    public Type_Resource Type { get; }

    public Amount_Model(int amount, Type_Resource type)
    {
        Amount = amount;
        Is_Positive = Amount > 0;
        if (!Is_Positive)
            Amount = -Amount;
        Type = type;
    }
}