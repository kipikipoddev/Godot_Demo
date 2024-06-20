using System.Collections.Generic;
using System.Linq;
using Core;
using Messages;
using Requests;

namespace Controllers;

public class Target_Controller
{
    private readonly List<Components> comps;

    public Target_Controller()
    {
        Mediator.Add_Handler<Get_Target_Request, Components>(Get_Target_Handler);
        Mediator.Add_Listener<Components_Created_Message>(Entity_Created_Listener);
        comps = new();
    }

    private void Entity_Created_Listener(Components_Created_Message msg)
    {
        comps.Add(msg.Components);
    }

    private Components Get_Target_Handler(Get_Target_Request req)
    {
        return Get_Target(comps, req.Action.Parent);
    }

    private Components Get_Target(IEnumerable<Components> comps, Components action)
    {
        return comps.Where(c => new Can_Action_Request(action, c).Result).FirstOrDefault();
    }
}