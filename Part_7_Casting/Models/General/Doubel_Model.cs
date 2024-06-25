namespace Models;

public class Doubel_Model : Value_Model<double>
{
    public Doubel_Model(double max)
        : base(0, max)
    {
    }
    
    public override string ToString()
    {
        return Value.ToString("0.0");
    }
}