using Core;

namespace Interfaces;

public interface IEffects_Model
{
    /// <summary>
    /// An amount of damage reduction
    /// </summary>
    int Armor { get; }

    /// <summary>
    /// An amount of temporary damage reduction
    /// </summary>
    Ranged_Value<int> Shield { get; }
}
