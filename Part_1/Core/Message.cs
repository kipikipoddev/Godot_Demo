using System;
using System.Text;
using Singletons;

namespace Core;

public abstract record Message
{
    protected static int Indentation = 0;

    public Message()
    {
        Start();
        Call();
        End();
    }

    protected virtual void Call()
    {
        Mediator.Call(this);
    }

    protected virtual void Start()
    {
        Write_log("Started");
        Indentation++;
    }

    protected virtual void End()
    {
        Indentation--;
        Write_log("Ended");
    }

    protected void Write_log(string message)
    {
        var sb = new StringBuilder();
        sb.Append(DateTime.Now.ToString("HH:mm:ss:ff"));
        for (int i = 0; i < Indentation; i++)
            sb.Append('\t');
        Console.WriteLine($"{sb} {GetType().Name} {message}");
    }
}