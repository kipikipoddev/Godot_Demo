using System.Linq;
using Commands;
using Components_Namespace;
using Core;
using Messages;
using Resources;

namespace Controllers;

public class Create_Models_Controller
{
    public Create_Models_Controller()
    {
        Create_Entity_Model_Request.Handler = Create_Entity_Model_Request_Handler;
    }

    private Components Create_Entity_Model_Request_Handler(Create_Entity_Model_Request request)
    {
        var entity = new Components()
            .Set(new Name_Component(request.Resource.Name))
            .Set(new Hp_Component(request.Resource.Hp))
            .Set(new Armor_Component(request.Resource.Armor));

        entity.Add_Range(request.Resource.Actions.Select(Create_Action_Model));
        return entity;
    }

    private Action_Component Create_Action_Model(Action_Resource resource)
    {
        var action = new Action_Component();
        action.Set(new Name_Component(resource.Name))
            .Set(new Timer_Component(resource.Cooldown));

        if (resource is Attack_Resource)
            action.Set(new Amount_Component((resource as Attack_Resource).Damage))
                .Set(new Do_Action_Component(c => new Attack_Command(action, c)))
                .Set(new Can_Action_Component(c => new Can_Action_Request(action, c).Result));

        if (resource is Dot_Resource dot)
            action.Set(new Over_Time_Component(dot.Time_Between, dot.Times, false))
                .Set(new Do_Action_Component(c => new Over_Time_Command(action, c)));

        if (resource is Heal_Resource)
            action.Set(new Amount_Component((resource as Heal_Resource).Heal))
                .Set(new Do_Action_Component(c => new Heal_Command(action, c)))
                .Set(new Can_Action_Component(c => new Can_Action_Request(action, c).Result));

        if (resource is Hot_Resource hot)
            action.Set(new Over_Time_Component(hot.Time_Between, hot.Times, true))
                .Set(new Do_Action_Component(c => new Over_Time_Command(action, c)));

        if (resource is Shield_Resource)
            action.Set(new Amount_Component((resource as Shield_Resource).Amount))
                .Set(new Do_Action_Component(c => new Shield_Command(action, c)))
                .Set(new Can_Action_Component(c => new Can_Action_Request(action, c).Result));

        return action;
    }
}