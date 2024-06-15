using System;

namespace Core;

public class Ranged_Value<T>
    where T : IComparable<T>
{
    private T value;

    public Ranged_Value(T value, T min, T max)
    {
        this.value = value;
        Min = min;
        Max = max;
    }

    public bool Is_Min => Value.Equals(Min);
    public bool Not_Min => !Value.Equals(Min);
    public bool Is_Max => Value.Equals(Max);
    public bool Not_Max => !Value.Equals(Max);

    public T Min { get; set; }

    public T Max { get; set; }

    public T Value
    {
        get => value;
        set
        {
            this.value = GetValue(value);
        }
    }

    public override string ToString()
    {
        return $"{Value:D2} / {Max:D2}";
    }

    private T GetValue(T value)
    {
        var min = Min.CompareTo(value);
        if (min > 0)
            return Min;
        var max = Max.CompareTo(value);
        if (max < 0)
            return Max;
        return value;
    }
}