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
    public Entity Target;

    private Label hp_lable;
    private Button attack_button;
    private Action_Component action;

    public override void _Ready()
    {
        Model = new Create_Entity_Request(Resource).Result;

        hp_lable = GetNode<Label>("Hp_Label");
        GetNode<Label>("Name_Label").Text = Get_Name();
        attack_button = GetNode<Button>("Attack_Button");

        action = Model.Get<Components>().Action();
        attack_button.Text = action.Parent.Name();
    }

    public override void Update()
    {
        var hp = Model.Hp();
        hp_lable.Text = Get_Hp(hp);
        attack_button.Disabled = !action.Can(Target.Model);
    }

    private string Get_Name()
    {
        return Model.Name();
    }

    private string Get_Hp(Hp_Component hp)
    {
        return hp.Is_Alive ? $"{hp.Value:d2} / {hp.Max:d2}" : "Dead";
    }

    public void On_attack_button_pressed()
    {
        action.Do(Target.Model);
    }
}
