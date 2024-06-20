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
        Mediator.Add_Handler<Create_Entity_Request, Components>(Create_Entity_Handler);
    }

    private Components Create_Entity_Handler(Create_Entity_Request req)
    {
        var resource = req.Resource;
        return new Components()
            .Set(new Name_Component(resource.Name))
            .Set(new Hp_Component(resource.Hp))
            .Set(Create_Action(resource.Action));
    }

    private Components Create_Action(Attack_Resource res)
    {
        return new Components()
            .Set(new Name_Component(res.Name))
            .Set(new Hp_Change_Action_Component(-res.Damage));
    }
}