using System.Collections.Generic;
using System.Linq;
using Godot;
using Interfaces;

public partial class Actions_Scene : Base_Scene<IAction_Model[]>
{
    public List<Entity> Targets;

    private Button[] buttons;

    private IEntity_Model Target => Targets.FirstOrDefault()?.Model;

    public override void Update()
    {
        if (!Target?.Is_Alive ?? false)
            Targets.RemoveAt(0);
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].Disabled = !Model[i].Can_Do(Target);
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
        button.Text = Model[index].Name;
        button.Pressed += () => Model[index].Do(Target);
        return button;
    }
}
