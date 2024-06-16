namespace Inherent_Problem_P2;

public class Class_A
{
    public void A() { }
}

public class Class_B
{
    public void B() { }
}

public record Class_AB(Class_A a, Class_B b)
{
}

public class Runner
{
    public void Method(Class_AB class_ab)
    {
        class_ab.a.A();
        if (class_ab.b != null)
            class_ab.b.B();
    }
}