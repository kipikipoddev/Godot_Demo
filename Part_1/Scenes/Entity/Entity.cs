using System.Linq;
using Components_Namespace;
using Core;
using Godot;
using Resources;

public partial class Entity : Base_Scene
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity Enemy;

    private Label hp_label;
    private Button attack_button;
    private Components attack_model;

    public override void _Ready()
    {
        GetNode<Label>("Name_Label").Text = Resource.Name;
        hp_label = GetNode<Label>("Hp_Label");
        attack_button = GetNode<Button>("Attack_Button");
        attack_button.Text = Resource.Attack.Name;
        Model = new Create_Entity_Request(Resource).Result;
        attack_model = Model.Get_Actions().First();
    }

    public override void Update()
    {
        Set_Hp();
        attack_button.Disabled = !attack_model.Get_Can_Action()(Enemy.Model);
    }

    private void Set_Hp()
    {
        hp_label.Text = Model.Get_Hp().Is_Min ? "Dead" : Model.Get_Hp().ToString();
    }

    public void On_button_pressed()
    {
        attack_model.Get_Do_Action()(Enemy.Model);
    }
}
