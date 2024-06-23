using Commands;
using Core;

namespace Controllers;

public class Hp_Controller
{
    public Hp_Controller()
    {
        Mediator.Add_Listener<Hp_Change_Command>(Hp_Change_Handler);
    }

    private static void Hp_Change_Handler(Hp_Change_Command cmd)
    {
        cmd.Target.Hp.Value += cmd.Total * (cmd.Model.Is_Positive ? 1 : -1);
        cmd.Reduction = 0;
    }
}