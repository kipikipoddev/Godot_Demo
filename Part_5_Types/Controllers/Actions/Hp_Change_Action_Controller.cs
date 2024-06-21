using Commands;
using Components_Namespace;
using Core;

namespace Controllers;

public class Hp_Change_Action_Controller
{
    public Hp_Change_Action_Controller()
    {
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
    }

    private static void Do_Action_Handler(Do_Action_Command cmd)
    {
        var comp = cmd.Action.Get<Hp_Change_Action_Component>();
        if (comp != null)
        {
            var amount = cmd.Action.Amount().Amount;
            new Hp_Change_Command(cmd.Target, amount);
            Handle_Over_Time(cmd, amount);
        }
    }

    private static void Handle_Over_Time(Do_Action_Command cmd, int amount)
    {
        var comp = cmd.Action.Get<Over_Time_Component>();
        if (comp != null)
            new Over_Time_Command(comp.Times, comp.Time_Between, cmd.Target, amount, cmd.Action.Name());
    }

}