using System.Collections.Generic;
using System.Linq;
using Godot;
using Models;

public partial class Attacks_Scene : Base_Scene<Attack_Model[]>
{
    public List<Entity> Enemies;

    private Button[] buttons;

    private Entity_Model Enemy => Enemies.FirstOrDefault()?.Model;

    public override void Update()
    {
        if (!Enemy?.Is_Alive ?? false)
            Enemies.RemoveAt(0);
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].Disabled = !Model[i].Can_Attack(Enemy);
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
        button.Pressed += () => Model[index].Attack(Enemy);
        return button;
    }
}
