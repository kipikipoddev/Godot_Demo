using Commands;
using Core;
using Requests;

namespace Controllers;

public class Action_Controller
{
    public Action_Controller()
    {
        Mediator.Add_Handler<Can_Action_Request, bool>(Can_Action_Handler);
        Mediator.Add_Listener<Do_Action_Command>(Do_Action_Handler);
    }

    private static bool Can_Action_Handler(Can_Action_Request req)
    {
        if (req.Target == null)
            return false;

        var target_alive = req.Target.Is_Alive;
        var on_live_target = req.Action.On_Live_Target;
        if (target_alive ^ on_live_target)
            return false;

        var parent_alive = req.Action.Owner.Is_Alive;
        if (!parent_alive)
            return false;

        var on_cooldown = req.Action.Cooldown.In_Progress;
        if (on_cooldown)
            return false;

        var is_same_group = Is_Same_Group(req);
        var on_friendly = req.Action.On_Friendly;
        if (is_same_group ^ on_friendly)
            return false;

        return true;
    }

    private static bool Is_Same_Group(Can_Action_Request req)
    {
        var group = req.Action.Owner.Group;
        var target_group = req.Target.Group;
        return group == target_group;
    }

    private static void Do_Action_Handler(Do_Action_Command cmd)
    {
        cmd.Action.Cooldown.Start();
    }
}