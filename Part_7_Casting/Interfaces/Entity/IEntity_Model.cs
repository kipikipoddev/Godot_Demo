using System.Collections.Generic;
using Resources;

namespace Interfaces;

public interface IEntity_Model : IName_Model
{
    IValue_Model<int> Hp { get; }
    Group_Resource Group { get; set; }
    IAmount_Model[] Armor { get; }
    IValue_Model<int> Shield { get; }
    IAction_Model[] Actions { get; }
    List<IEffect_Model> Effects { get; }
    IValue_Model<double> Casting { get; set;}

    bool Is_Alive => !Hp.Is_Min;
    bool Is_Casting => !Casting.Is_Min;
}