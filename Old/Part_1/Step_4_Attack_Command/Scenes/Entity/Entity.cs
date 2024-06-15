using Godot;
using Models;

public partial class Entity : Base_Scene<Entity_Model>
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity Enemy;

    private Label hp_label;

    public override void _Ready()
    {
        hp_label = GetNode<Label>("Hp_Label");
        Model = new Entity_Model(Resource);
    }

    public override void Update()
    {
        hp_label.Text = Model.Hp.ToString("D2");
    }

    public void On_button_pressed()
    {
        Model.Attack(Enemy.Model);
    }
}