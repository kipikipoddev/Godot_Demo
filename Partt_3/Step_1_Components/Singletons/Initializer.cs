using Controllers;
using Godot;

namespace Singletons;

public partial class Initializer : Node
{
    public Initializer()
    {
        new Create_Models_Controller();
        new Timer_Controller();
        new Actions_Controller();
        new Over_Time_Controller();
        new Damage_Controller();
    }
}