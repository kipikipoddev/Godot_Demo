using Interfaces;
using Resources;

namespace Models;

public abstract class Hp_Change_Action_Model : Action_Model, IAmount_Model
{
    public int Amount { get; }
    public bool Is_Positive { get; }

    public Hp_Change_Action_Model(Action_Resource resource, int amount, bool is_positive)
        : base(resource)
    {
        Amount = amount;
        Is_Positive = is_positive;
    }
}