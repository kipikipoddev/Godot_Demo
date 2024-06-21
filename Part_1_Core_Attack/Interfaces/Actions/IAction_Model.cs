namespace Interfaces;

public interface IAction_Model : IName_Model
{
    IEntity_Model Owner { get; set; }

    bool Can(IEntity_Model target);
    void Do(IEntity_Model target);
}