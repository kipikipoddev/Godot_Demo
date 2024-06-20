using Components_Namespace;
using Core;
using Requests;
using Resources;

namespace Controllers;

public class Create_Action_Controller
{
    public Create_Action_Controller()
    {
        Mediator.Add_Handler<Create_Action_Request, Components>(Create_Action_Handler);
    }

    private Components Create_Action_Handler(Create_Action_Request req)
    {
        var res = req.Resource;
        var action = new Components()
            .Set(new Name_Component(res.Name))
            .Set(new Timer_Component(res.Cooldown));

        if (res is Attack_Resource attack)
            action.Set(new Hp_Change_Action_Component(-attack.Damage, false));

        else if (res is Heal_Resource heal)
            action.Set(new Hp_Change_Action_Component(heal.Heal, true));

        else if (res is Rise_Resource)
            action.Set(new Hp_Change_Action_Component(1, false));

        else if (res is Revive_Resource revive)
            action.Set(new Hp_Change_Action_Component(revive.To_Hp, true));

        else if (res is Shield_Resource shield)
            action.Set(new Shield_Action_Component(shield.Amount));

        if (res is Hot_Resource hot)
            action.Set(new Over_Time_Component(hot.Time_Between, hot.Times));
        if (res is Dot_Resource dot)
            action.Set(new Over_Time_Component(dot.Time_Between, dot.Times));

        return action;
    }
}