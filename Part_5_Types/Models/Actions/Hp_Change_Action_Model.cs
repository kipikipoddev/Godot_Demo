using Interfaces;
using Resources;

namespace Models;

public abstract class Hp_Change_Action_Model : Action_Model, IAmount_Model
{
    public int Amount { get; }
    public bool Is_Positive { get; }

    public Hp_Change_Action_Model(Action_Resource resource, int amount, bool on_friendly, bool on_live_target)
        : base(resource, on_friendly, on_live_target)
    {
        Amount = amount;
        Is_Positive = on_friendly;
    }
}