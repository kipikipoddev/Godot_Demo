using Commands;
using Core;
using Interfaces;
using Resources;

namespace Models;

public class Attack_Action_Model : Action_Model, IAmount_Model
{
    public int Amount { get; }

    public Attack_Action_Model(Attack_Resource resource)
        : base(resource)
    {
        Amount = resource.Damage;
    }

    public override Command Do(IHp_Model target)
    {
        return new Attack_Command(this, target);
    }
}