namespace Interfaces;

public interface IEffect_Model : IType_Model, IName_Model
{
    double Time_Left { get; }
    bool Ended => Time_Left <= 0;

    IEntity_Model Target { get; }
}