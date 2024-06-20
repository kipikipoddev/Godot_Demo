using System.Collections.Generic;
using System.Linq;
using Components_Namespace;
using Core;
using Messages;
using Requests;
using Resources;

namespace Controllers;

public class Create_Entity_Controller
{
    public Create_Entity_Controller()
    {
        Mediator.Add_Handler<Create_Entity_Request, Components>(Create_Entity_Handler);
    }

    private Components Create_Entity_Handler(Create_Entity_Request req)
    {
        var resource = req.Resource;
        var entity = new Components()
            .Set(new Name_Component(resource.Name))
            .Set(new Group_Component(req.Group))
            .Set(new Hp_Component(resource.Hp))
            .Set(new Armor_Component(req.Resource.Armor))
            .Add_Range(Get_Actions(resource));
        new Entity_Created_Message(entity);
        return entity;
    }

    private static IEnumerable<Components> Get_Actions(Entity_Resource resource)
    {
        return resource.Actions.Select(r => new Create_Action_Request(r).Result);
    }


    private Components Create_Action(Action_Resource res)
    {
        var action = new Components()
            .Set(new Name_Component(res.Name))
            .Set(new Timer_Component(res.Cooldown));

        if (res is Attack_Resource attack)
            action.Set(new Hp_Change_Action_Component(-attack.Damage, false));

        else if (res is Heal_Resource heal)
            action.Set(new Hp_Change_Action_Component(heal.Heal, true));

        else if (res is Shield_Resource shield)
            action.Set(new Shield_Action_Component(shield.Amount));

        if (res is Hot_Resource hot)
            action.Set(new Over_Time_Component(hot.Time_Between, hot.Times));
        if (res is Dot_Resource dot)
            action.Set(new Over_Time_Component(dot.Time_Between, dot.Times));

        return action;
    }
}