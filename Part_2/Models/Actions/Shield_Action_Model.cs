using Commands;
using Core;
using Interfaces;
using Resources;

namespace Models;

public class Shield_Action_Model : Action_Model, IAmount_Model
{
    public int Amount { get; }

    public Shield_Action_Model(Heal_Resource resource)
        : base(resource)
    {
        Amount = resource.Heal;
    }

    public override Command Do(IHp_Model target)
    {
        return new Shield_Action_Command(this, target);
    }
}