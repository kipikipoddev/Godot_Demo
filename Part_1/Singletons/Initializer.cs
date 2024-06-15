using Controllers;
using Godot;

namespace Singletons;

public partial class Initializer : Node
{
    public Initializer()
    {
        new Attack_Controller();
        new Create_Entity_Controller();
    }
}