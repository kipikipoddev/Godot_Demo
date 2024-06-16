using Core;

namespace Interfaces;

public interface ITimer_Model
{
    Ranged_Value<double> Time { get; }
    bool In_Progress => Time.Value > 0;
    bool Ended => Time.Value <= 0;

    void Start();
}