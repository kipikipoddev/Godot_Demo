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
    private VBoxContainer effects_vbox;

    public override void _Ready()
    {
        hp_lable = GetNode<Label>("Hp_Label");
        shield_label = GetNode<Label>("Shield_Label");
        var actions = GetNode<Actions_Scene>("Actions");
        name_label = GetNode<Label>("Name_Label");
        effects_vbox = GetNode<VBoxContainer>("Effects");

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
        Update_Effects();
    }

    private void Update_Effects()
    {
        foreach (var child in effects_vbox.GetChildren())
            effects_vbox.RemoveChild(child);
        foreach (var effect in Model.Effects)
        {
            var ls = new LabelSettings();
            ls.FontSize = 10;
            var label = new Label
            {
                Text = effect.Name,
                LabelSettings = ls,
                Modulate = effect.Type.Color
            };
            effects_vbox.AddChild(label);
        }
    }


    private void Set_Armor()
    {
        var armor_vb = GetNode<HBoxContainer>("Armor");
        var armor = Model.Armor;
        foreach (var armor_model in armor)
            armor_vb.AddChild(Get_Label(armor_model));
    }

    private static Label Get_Label(IAmount_Model model)
    {
        return new Label
        {
            Text = model.Amount.ToString(),
            Modulate = model.Type.Color
        };
    }

}
