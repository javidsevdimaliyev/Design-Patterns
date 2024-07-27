class Program
{
    static void Main(string[] args)
    {
        IImplementation implA = new ConcreteImplementationA();
        IImplementation implB = new ConcreteImplementationB();
        // The client code should be able to work with any pre-configured
        // abstraction-implementation combination.
        var abstraction = new ExtendedAbstraction(implB);
        var abstraction2 = new ExtendedAbstraction2(implA);
        abstraction.Operation();
        abstraction2.Operation();
        Console.WriteLine(); 
    }
}

// The Implementation defines the interface for all implementation classes.
// It doesn't have to match the Abstraction's interface. In fact, the two
// interfaces can be entirely different. Typically the Implementation
// interface provides only primitive operations, while the Abstraction
// defines higher- level operations based on those primitives.
public interface IImplementation
{
    string OperationImplementation();
}

#region Implementation
// Each Concrete Implementation corresponds to a specific platform and
// implements the Implementation interface using that platform's API.
class ConcreteImplementationA : IImplementation
{
    public string OperationImplementation()
    {
        return "ConcreteImplementationA: The result in platform A.\n";
    }
}

class ConcreteImplementationB : IImplementation
{
    public string OperationImplementation()
    {
        return "ConcreteImplementationB: The result in platform B.\n";
    }
}
#endregion


#region Abstraction
// The Abstraction defines the interface for the "control" part of the two
// class hierarchies. It maintains a reference to an object of the
// Implementation hierarchy and delegates all of the real work to this
// object.
abstract class Abstraction
{
    protected IImplementation _implementation;

    public Abstraction(IImplementation implementation)
    {
        this._implementation = implementation;
    }

    public abstract string Operation();

}

// You can extend the Abstraction without changing the Implementation
// classes.
class ExtendedAbstraction : Abstraction
{
    public ExtendedAbstraction(IImplementation implementation) : base(implementation)
    {
    }

    public override string Operation()
    {
        _implementation.OperationImplementation();
        return "ExtendedAbstraction: Extended operation with:\n";
    }
}


class ExtendedAbstraction2 : Abstraction
{
    public ExtendedAbstraction2(IImplementation implementation) : base(implementation)
    {
    }

    public override string Operation()
    {
        _implementation.OperationImplementation();
        return "ExtendedAbstraction2: Extended operation with:\n";
    }
}
#endregion



