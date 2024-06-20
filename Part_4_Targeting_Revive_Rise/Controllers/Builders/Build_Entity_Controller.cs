using System.Collections.Generic;
using System.Linq;
using Components_Namespace;
using Core;
using Messages;
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
        var entity = new Components()
            .Set(new Name_Component(resource.Name))
            .Set(new Group_Component(req.Group))
            .Set(new Hp_Component(resource.Hp))
            .Set(new Armor_Component(req.Resource.Armor))
            .Add_Range(Get_Actions(resource));
        new Components_Created_Message(entity);
        return entity;
    }

    private static IEnumerable<Components> Get_Actions(Entity_Resource resource)
    {
        return resource.Actions.Select(r => new Build_Action_Request(r).Result);
    }
}