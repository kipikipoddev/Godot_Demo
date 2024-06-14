using Core;
using Godot;
using Messages;

public partial class Base_Scene<T> : Node2D
{
    private T model;
    public T Model
    {
        get => model;
        set
        {
            model = value;
            On_model_changed();
        }
    }

    public Base_Scene()
    {
        Update_Message.Handle((m) => Update());
    }

    public virtual void Update() { }
    protected virtual void On_model_changed() { }
}
