namespace Interfaces;

public interface IAmount_Model : IType_Model
{
    IValue_Model Amount { get; }

    bool Is_Positive { get; }
}