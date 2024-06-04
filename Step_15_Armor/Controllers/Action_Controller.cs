using Interfaces;

namespace Controllers;

public abstract class Action_Controller
{
    protected bool Can_Action(IAction_Model action_, IHp_Model target)
    {
        return target != null &&
            target.Is_Alive &
            action_.Owner.Is_Alive &
            !action_.Cooldown.In_Progress;
    }
}