namespace Interfaces;

public interface ITimer_Model
{
    int Time { get; }
    double Current { get; set; }
    bool In_Progress => Current > 0;
    bool Ended => Current <= 0;

    void Start();
}