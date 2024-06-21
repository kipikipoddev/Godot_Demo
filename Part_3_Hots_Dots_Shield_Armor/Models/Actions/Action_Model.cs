using Commands;
using Interfaces;
using Requests;
using Resources;

namespace Models;

public abstract class Action_Model : Name_Model, IAction_Model
{
    public ITimer_Model Cooldown { get; }
    public IEntity_Model Owner { get; set; }

    public Action_Model(Action_Resource resource)
        : base(resource)
    {
        Cooldown = new Timer_Model(resource.Cooldown);
    }

    public bool Can(IEntity_Model target)
    {
        return new Can_Action_Request(this, target).Result;
    }

    public void Do(IEntity_Model target)
    {
        new Do_Action_Command(this, target);
    }
}