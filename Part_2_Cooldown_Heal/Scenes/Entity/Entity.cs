using System.Linq;
using Components_Namespace;
using Core;
using Godot;
using Requests;
using Resources;

public partial class Entity : Base_Scene<Components>
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity[] Targets;

    private Label hp_lable;

    public override void _Ready()
    {
        hp_lable = GetNode<Label>("Hp_Label");
        Model = new Build_Entity_Request(Resource).Result;
        GetNode<Label>("Name_Label").Text = Model.Name();
        var actions = GetNode<Actions_Scene>("Actions");
        actions.Targets = Targets.ToList();
        actions.Model = Model.Get_Actions().ToArray();
    }

    public override void Update()
    {
        var hp = Model.Hp();
        hp_lable.Text = Get_Hp(hp);
    }

    private string Get_Hp(Hp_Component hp)
    {
        return hp.Is_Alive ? $"{hp.Value:d2} / {hp.Max:d2}" : "Dead";
    }
}
