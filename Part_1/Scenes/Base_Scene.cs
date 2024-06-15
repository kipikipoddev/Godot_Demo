using Messages;
using Core;
using Godot;

public partial class Base_Scene : Node2D
{
    public Components Model;

    public Base_Scene()
    {
        Mediator.Add_Listener<Update_Message>((m) => Update());
    }

    public virtual void Update() { }
}
