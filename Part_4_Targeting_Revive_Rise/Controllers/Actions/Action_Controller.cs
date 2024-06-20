using Commands;
using Components_Namespace;
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

    private static void Do_Action_Handler(Do_Action_Command cmd)
    {
        cmd.Action.Timer().Start();
    }

    private static bool Can_Action_Handler(Can_Action_Request req)
    {
        if (req.Target == null)
            return false;

        var target_alive = req.Target.Hp().Is_Alive;
        var on_live_target = req.Action.Action().On_Live_Target;
        if (target_alive ^ on_live_target)
            return false;

        var parent_alive = req.Action.Parent.Hp().Is_Alive;
        if (!parent_alive)
            return false;

        var on_cooldown = req.Action.Timer().In_Progress;
        if (on_cooldown)
            return false;

        var is_same_group = Is_Same_Group(req);
        var on_friendly = req.Action.Action().On_Friendly;
        if (is_same_group ^ on_friendly)
            return false;

        return true;
    }

    private static bool Is_Same_Group(Can_Action_Request req)
    {
        var group = req.Action.Parent.Group();
        var target_group = req.Target.Group();
        return group == target_group;
    }
}