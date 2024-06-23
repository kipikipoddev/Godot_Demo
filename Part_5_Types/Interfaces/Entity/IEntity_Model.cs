using Resources;

namespace Interfaces;

public interface IEntity_Model : IName_Model
{
    IValue_Model Hp { get; }
    Group_Resource Group { get; set; }
    IAmount_Model[] Armor { get; }
    IValue_Model Shield { get; }
    IAction_Model[] Actions { get; }

    bool Is_Alive => !Hp.Is_Min;
}