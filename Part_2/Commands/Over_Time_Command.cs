using Components_Namespace;
using Core;

namespace Commands;

public record Over_Time_Command(Components Model, Components Target) : Command
{
    public int Activated { get; set; }

    public virtual bool Equals(Over_Time_Command? other)
    {
        if (other is null) return false;
        return Target == other.Target & Model.Get_Name() == other.Model.Get_Name();
    }

    public override int GetHashCode()
    {
        return Target.GetHashCode() + Model.Get_Name().GetHashCode();
    }
}
