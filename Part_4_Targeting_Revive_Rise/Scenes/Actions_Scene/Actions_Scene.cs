using Godot;
using Interfaces;
using Messages;

public partial class Actions_Scene : Base_Scene<IAction_Model[]>
{
    private Button[] buttons;

    private IEntity_Model[] targets;

    public override void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            targets[i] = new Get_Target_Request(Model[i]).Result;
            buttons[i].Disabled = targets[i] == null;
        }
    }

    protected override void On_model_changed()
    {
        var vb = GetNode<VBoxContainer>("VBoxContainer");
        buttons = new Button[Model.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = Get_Button(i);
            vb.AddChild(buttons[i]);
        }
        targets = new IEntity_Model[buttons.Length];
    }

    private Button Get_Button(int index)
    {
        var button = new Button();
        button.Text = Model[index].Name;
        button.Pressed += () => Model[index].Do(targets[index]);
        return button;
    }
}
