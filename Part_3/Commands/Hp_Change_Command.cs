using Core;

namespace Commands;

public record Hp_Change_Command : Command
{
    public Components Target { get; }
    public int Amount { get; set; }

    public Hp_Change_Command(Components target, int amount)
        : base(false)
    {
        Target = target;
        Amount = amount;
        Invoke();
    }
}
