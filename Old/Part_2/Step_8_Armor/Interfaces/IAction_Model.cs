namespace Interfaces;

public interface IAction_Model
{
    IHp_Model Owner { get; }
    ITimer_Model Cooldown { get; }
    string Name { get; }

    void Do(IHp_Model target);
    bool Can_Do(IHp_Model target);
}