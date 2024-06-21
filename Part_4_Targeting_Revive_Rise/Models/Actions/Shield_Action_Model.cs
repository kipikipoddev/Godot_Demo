using Resources;

namespace Models;

public class Shield_Action_Model : Action_Model
{
    public int Amount { get; }

    public Shield_Action_Model(Shield_Resource resource)
        : base(resource, true, true)
    {
        Amount = resource.Amount;
    }
}