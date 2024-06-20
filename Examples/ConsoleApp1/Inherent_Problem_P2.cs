namespace Inherent_Problem_P2;

public class Class_A
{
    public void A() { }
}

public class Class_B
{
    public void B() { }
}

public record Class_AB(Class_A A, Class_B B)
{
}

public class Runner
{
    public void Method(Class_AB class_ab)
    {
        class_ab.A.A();
        class_ab.B?.B();
    }
}