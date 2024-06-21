using Models;
using Core;
using Requests;
using Resources;
using Interfaces;

namespace Controllers;

public class Build_Entity_Controller
{
    public Build_Entity_Controller()
    {
        Mediator.Add_Handler<Create_Entity_Request, IEntity_Model>(Build_Entity_Handler);
    }

    private IEntity_Model Build_Entity_Handler(Create_Entity_Request req)
    {
        return new Entity_Model(req.Resource, Action_Mapper);
    }

    private IAction_Model Action_Mapper(Action_Resource resource)
    {
        if (resource is Attack_Resource attack)
            return new Attack_Action_Model(attack);
        else if (resource is Heal_Resource heal)
            return new Heal_Action_Model(heal);
        return null;
    }
}