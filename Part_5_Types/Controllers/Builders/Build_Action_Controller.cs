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
            .Set(new Timer_Component(res.Cooldown));

        if (res is Attack_Resource attack)
            action.Set(new Hp_Change_Action_Component(false, true))
                .Set(new Amount_Component(-attack.Damage, res.Type));

        else if (res is Heal_Resource heal)
            action.Set(new Hp_Change_Action_Component(true, true))
                .Set(new Amount_Component(heal.Heal, res.Type));

        else if (res is Rise_Resource rise)
            action.Set(new Rise_Action_Component())
                .Set(new Amount_Component(rise.To_Hp, res.Type));

        else if (res is Revive_Resource revive)
            action.Set(new Hp_Change_Action_Component(true, false))
                .Set(new Amount_Component(revive.To_Hp, res.Type));

        else if (res is Shield_Resource shield)
            action.Set(new Shield_Action_Component())
                .Set(new Amount_Component(shield.Amount, res.Type));

        if (res is Hot_Resource hot)
            action.Set(new Over_Time_Component(hot.Time_Between, hot.Times));
        if (res is Dot_Resource dot)
            action.Set(new Over_Time_Component(dot.Time_Between, dot.Times));

        return action;
    }
}