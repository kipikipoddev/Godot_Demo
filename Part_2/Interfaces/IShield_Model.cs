using Core;

namespace Interfaces;

public interface IShield_Model
{
    Ranged_Value<int> Shield { get; }
    bool Has => Shield?.Value > 0;
}