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
        Mediator.Add_Listener<Update_Message>((m) => Update());
        Mediator.Add_Listener<Time_Message>((m) => Time_Update());
    }

    public virtual void Update() { }
    public virtual void Time_Update() { }
    protected virtual void On_model_changed() { }
}
