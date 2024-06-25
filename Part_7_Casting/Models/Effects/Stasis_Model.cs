using Interfaces;

namespace Models;

public class Stasis_Model : Effect_Model
{
    public Stasis_Model(Stasis_Action_Model action, IEntity_Model target)
        : base(action, target, action.Time)
    {
    }
}