using Messages;
using Godot;

public partial class Base_Scene<T> : Node2D
{
    public T Model;

    public Base_Scene()
    {
        Update_Message.Handle((e) => Update());
    }

    public virtual void Update() { }
}
