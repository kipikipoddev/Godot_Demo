using System;

namespace Core;

public abstract record Request<TRequest, TResult>
    where TRequest : class
{
    public static Func<TRequest, TResult> Handler;

    public TResult Result { get; }

    public Request()
    {
        Console.WriteLine(GetType().Name + " started");
        Result = Handler(this as TRequest);
        Console.WriteLine(GetType().Name + " ended");
    }
}