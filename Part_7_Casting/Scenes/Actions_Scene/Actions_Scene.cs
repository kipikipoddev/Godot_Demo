using System.Text;
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

    public override void Time_Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            var model = Model[i];
            if (model.Cooldown.Not_Min)
                buttons[i].Text = model.Cooldown.ToString();
            else
                buttons[i].Text = Get_Name(model);
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
        var model = Model[index];

        button.Text = Get_Name(model);
        button.Pressed += () => model.Start(targets[index]);
        button.Modulate = model.Type.Color;
        return button;
    }

    private static string Get_Name(IAction_Model model)
    {
        var sb = new StringBuilder(model.Name);
        if (model is IAmount_Model amount)
        {
            sb.Append($" ({amount.Amount}");
            if (model is IOver_Timer_Model over)
                sb.Append($"x{over.Times}");
            sb.Append(')');
        }
        return sb.ToString();
    }
}
