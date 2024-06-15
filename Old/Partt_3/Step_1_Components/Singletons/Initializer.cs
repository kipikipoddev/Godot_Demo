using Controllers;
using Godot;

namespace Singletons;

public partial class Initializer : Node
{
    public Initializer()
    {
        new Create_Models_Controller();
        new Timer_Controller();
        new Actions_Controller();
        new Over_Time_Controller();
        new Damage_Controller();

        Mediator.Add_Listener<Message>(m => System.Console.WriteLine("1"));
        Mediator.Add_Listener<Test_Message>(m => System.Console.WriteLine("2" + m.Number));
        Mediator.Add_Listener<Test_Message>(m => System.Console.WriteLine("3" + m.Number));
        Mediator.Add_Listener<Message>(m => System.Console.WriteLine("4"));
        new Test_Message(2);
        System.Console.WriteLine("");
    }
}

public record Message
{
    public Message()
    {
        System.Console.WriteLine("PRE");
        Mediator.Call(this);
        System.Console.WriteLine("POST");
    }
}

public record Test_Message(int Number) : Message { }
