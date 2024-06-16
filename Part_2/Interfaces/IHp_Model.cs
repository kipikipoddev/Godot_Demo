using Core;

namespace Interfaces;

public interface IHp_Model
{
    Ranged_Value<int> Hp { get; }
    bool Is_Alive => Hp.Value > 0;
}