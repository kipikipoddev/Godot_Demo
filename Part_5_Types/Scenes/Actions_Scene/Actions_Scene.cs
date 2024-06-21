using Components_Namespace;
using Core;
using Godot;
using Messages;

public partial class Actions_Scene : Base_Scene<Action_Component[]>
{
    private Button[] buttons;
    private Components[] targets;

    public override void Update()
    {
        targets = new Components[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            targets[i] = new Get_Target_Request(Model[i]).Result;
            buttons[i].Disabled = !Model[i].Can(targets[i]);
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
    }

    private Button Get_Button(int index)
    {
        var button = new Button();
        var parent = Model[index].Parent;
        var amount_comp = parent.Amount();
        var amount_str = amount_comp != null ? $"({amount_comp.Amount})" : "";
        button.Text = parent.Name() + amount_str;
        button.Modulate = amount_comp.Type.Color;
        button.Pressed += () => Model[index].Do(targets[index]);
        return button;
    }
}
