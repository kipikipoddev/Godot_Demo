using Commands;
using Interfaces;
using Requests;
using Resources;

namespace Models;

public abstract class Action_Model : Name_Model, IAction_Model
{
    public int Cast_Time { get; }
    public ITimer_Model Cooldown { get; }
    public bool On_Friendly { get; }
    public bool On_Live_Target { get; }
    public IEntity_Model Owner { get; set; }
    public Type_Resource Type { get; }

    public Action_Model(Action_Resource resource, bool on_friendly, bool on_live_target)
        : base(resource)
    {
        Cast_Time = resource.Cast;
        Cooldown = new Timer_Model(resource.Cooldown);
        On_Friendly = on_friendly;
        On_Live_Target = on_live_target;
        Type = resource.Type;
    }

    public bool Can(IEntity_Model target)
    {
        return new Can_Action_Request(this, target, true).Result;
    }

    public void Start(IEntity_Model target)
    {
        new Start_Action_Command(this, target);
    }
}