namespace Interfaces;

public interface IAction_Model : IName_Model, IType_Model
{
    int Cast_Time { get;}
    IEntity_Model Owner { get; set; }
    ITimer_Model Cooldown { get; }
    bool On_Friendly { get; }
    bool On_Live_Target { get; }

    bool Can(IEntity_Model target);
    void Start(IEntity_Model target);
}