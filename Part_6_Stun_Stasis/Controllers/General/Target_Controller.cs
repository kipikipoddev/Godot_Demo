using System.Collections.Generic;
using System.Linq;
using Core;
using Interfaces;
using Messages;
using Requests;

namespace Controllers;

public class Target_Controller
{
    private readonly List<IEntity_Model> entities;

    public Target_Controller()
    {
        Mediator.Add_Handler<Get_Target_Request, IEntity_Model>(Get_Target_Handler);
        Mediator.Add_Listener<Entity_Created_Message>(Entity_Created_Listener);
        entities = new();
    }

    private void Entity_Created_Listener(Entity_Created_Message message)
    {
        entities.Add(message.Entity);
    }

    private IEntity_Model Get_Target_Handler(Get_Target_Request req)
    {
        return entities.Where(c => Can_Action(req, c)).FirstOrDefault();
    }

    private static bool Can_Action(Get_Target_Request req, IEntity_Model c)
    {
        return new Can_Action_Request(req.Action, c).Result;
    }

}