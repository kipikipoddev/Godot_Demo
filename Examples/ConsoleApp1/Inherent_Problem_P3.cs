

namespace Inherent_Problem_P2;

public interface Int_A
{
    void A() { }
}

public class Class_A : Int_A
{
    public void A() { }
}

public interface Int_B
{
    void B() { }
}

public class Class_B : Int_B
{
    public void B() { }
}

public class Class_C : Class_A, Int_B
{
    private Int_B b;

    public Class_C(Int_B b)
    {
        this.b = b;
    }
    
    public void B()
    {
        if (B != null)
            b.B();
    }
}

public class Runner
{
    public void Method(Class_C class_C)
    {
        class_C.A();
        class_C.B();
    }
}