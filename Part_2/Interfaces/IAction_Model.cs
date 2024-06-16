using Core;

namespace Interfaces;

public interface IAction_Model : IName_Model
{
    ITimer_Model Coolown { get; }

    bool Can(IHp_Model target);

    Command Do(IHp_Model target);
}