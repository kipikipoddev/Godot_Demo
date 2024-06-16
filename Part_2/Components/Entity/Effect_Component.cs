using Core;

namespace Components_Namespace;

public record Effect_Component : Components
{
    public int Left { get; set; }
    public Command Command { get; }

    public Effect_Component(Action_Components action, Command command)
    {
        var over_time = action.Over_Time();
        Set(new Timer_Component(over_time.Time_between));
        Set(new Name_Component(action.Name()));
        Left = over_time.Times - 1;
        Command = command;
    }
}