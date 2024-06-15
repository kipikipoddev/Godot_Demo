using Godot;
using Models;

public partial class Attacks_Scene : Base_Scene<Attack_Model[]>
{
    public Entity Enemy;

    private Button[] buttons;

    public override void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].Disabled = !Model[i].Can_Attack(Enemy.Model);
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
        button.Pressed += () => Model[index].Attack(Enemy.Model);
        return button;
    }
}
