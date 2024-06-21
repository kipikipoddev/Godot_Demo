namespace Interfaces;

public interface IEntity_Model : IName_Model
{
    IValue_Model Hp { get; }
    int Armor { get; }
    IValue_Model Shield { get; }
    IAction_Model[] Actions { get; }

    bool Is_Alive => !Hp.Is_Min;
}