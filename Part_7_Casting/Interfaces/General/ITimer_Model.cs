namespace Interfaces;

public interface ITimer_Model : IValue_Model<double>
{
    bool Is_Paused { get; set; }
    void Start();
}