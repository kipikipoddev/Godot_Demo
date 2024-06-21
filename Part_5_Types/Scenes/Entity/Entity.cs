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

    [Export(PropertyHint.Range, "1,2")]
    public int Group;

    private Label name_label;
    private Label hp_lable;
    private Label shield_label;

    public override void _Ready()
    {
        Model = new Build_Entity_Request(Resource, Group).Result;

        hp_lable = GetNode<Label>("Hp_Label");
        shield_label = GetNode<Label>("Shield_Label");
        var actions = GetNode<Actions_Scene>("Actions");
        name_label = GetNode<Label>("Name_Label");

        name_label.Text = Model.Name();
        actions.Model = Model.Get_Actions().ToArray();
        Set_Armor();
    }

    public override void Update()
    {
        var hp = Model.Hp();
        hp_lable.Text = Get_Hp(hp);
        Update_Shield();
        name_label.Modulate = Model.Group() == 1 ? Colors.Blue : Colors.Red;
    }

    private string Get_Hp(Hp_Component hp)
    {
        return hp.Is_Alive ? $"{hp.Value:d2} / {hp.Max:d2}" : "Dead";
    }

    private void Update_Shield()
    {
        var shield = Model.Shield();
        shield_label.Visible = shield != null;
        if (shield != null)
            shield_label.Text = $"{shield.Value} / {shield.Max}";
    }

    private void Set_Armor()
    {
        var armor_vb = GetNode<HBoxContainer>("Armor");
        var armosr_comps = Model.Get_Armors();
        armor_vb.Visible = armosr_comps.Any();
        foreach (var armor_comp in armosr_comps)
        {
            var label = new Label
            {
                Text = armor_comp.Amount.ToString(),
                Modulate = armor_comp.Parent.Amount().Type.Color
            };
            armor_vb.AddChild(label);
        }
    }
}
