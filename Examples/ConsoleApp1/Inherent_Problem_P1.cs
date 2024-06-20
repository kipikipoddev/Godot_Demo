
namespace Inherent_Problem_P1;

public class Class_A
{
    public void A() { }
}

public class Class_B
{
    public void B() { }
}

public class Runner
{
    public void Method(Class_A obj_a, Class_B obj_b)
    {
        obj_a.A();
        obj_b?.B();
    }
}