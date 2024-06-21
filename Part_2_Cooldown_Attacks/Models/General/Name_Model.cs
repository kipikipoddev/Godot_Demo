using Interfaces;
using Resources;

namespace Models;

public class Name_Model : IName_Model
{
    public string Name { get; }

    public Name_Model(Named_Resource resource)
    {
        Name = resource.Name;
    }
}