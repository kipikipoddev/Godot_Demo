using System.Collections.Generic;

namespace Interfaces;

public interface IEntity_Model : IHp_Model
{
    /// <summary>
    /// All the actions that the entity can proforme
    /// </summary>
    List<IAction_Model> Actions { get; }
}
