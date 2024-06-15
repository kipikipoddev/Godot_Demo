using System.Linq;
using Components_Namespace;
using Core;
using Requests;
using Resources;

namespace Controllers;

public class Create_Entity_Controller
{
    public Create_Entity_Controller()
    {
        Mediator.Set_Handler<Create_Entity_Request, Components>(Create_Entity_Handler);
    }

    private Components Create_Entity_Handler(Create_Entity_Request request)
    {
        var resource = request.Resource;
        return new Components()
            .Set(new Name_Component(resource.Name))
            .Set(new Hp_Component(resource.Hp))
            .Set(new Armor_Component(request.Resource.Armor))
            .Add_Range(resource.Actions.Select(Create_Action));
    }

    private Action_Components Create_Action(Action_Resource resource)
    {
        Action_Components action = null;
        if (resource is Attack_Resource attack)
            action = new Attack_Action_Components(resource.Name, resource.Cooldown, attack.Damage);
        else if (resource is Heal_Resource heal)
            action = new Heal_Action_Components(resource.Name, resource.Cooldown, heal.Heal);
        else if (resource is Shield_Resource shield)
            action = new Shield_Action_Components(resource.Name, resource.Cooldown, shield.Amount);
        else if (resource is Hot_Resource hot)
            action.Set(new Over_Time_Component(hot.Time_Between, hot.Times));
        else if (resource is Dot_Resource dot)
            action.Set(new Over_Time_Component(dot.Time_Between, dot.Times));
        return action;
    }
}