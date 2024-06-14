using Core;

namespace Components_Namespace;

public class Value_Component<T> : Component
{
    public T Value { get; }

    public Value_Component(T value)
    {
        Value = value;
    }
}