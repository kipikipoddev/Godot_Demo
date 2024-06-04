using Core;

namespace Interfaces;

public interface IHp_Model  
{
    /// <summary>
    /// The hp of the entity, in a range of zero to max
    /// </summary>
    Ranged_Value<int> Hp { get; set; }

    /// <summary>
    /// Is the entity have more then 0 hp
    /// </summary>
    bool Is_Alive => Hp.Value > 0;
}
