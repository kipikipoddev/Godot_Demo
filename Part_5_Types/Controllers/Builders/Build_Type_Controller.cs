using System;
using System.Collections.Generic;
using Components_Namespace;
using Core;
using Requests;
using Resources;

namespace Controllers;

public class Build_Type_Controller
{
    private readonly Dictionary<string, Type_Component> types;

    public Build_Type_Controller()
    {
        types = new();
        Mediator.Add_Handler<Build_Type_Request, Type_Component>(Build_Type_Handler);
    }

    private Type_Component Build_Type_Handler(Build_Type_Request req)
    {
        var type = new Type_Component(req.Resource.Name, req.Resource.Color, () => types[req.Resource.Parent.Name]);
        types[req.Resource.Name] = type;
        return type;
    }
}