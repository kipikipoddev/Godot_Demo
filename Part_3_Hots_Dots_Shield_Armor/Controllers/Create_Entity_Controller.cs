using System.Linq;
using Components_Namespace;
using Core;
using Requests;
using Resources;

namespace Controllers;

public class Build_Entity_Controller
{
    public Build_Entity_Controller()
    {
        Mediator.Add_Handler<Create_Entity_Request, Components>(Create_Entity_Handler);
    }

    private Components Create_Entity_Handler(Create_Entity_Request req)
    {
        var resource = req.Resource;
        return new Components()
            .Set(new Name_Component(resource.Name))
            .Set(new Hp_Component(resource.Hp))
            .Set(new Armor_Component(req.Resource.Armor))
            .Add_Range(resource.Actions.Select(Create_Action));
    }

    private Components Create_Action(Action_Resource res)
    {
        var action = new Components()
            .Set(new Name_Component(res.Name))
            .Set(new Timer_Component(res.Cooldown));

        if (res is Attack_Resource attack)
            action.Set(new Hp_Change_Action_Component(-attack.Damage));

        else if (res is Heal_Resource heal)
            action.Set(new Hp_Change_Action_Component(heal.Heal));

        else if (res is Shield_Resource shield)
            action.Set(new Shield_Action_Component(shield.Amount));

        if (res is Hot_Resource hot)
            action.Set(new Over_Time_Component(hot.Time_Between, hot.Times));
        if (res is Dot_Resource dot)
            action.Set(new Over_Time_Component(dot.Time_Between, dot.Times));

        return action;
    }
}