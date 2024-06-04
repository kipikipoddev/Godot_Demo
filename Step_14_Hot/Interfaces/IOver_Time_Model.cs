namespace Interfaces;

public interface IOver_Time_Model : IAction_Model
{
    public int Time_Between { get; }
    public int Times { get; }
}