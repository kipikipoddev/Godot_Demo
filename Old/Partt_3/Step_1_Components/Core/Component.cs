namespace Core;

public abstract record Component
{
    public Components Owner { get; set; }
}