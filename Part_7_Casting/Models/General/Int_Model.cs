namespace Models;

public class Int_Model : Value_Model<int>
{
    public Int_Model(int max)
        : base(0, max)
    {
    }
    public override string ToString()
    {
        return $"{Value:d2} / {Max:d2}";
    }
}