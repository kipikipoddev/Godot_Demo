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
        Mediator.Add_Handler<Build_Entity_Request, Components>(Build_Entity_Handler);
    }

    private Components Build_Entity_Handler(Build_Entity_Request req)
    {
        var resource = req.Resource;
        return new Components()
            .Set(new Name_Component(resource.Name))
            .Set(new Hp_Component(resource.Hp))
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

        return action;
    }
}