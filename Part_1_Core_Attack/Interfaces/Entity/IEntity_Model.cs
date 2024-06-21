namespace Interfaces;

public interface IEntity_Model : IName_Model
{
    IValue_Model Hp { get; }
    IAction_Model Action { get; }

    bool Is_Alive => !Hp.Is_Min;
}