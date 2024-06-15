using Components_Namespace;
using Godot;
using Requests;
using Resources;

public partial class Entity : Base_Scene
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity Enemy;

    private Label hp_label;
    private Button attack_button;
    private Attack_Component attack_model;

    public override void _Ready()
    {
        GetNode<Label>("Name_Label").Text = Resource.Name;
        hp_label = GetNode<Label>("Hp_Label");
        attack_button = GetNode<Button>("Attack_Button");
        attack_button.Text = Resource.Attack.Name;
        Model = new Create_Entity_Request(Resource).Result;
        attack_model = Model.Get<Attack_Component>();
    }

    public override void Update()
    {
        Set_Hp();
        attack_button.Disabled = !attack_model.Can(Enemy.Model);
    }

    private void Set_Hp()
    {
        hp_label.Text = Model.Hp().Is_Min ? "Dead" : Model.Hp().ToString();
    }

    public void On_button_pressed()
    {
        attack_model.Do(Enemy.Model);
    }
}
