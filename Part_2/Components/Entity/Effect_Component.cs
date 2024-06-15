using Core;

namespace Components_Namespace;

public record Effect_Component : Components
{
    public int Left { get; set; }
    public Action_Components Action { get; }

    public Effect_Component(Action_Components action)
    {
        var over_time = action.Over_Time();
        Set(new Timer_Component(over_time.Time_between));
        Left = over_time.Times;
        Action = action;
    }
}