using Components_Namespace;
using Core;
using Requests;
using Resources;

namespace Controllers;

public class Build_Action_Controller
{
    public Build_Action_Controller()
    {
        Mediator.Add_Handler<Build_Action_Request, Components>(Build_Action_Handler);
    }

    private Components Build_Action_Handler(Build_Action_Request req)
    {
        var res = req.Resource;
        var action = new Components()
            .Set(new Name_Component(res.Name))
            .Set(new Build_Type_Request(res.Type).Result)
            .Set(new Timer_Component(res.Cooldown));

        if (res is Attack_Resource attack)
            action.Set(new Hp_Change_Action_Component(-attack.Damage, false, true));

        else if (res is Heal_Resource heal)
            action.Set(new Hp_Change_Action_Component(heal.Heal, true, true));

        else if (res is Rise_Resource)
            action.Set(new Rise_Action_Component());

        else if (res is Revive_Resource revive)
            action.Set(new Hp_Change_Action_Component(revive.To_Hp, true, false));

        else if (res is Shield_Resource shield)
            action.Set(new Shield_Action_Component(shield.Amount));

        if (res is Hot_Resource hot)
            action.Set(new Over_Time_Component(hot.Time_Between, hot.Times));
        if (res is Dot_Resource dot)
            action.Set(new Over_Time_Component(dot.Time_Between, dot.Times));

        return action;
    }
}