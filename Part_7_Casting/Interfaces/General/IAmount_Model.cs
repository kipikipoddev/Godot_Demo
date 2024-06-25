namespace Interfaces;

public interface IAmount_Model : IType_Model
{
    int Amount { get; }
    bool Is_Positive { get; }
}