using System.Linq;
using Components_Namespace;
using Core;
using Godot;
using Messages;
using Resources;

public partial class Entity : Base_Scene<Components>
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Entity[] Targets;

    private Label hp_lable;
    private Label shield_label;

    public override void _Ready()
    {
        hp_lable = GetNode<Label>("Hp_Label");
        shield_label = GetNode<Label>("Shield_Label");
        Model = new Create_Entity_Model_Request(Resource).Result;
        GetNode<Label>("Name_Label").Text = Get_Name();
        var actions = GetNode<Actions_Scene>("Actions");
        actions.Targets = Targets.ToList();
        actions.Model = Model.Get_All<Action_Component>().ToArray();
    }

    public override void Update()
    {
        var hp = Model.Hp();
        hp_lable.Text = hp.Is_Min ? "Dead" : hp.ToString();

        var shield = Model.Get_Or_Defualt<Shield_Component>()?.Shield;
        shield_label.Visible = shield != null;
        if (shield != null)
            shield_label.Text = shield.ToString();
    }

    private string Get_Name()
    {
        return Model.Name() + (Resource.Armor > 0 ? $" ({Resource.Armor})" : "");
    }
}