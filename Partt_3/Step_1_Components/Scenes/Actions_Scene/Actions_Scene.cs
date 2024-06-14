using System.Collections.Generic;
using System.Linq;
using Components_Namespace;
using Core;
using Godot;

public partial class Actions_Scene : Base_Scene<Action_Component[]>
{
    public List<Entity> Targets;

    private Button[] buttons;

    private Components Target => Targets.FirstOrDefault()?.Model;

    public override void Update()
    {
        if (!Target?.Get<Hp_Component>().Is_alive ?? false)
            Targets.RemoveAt(0);
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].Disabled = !Model[i].Get<Can_Action_Component>().Can_Do(Target);
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
        button.Pressed += () => Model[index].Get<Do_Action_Component>().Do(Target);
        return button;
    }
}
