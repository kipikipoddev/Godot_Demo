using Singletons;

namespace Core;

public abstract record Request<T> : Message
{
    public T Result { get; protected set; }

    protected override void Call()
    {
        Result = Mediator.Call(this);
    }
}