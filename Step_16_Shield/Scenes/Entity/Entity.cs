using System.Linq;
using Core;
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
    private Label shield_label;

    public override void _Ready()
    {
        GetNode<Label>("Name_Label").Text = Get_Name();
        hp_lable = GetNode<Label>("Hp_Label");
        shield_label = GetNode<Label>("Shield_Label");
        Model = new Create_Entity_Model_Request(Resource).Result;
        var actions = GetNode<Actions_Scene>("Actions");
        actions.Targets = Targets.ToList();
        actions.Model = Model.Actions.ToArray();
    }

    public override void Update()
    {
        hp_lable.Text = Model.Is_Alive ? Model.Hp.ToString() : "Dead";
        shield_label.Visible = Model.Shield.Value > 0;
        shield_label.Text = Model.Shield.ToString();
    }

    private string Get_Name()
    {
        return Resource.Name + (Resource.Armor > 0 ? $" ({Resource.Armor})" : "");
    }
}
