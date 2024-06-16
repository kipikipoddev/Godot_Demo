namespace Interfaces;

public interface IOvertime_Model : IName_Model
{
    int Time_between { get; }
    int Times { get; }
}