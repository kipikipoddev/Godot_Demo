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
        var actions = GetNode<Actions_Scene>("Actions");
        name_label = GetNode<Label>("Name_Label");

        Model = new Create_Entity_Request(Resource, Group).Result; 
        name_label.Text = Model.Name;
        actions.Model = Model.Actions;
        Set_Armor();
    }

    public override void Update()
    {
        hp_lable.Text = Model.Hp.Is_Min ? "Dead" : Model.Hp.ToString();
        shield_label.Visible = !Model.Shield.Is_Min;
        shield_label.Text = Model.Shield.ToString();
        name_label.Modulate = Model.Group.Color;
    }

    private void Set_Armor()
    {
        var armor_vb = GetNode<HBoxContainer>("Armor");
        var armor = Model.Armor;
        foreach (var armor_model in armor)
        {
            var label = new Label
            {
                Text = armor_model.Amount.ToString(),
                Modulate = armor_model.Type.Color
            };
            armor_vb.AddChild(label);
        }
    }
}
