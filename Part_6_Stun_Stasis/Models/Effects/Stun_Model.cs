using Interfaces;

namespace Models;

public class Stun_Model : Effect_Model
{
    public Stun_Model(Stun_Action_Model action, IEntity_Model target)
        : base(action, target, action.Time)
    {
    }
}