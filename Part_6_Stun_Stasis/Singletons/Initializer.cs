using Controllers;
using Godot;

namespace Singletons;

public partial class Initializer : Node
{
    public Initializer()
    {
        new Build_Entity_Controller();
        new Effects_Controller();
        new Timer_Controller();
        new Shield_Controller();
        new Armor_Controller();
        new Hp_Controller();
        new Actions_Controller();
        new Hp_Change_Action_Controller();
        new Action_Controller();
        new Over_Time_Controller();
        new Target_Controller();
    }
}