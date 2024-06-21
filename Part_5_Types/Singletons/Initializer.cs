using Controllers;
using Godot;
using Resources;

namespace Singletons;

public partial class Initializer : Node
{
    public Initializer()
    {
        var att = new Attack_Resource();
        att.Damage = 1;
        att.Name = "ATT";

        new Build_Entity_Controller();
        new Build_Action_Controller();

        new Timer_Controller();
        new Shield_Controller();
        new Armor_Controller();
        new Hp_Controller();
        new Shield_Action_Controller();
        new Hp_Change_Action_Controller();
        new Action_Controller();
        new Over_Time_Controller();
        new Target_Controller();
        new Rise_Action_Controller();
    }
}