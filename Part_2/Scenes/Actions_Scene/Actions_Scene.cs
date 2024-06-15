using System.Collections.Generic;
using System.Linq;
using Components_Namespace;
using Core;
using Godot;

public partial class Actions_Scene : Base_Scene<Action_Components[]>
{
    public List<Entity> Targets;

    private Button[] buttons;

    private Components Target => Targets.FirstOrDefault()?.Model;

    public override void Update()
    {
        if (Target?.Hp().Is_Min ?? false)
            Targets.RemoveAt(0);
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].Disabled = !Model[i].Can(Target);
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
        button.Text = Model[index].Get<Name_Component>().Name;
        button.Pressed += () => Model[index].Do(Target);
        return button;
    }
}
