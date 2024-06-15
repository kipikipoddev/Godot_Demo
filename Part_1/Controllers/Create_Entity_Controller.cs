using Commands;
using Components_Namespace;
using Core;
using Requests;
using Resources;

namespace Controllers;

public class Create_Entity_Controller
{
    public Create_Entity_Controller()
    {
        Mediator.Set_Handler<Create_Entity_Request, Components>(Create_Entity_Model_Request_Handler);
    }

    private Components Create_Entity_Model_Request_Handler(Create_Entity_Request request)
    {
        var entity = new Components()
             .Set_Name(request.Resource.Name)
             .Set_Hp(request.Resource.Hp);
        entity.Add_Action(Get_Attack_Component(request.Resource.Attack, entity));
        return entity;
    }

    private Components Get_Attack_Component(Attack_Resource resource, Components entity)
    {
        var attack_action = new Components()
            .Set_Name(resource.Name)
            .Set_Amount(resource.Damage);
        attack_action.Parent = entity;
        attack_action
            .Set_Can_Action(c => new Can_Attack_Request(attack_action, c).Result)
            .Set_Do_Action(c => new Attack_Command(attack_action, c));
        return attack_action;
    }
}