using System.Linq;
using Core;
using Interfaces;
using Models;
using Requests;

namespace Controllers;

public class Can_Action_Controller
{
    public Can_Action_Controller()
    {
        Mediator.Add_Handler<Can_Action_Request, bool>(Can_Action_Handler);
    }

    private static bool Can_Action_Handler(Can_Action_Request req)
    {
        if (!Is_Entity_Valid(req.Action.Owner, req.Start_Casting))
            return false;
        if (!Is_Target_Valid(req.Target, req.Action))
            return false;

        var on_cooldown = req.Action.Cooldown.Not_Min;
        if (req.Start_Casting & on_cooldown)
            return false;

        var is_same_group = Is_Same_Group(req);
        var on_friendly = req.Action.On_Friendly;
        if (is_same_group ^ on_friendly)
            return false;

        return true;
    }

    private static bool Is_Target_Valid(IEntity_Model target, IAction_Model action)
    {
        if (target == null)
            return false;

        var target_alive = target.Is_Alive;
        var on_live_target = action.On_Live_Target;
        if (target_alive ^ on_live_target)
            return false;

        var target_stasis = target.Effects.Any(e => e is Stasis_Model);
        return !target_stasis;
    }


    private static bool Is_Entity_Valid(IEntity_Model entity, bool start_casting)
    {
        if (!entity.Is_Alive || (start_casting && entity.Is_Casting))
            return false;

        var has_effect = entity.Effects.Any(e => e is Stun_Model | e is Stasis_Model);
        return !has_effect;
    }

    private static bool Is_Same_Group(Can_Action_Request req)
    {
        var group = req.Action.Owner.Group;
        var target_group = req.Target.Group;
        return group == target_group;
    }
}