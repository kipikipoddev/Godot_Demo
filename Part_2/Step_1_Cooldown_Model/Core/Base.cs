using System;
using System.Text;

namespace Core;

public abstract record Base
{
    private static int ind = 0;

    protected virtual void Started()
    {
        Write_log("Started");
        ind++;
    }

    protected virtual void Ended()
    {
        ind--;
        Write_log("Ended");
    }

    protected void Write_log(string message)
    {
        var sb = new StringBuilder();
        sb.Append(DateTime.Now.ToString("HH:mm:ss:ff"));
        for (int i = 0; i < ind; i++)
            sb.Append('\t');
        Console.WriteLine($"{sb} {GetType().Name} {message}");
    }
}