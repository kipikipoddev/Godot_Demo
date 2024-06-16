using Commands;
using Core;
using Interfaces;
using Resources;

namespace Models;

public class Heal_Action_Model : Action_Model, IAmount_Model
{
    public int Amount { get; }

    public Heal_Action_Model(Heal_Resource resource)
        : base(resource)
    {
        Amount = resource.Heal;
    }

    public override Command Do(IHp_Model target)
    {
        return new Heal_Command(this, target);
    }
}