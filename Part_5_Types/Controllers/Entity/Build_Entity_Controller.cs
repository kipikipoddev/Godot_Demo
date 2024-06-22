using Models;
using Core;
using Requests;
using Resources;
using Interfaces;
using Messages;
using System.Linq;

namespace Controllers;

public class Build_Entity_Controller
{
    public Build_Entity_Controller()
    {
        Mediator.Add_Handler<Create_Entity_Request, IEntity_Model>(Build_Entity_Handler);
    }

    private IEntity_Model Build_Entity_Handler(Create_Entity_Request req)
    {
        var actions = req.Resource.Actions.Select(Action_Mapper).ToArray();
        var armor = req.Resource.Armor.Select(r => new Armor_Model(r)).ToArray();
        var entity = new Entity_Model(req.Resource, req.Group, actions, armor);
        new Entity_Created_Message(entity);
        return entity;
    }

    private IAction_Model Action_Mapper(Action_Resource resource)
    {
        if (resource is Dot_Resource dot)
            return new Dot_Action_Model(dot);
        else if (resource is Hot_Resource hot)
            return new Hot_Action_Model(hot);
        else if (resource is Shield_Resource shield)
            return new Shield_Action_Model(shield);
        else if (resource is Attack_Resource attack)
            return new Attack_Action_Model(attack);
        else if (resource is Heal_Resource heal)
            return new Heal_Action_Model(heal);
        else if (resource is Revive_Resource revive)
            return new Revive_Action_Model(revive);
        else if (resource is Rise_Resource rise)
            return new Rise_Action_Model(rise);
        return null;
    }
}