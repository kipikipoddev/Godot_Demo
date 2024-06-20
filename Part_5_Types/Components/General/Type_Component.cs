using System;
using Core;
using Godot;

namespace Components_Namespace;

public record Type_Component(string Name, Color Color, Func<Type_Component> Get_Upper) : Component
{
}

public static class Components_Type_Extension
{
    public static Type_Component Type(this Components components)
    {
        return components.Get<Type_Component>();
    }
}