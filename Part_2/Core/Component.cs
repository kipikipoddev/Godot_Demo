namespace Core;

public abstract record Component
{
    public Components Parent { get; set; }
}