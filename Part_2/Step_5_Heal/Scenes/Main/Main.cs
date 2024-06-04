using Messages;
using Godot;

public partial class Main : Node2D
{
    public override void _Ready()
    {
        new Update_Message();
    }

    public override void _Process(double delta)
    {
        new Time_Message(delta);
    }
}
