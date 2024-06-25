using System;
using Interfaces;

namespace Models;

public class Value_Model<T> : IValue_Model<T>
    where T : IComparable
{
    private T value;
    public T Min { get; set; }
    public T Max { get; set; }

    public Value_Model(T min, T max, bool set_max = true)
    {
        value = set_max ? max : min;
        Min = min;
        Max = max;
    }

    public T Value
    {
        get => value;
        set
        {
            if (Min.CompareTo(value) > 0)
                value = Min;
            if (Max.CompareTo(value) < 0)
                value = Max;
            this.value = value;
        }
    }
}