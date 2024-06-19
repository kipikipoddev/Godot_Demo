
public class Hp_Change_Data
{
    public int Amount { get; set; }
    public bool Is_Positive { get; set; }

    public Hp_Change_Data(int amount, bool is_positive)
    {
        Amount = amount;
        Is_Positive = is_positive;
    }
}