using Core;

namespace Components_Namespace;

public static class Name_Component
{
    private static readonly string Key = "Name_Component";

    public static Components Set_Name(this Components comp, string name)
    {
        comp.Set(Key, name);
        return comp;
    }

    public static string Get_Name(this Components comp)
    {
        return comp.Get<string>(Key);
    }
}