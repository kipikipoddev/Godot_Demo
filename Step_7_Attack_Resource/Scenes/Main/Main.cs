using Messages;
using Godot;
using Controllers;

public partial class Main : Node2D
{
    public override void _Ready()
    {
        new Attack_Controller();
        new Update_Message();
    }
}
