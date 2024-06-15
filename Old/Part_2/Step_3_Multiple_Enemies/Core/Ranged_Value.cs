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

    public T Min { get; private set; }

    public T Max { get; private set; }

    public T Value
    {
        get => value;
        set
        {
            this.value = GetValue(value);
        }
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