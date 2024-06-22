using System.Linq;
using Interfaces;
using Resources;

namespace Models;

public class Armor_Model : IArmor_Model
{
    public Type_Resource Type { get; }
    public int Amount { get; }

    public Armor_Model(Armor_Resource resource)
    {
        Type = resource.Type;
        Amount = resource.Amount;
    }
}