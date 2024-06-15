using System.Linq;
using Godot;
using Models;
using Resources;

public partial class Entity : Base_Scene<Entity_Model>
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity[] Targets;

    private Label hp_lable;

    public override void _Ready()
    {
        GetNode<Label>("Name_Label").Text = Resource.Name;
        hp_lable = GetNode<Label>("Hp_Label");
        Model = new Entity_Model(Resource);
        var actions = GetNode<Actions_Scene>("Actions");
        actions.Targets = Targets.ToList();
        actions.Model = Model.Actions;
    }

    public override void Update()
    {
        hp_lable.Text = Get_Hp();
    }

    private string Get_Hp()
    {
        return Model.Is_Alive ?
            $"{Model.Hp.Value:D2} / {Model.Hp.Max:D2}" :
            "Dead";
    }
}
