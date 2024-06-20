namespace Components_Namespace;

public record Hp_Change_Action_Component(int Amount, bool On_Friendly, bool On_Live_Target)
    : Action_Component(On_Friendly, On_Live_Target)
{
}