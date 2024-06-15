using Components_Namespace;
using Core;
using Requests;

namespace Controllers;

public class Create_Entity_Controller
{
    public Create_Entity_Controller()
    {
        Mediator.Set_Handler<Create_Entity_Request, Components>(Create_Entity_Handler);
    }

    private Components Create_Entity_Handler(Create_Entity_Request request)
    {
        var resource = request.Resource;
        return new Components()
              .Set(new Name_Component(resource.Name))
              .Set(new Hp_Component(resource.Hp))
              .Set(new Attack_Component(resource.Attack.Name, resource.Attack.Damage));
    }
}