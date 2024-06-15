using Commands;
using Components_Namespace;
using Core;
using Messages;
using Resources;
using Singletons;

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
            .Set(new Name_Component(request.Resource.Name))
            .Set(new Hp_Component(request.Resource.Hp));

        entity.Set(Create_Attack_Component(request.Resource.Attack));
        return entity;
    }

    private Attack_Component Create_Attack_Component(Attack_Resource resource)
    {
        return new Attack_Component(resource.Name, resource.Damage);
    }
}