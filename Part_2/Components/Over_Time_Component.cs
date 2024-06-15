using Core;

namespace Components_Namespace;

public record Over_Time_Component(int Time_between, int Times, bool Is_heal) : Component
{
}

public static class Components_Over_Time_Extension
{
    public static Over_Time_Component Over_Time(this Components components)
    {
        return components.Get<Over_Time_Component>();
    }
}