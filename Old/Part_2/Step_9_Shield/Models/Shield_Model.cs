using Commands;
using Interfaces;
using Messages;
using Resources;

namespace Models;

public class Shield_Model : Action_Model
{
    public int Amount { get; }

    public Shield_Model(IHp_Model owner, Shield_Resource resource)
    : base(owner, resource)
    {
        Amount = resource.Amount;
    }

    public override void Do(IHp_Model target)
    {
        new Shield_Command(this, target);
    }

    public override bool Can_Do(IHp_Model target)
    {
        return new Can_Heal_Request(this, target).Result;
    }
}