namespace Interfaces;

public interface IValue_Model<T>
{
    T Min { get; }
    T Max { get; set; }
    T Value { get; set; }
    bool Is_Min => Value.Equals(Min);
    bool Not_Min => !Value.Equals(Min);
}