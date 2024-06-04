using System;

namespace Core;

public abstract record Request<TRequest, TResult> : Base
    where TRequest : class
{
    public static Func<TRequest, TResult> Handler;

    public TResult Result { get; }

    public Request()
    {
        Started();
        Result = Handler(this as TRequest);
        Ended();
    }
}