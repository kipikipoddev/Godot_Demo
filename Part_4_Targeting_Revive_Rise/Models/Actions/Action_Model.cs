using Commands;
using Interfaces;
using Requests;
using Resources;

namespace Models;

public abstract class Action_Model : Name_Model, IAction_Model
{
    public ITimer_Model Cooldown { get; }
    public bool On_Friendly { get; }
    public bool On_Live_Target { get; }
    public IEntity_Model Owner { get; set; }

    public Action_Model(Action_Resource resource, bool on_friendly, bool on_live_target)
        : base(resource)
    {
        Cooldown = new Timer_Model(resource.Cooldown);
        On_Friendly = on_friendly;
        On_Live_Target = on_live_target;
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