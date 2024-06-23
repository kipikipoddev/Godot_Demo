using System.Linq;
using Interfaces;
using Resources;

namespace Models;

public class Armor_Model : IAmount_Model
{
    public Type_Resource Type { get; }
    public int Amount { get; }
    public bool Is_Positive => true;

    public Armor_Model(Armor_Resource resource)
    {
        Type = resource.Type;
        Amount = resource.Amount;
    }
}