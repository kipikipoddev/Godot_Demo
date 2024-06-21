namespace Interfaces;

public interface IAction_Model : IName_Model
{
    IEntity_Model Owner { get; set; }
    ITimer_Model Cooldown { get; }

    bool Can(IEntity_Model target);
    void Do(IEntity_Model target);
}