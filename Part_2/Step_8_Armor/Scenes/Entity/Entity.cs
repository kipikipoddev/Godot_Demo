using System.Linq;
using Godot;
using Interfaces;
using Messages;
using Resources;

public partial class Entity : Base_Scene<IEntity_Model>
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity[] Targets;

    private Label hp_lable;

    public override void _Ready()
    {
        GetNode<Label>("Name_Label").Text = Get_Name();
        hp_lable = GetNode<Label>("Hp_Label");
        Model = new Create_Entity_Model_Request(Resource).Result;
        var actions = GetNode<Actions_Scene>("Actions");
        actions.Targets = Targets.ToList();
        actions.Model = Model.Actions.ToArray();
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

    private string Get_Name()
    {
        return Resource.Name + (Resource.Armor > 0 ? $" ({Resource.Armor})" : "");
    }
}
