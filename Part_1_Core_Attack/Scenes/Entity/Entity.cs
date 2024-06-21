using System.Linq;
using Godot;
using Requests;
using Resources;
using Interfaces;

public partial class Entity : Base_Scene<IEntity_Model>
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity[] Targets;

    private Label hp_lable;
    private Button action;
    private IEntity_Model target;

    public override void _Ready()
    {
        hp_lable = GetNode<Label>("Hp_Label");
        Model = new Create_Entity_Request(Resource).Result;
        GetNode<Label>("Name_Label").Text = Model.Name;
        action = GetNode<Button>("Action");
        action.Text = Model.Action.Name;
    }

    public override void Update()
    {
        hp_lable.Text = Model.Hp.Is_Min ? "Dead" : Model.Hp.ToString();
        target = Targets.FirstOrDefault(t => t.Model.Is_Alive)?.Model;
        action.Disabled = !Model.Action.Can(target);
    }

    public void On_Action_Pressed()
    {
        Model.Action.Do(target);
    }
}
