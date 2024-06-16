using Core;
using Interfaces;
using Requests;
using Resources;

namespace Models;

public abstract class Action_Model : IAction_Model
{
    public string Name { get; }

    public ITimer_Model Coolown { get; }

    public Action_Model(Action_Resource resource)
    {
        Name = resource.Name;
        Coolown = new Timer_Model(resource.Cooldown);
    }

    public bool Can(IHp_Model target)
    {
        return new Can_Action_Request(this, target).Result;
    }

    public abstract Command Do(IHp_Model target);
}