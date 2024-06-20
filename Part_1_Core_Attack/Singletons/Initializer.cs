using Controllers;
using Godot;

namespace Singletons;

public partial class Initializer : Node
{
    public Initializer()
    {
        new Create_Entity_Controller();
        new Hp_Controller();
        new Hp_Change_Action_Controller();
        new Action_Controller();
    }
}