using Commands;
using Interfaces;
using Messages;
using Resources;

namespace Models;

public class Heal_Model : Action_Model
{
    public int Heal { get; }

    public Heal_Model(IHp_Model owner, Heal_Resource resource)
    : base(owner, resource)
    {
        Heal = resource.Heal;
    }

    public override void Do(IHp_Model target)
    {
        new Heal_Command(this, target);
    }

    public override bool Can_Do(IHp_Model target)
    {
        return new Can_Heal_Request(this, target).Result;
    }
}