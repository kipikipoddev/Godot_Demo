using Godot;

public partial class Entity : Node
{
    [Export]
    public Entity Enemy;

    private Label hp_lable;
    protected Entity_Model Model;

    public override void _Ready()
    {
        hp_lable = GetNode<Label>("Hp_Label");
        Model = new Entity_Model(5);
        Update();
    }

    public void Update()
    {
        hp_lable.Text = Model.Hp.ToString("D2");
    }

    public void On_button_pressed()
    {
        Enemy.Model.Hp--;
        Enemy.Update();
    }
}
