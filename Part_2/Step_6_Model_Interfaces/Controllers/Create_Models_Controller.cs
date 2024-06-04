using System.Linq;
using Godot;
using Interfaces;
using Messages;
using Models;
using Resources;

namespace Controllers;

public class Create_Models_Controller
{
    public Create_Models_Controller()
    {
        Create_Entity_Model_Request.Handler = Create_Entity_Model_Request_Handler;
    }

    private IEntity_Model Create_Entity_Model_Request_Handler(Create_Entity_Model_Request request)
    {
        var entity = new Entity_Model(request.Resource);
        entity.Actions.AddRange(request.Resource.Actions
                 .Select(r => Get_Model(r, entity)));
        return entity;
    }

    private IAction_Model Get_Model(Resource resource, IEntity_Model entity)
    {
        if (resource is Dot_Resource)
            return new Dot_Attack_Model(entity, resource as Dot_Resource);
        if (resource is Attack_Resource)
            return new Attack_Model(entity, resource as Attack_Resource);
        if (resource is Heal_Resource)
            return new Heal_Model(entity, resource as Heal_Resource);
        return null;
    }
}