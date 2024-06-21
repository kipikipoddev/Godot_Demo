namespace Interfaces;

public interface IValue_Model
{
    int Min { get; set; }
    int Max { get; set; }
    int Value { get; set; }
    bool Is_Min => Value == Min;
}