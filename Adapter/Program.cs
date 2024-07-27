class Program
{
    static void Main(string[] args)
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new SomethingAdapter(adaptee);

        Console.WriteLine("Adaptee interface is incompatible with the client.");
        Console.WriteLine("But with adapter client can call it's method.");

        Console.WriteLine(target.GetRequest());
    }
}

// The Target defines the domain-specific interface used by the client code.


// The Adaptee contains some useful behavior, but its interface is
// incompatible with the existing client code. The Adaptee needs some
// adaptation before the client code can use it.
class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request.";
    }
}

public interface ITarget
{
    string GetRequest();
}

// The Adapter makes the Adaptee's interface compatible with the Target's
// interface.
class SomethingAdapter : ITarget
{
    private readonly Adaptee _adaptee;

    public SomethingAdapter(Adaptee adaptee)
    {
        this._adaptee = adaptee;
    }

    public string GetRequest()
    {
        Console.WriteLine("Some adapter operations...");
        return $"This is '{this._adaptee.GetSpecificRequest()}'";
    }
}

