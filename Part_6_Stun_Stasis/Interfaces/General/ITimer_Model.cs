namespace Interfaces;

public interface ITimer_Model
{
    bool Is_Paused { get; set; }
    double Current { get; set; }
    double Interval { get; }
    bool In_Progress => Current > 0;
    bool Ended => Current <= 0;
    void Start();
}