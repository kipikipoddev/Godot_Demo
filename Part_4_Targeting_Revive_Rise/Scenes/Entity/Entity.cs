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

        name_label.Text = Get_Name();
        actions.Model = Model.Get_Actions().ToArray();
    }

    public override void Update()
    {
        var hp = Model.Hp();
        hp_lable.Text = Get_Hp(hp);
        var shield = Model.Shield();
        shield_label.Visible = shield != null;
        if (shield != null)
            shield_label.Text = $"{shield.Value} / {shield.Max}";
        name_label.Modulate = Model.Group() == 1 ? Colors.Blue : Colors.Red;
    }

    private string Get_Name()
    {
        return Model.Name() + (Resource.Armor > 0 ? $" ({Resource.Armor})" : "");
    }

    private string Get_Hp(Hp_Component hp)
    {
        return hp.Is_Alive ? $"{hp.Value:d2} / {hp.Max:d2}" : "Dead";
    }
}
