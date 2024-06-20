using System;
using System.Collections.Generic;
using System.Linq;
using Components_Namespace;
using Core;
using Messages;

namespace Controllers;

public class Target_Controller
{
    private readonly Dictionary<int, List<Components>> group_to_entity;

    public Target_Controller()
    {
        Mediator.Add_Handler<Get_Target_Request, Components>(Get_Target_Handler);
        Mediator.Add_Listener<Entity_Created_Message>(Entity_Created_Listener);
        group_to_entity = new();
    }

    private void Entity_Created_Listener(Entity_Created_Message message)
    {
        var group = message.Entity.Group();
        if (!group_to_entity.ContainsKey(group))
            group_to_entity[group] = new();
        group_to_entity[group].Add(message.Entity);
    }

    private Components Get_Target_Handler(Get_Target_Request request)
    {
        var group = request.Action.Parent.Parent.Group();
        var is_friendly = request.Action.Is_Friendly;
        var target_group = Get_Group(group, is_friendly);
        return Get_Random(group_to_entity[target_group]);
    }

    private int Get_Group(int group, bool is_friendly)
    {
        return is_friendly ?
            group :
            group_to_entity.Keys.First(k => k != group);
    }

    private Components Get_Random(IEnumerable<Components> entities)
    {
        entities = entities.Where(e => e.Hp().Is_Alive);
        if (!entities.Any())
            return null;
        return entities.OrderBy(x => Guid.NewGuid()).First();
    }
}