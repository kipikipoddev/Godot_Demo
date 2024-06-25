
using System;
using Interfaces;

namespace Models;

public class Value_Model : IValue_Model
{
    private int value;
    public int Min { get; set; }
    public int Max { get; set; }

    public bool Is_Min => value == Min;

    public Value_Model(int value, int? min = null, int? max = null)
    {
        this.value = value;
        Min = min ?? 0;
        Max = max ?? value;
    }

    public int Value
    {
        get => value;
        set
        {
            this.value = Math.Min(Max, Math.Max(Min, value));
        }
    }

    public override string ToString()
    {
        return $"{Value:d2} / {Max:d2}";
    }
}