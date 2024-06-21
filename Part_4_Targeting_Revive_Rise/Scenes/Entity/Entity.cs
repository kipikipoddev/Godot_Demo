using Godot;
using Requests;
using Resources;
using Interfaces;

public partial class Entity : Base_Scene<IEntity_Model>
{
    [Export]
    public Entity_Resource Resource;

    [Export]
    public Group_Resource Group;

    private Label hp_lable;
    private Label shield_label;
    private Label name_label;


    public override void _Ready()
    {
        hp_lable = GetNode<Label>("Hp_Label");
        shield_label = GetNode<Label>("Shield_Label");
        Model = new Create_Entity_Request(Resource, Group).Result;
        name_label = GetNode<Label>("Name_Label");
        name_label.Text = Get_Name();
        var actions = GetNode<Actions_Scene>("Actions");
        actions.Model = Model.Actions;
    }

    public override void Update()
    {
        hp_lable.Text = Model.Hp.Is_Min ? "Dead" : Model.Hp.ToString();
        shield_label.Visible = !Model.Shield.Is_Min;
        shield_label.Text = Model.Shield.ToString();
        name_label.Modulate = Model.Group.Color;
    }

    private string Get_Name()
    {
        return Model.Name + (Model.Armor > 0 ? $" ({Model.Armor})" : "");
    }
}
