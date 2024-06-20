

namespace Inherent_Problem_P3;

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
    private readonly Int_B b;

    public Class_C(Int_B b)
    {
        this.b = b;
    }

    public void B()
    {
        b.B();
    }
}

public class Runner
{
    public void Method1(Class_C class_c)
    {
        class_c.A();
        class_c.B();
    }

    public void Method2<T>(T obj)
        where T : Int_A, Int_B
    {
        obj.A();
        obj.B();
    }
}