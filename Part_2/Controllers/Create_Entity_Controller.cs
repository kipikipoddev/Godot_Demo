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
        Mediator.Add_Listener<Create_Entity_Request, Components>(Create_Entity_Handler);
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

    private Components Create_Action(Action_Resource resource)
    {
        var action = new Components()
            .Set(new Name_Component(resource.Name))
            .Set(new Action_Component())
            .Set(new Timer_Component(resource.Cooldown));

        if (resource is Attack_Resource attack)
            action.Set(new Amount_Component(attack.Damage))
                  .Set(new Hp_Change_Action_Component(false));

        else if (resource is Heal_Resource heal)
            action.Set(new Amount_Component(heal.Heal))
                  .Set(new Hp_Change_Action_Component(true));
                  
        else if (resource is Shield_Resource shield)
            action.Set(new Shield_Action_Component())
                  .Set(new Amount_Component(shield.Amount));

        //if (resource is Hot_Resource hot)
        //action.Set(new Over_Time_Component(hot.Time_Between, hot.Times));
        //if (resource is Dot_Resource dot)
        //action.Set(new Over_Time_Component(dot.Time_Between, dot.Times));

        return action;
    }
}