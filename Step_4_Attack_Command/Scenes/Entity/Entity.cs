using Godot;
using Models;

public partial class Entity : Base_Scene<Entity_Model>
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity Enemy;

    private Label hp_lable;

    public override void _Ready()
    {
        hp_lable = GetNode<Label>("Hp_Label");
        Model = new Entity_Model(Resource);
    }

    public override void Update()
    {
        hp_lable.Text = Model.Hp.ToString("D2");
    }

    public void On_button_pressed()
    {
        Model.Attack(Enemy.Model);
    }
}
