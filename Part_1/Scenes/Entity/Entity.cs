using Components_Namespace;
using Godot;
using Messages;
using Resources;

public partial class Entity : Base_Scene
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity Enemy;

    private Label hp_label;
    private Button attack_button;


    public override void _Ready()
    {
        GetNode<Label>("Name_Label").Text = Resource.Name;
        hp_label = GetNode<Label>("Hp_Label");
        attack_button = GetNode<Button>("Attack_Button");
        attack_button.Text = Resource.Attack.Name;
        Model = new Create_Entity_Request(Resource).Result;
    }

    public override void Update()
    {
        hp_label.Text = Get_Hp();
        attack_button.Disabled = !Model.Attack().Can_Attack(Enemy.Model);
    }

    private string Get_Hp()
    {
        return Model.Hp().Is_Min ? "Dead" : Model.Hp().ToString();
    }

    public void On_button_pressed()
    {
        Model.Attack().Attack(Enemy.Model);
    }
}
