namespace Components_Namespace;

public record Hp_Change_Action_Component(int Amount, bool Is_Friendly) : Action_Component(Is_Friendly)
{
}