
using Decorator;

class Program
{
    static void Main(string[] args)
    {
        Sample3 s = new();
        s.Test();
        var simple = new Component();
        Console.WriteLine("RESULT: " + simple.Operation());
        Console.WriteLine();

        // ...as well as decorated ones.
        //
        // Note how decorators can wrap not only simple components but the
        // other decorators as well.
        ConcreteDecoratorA decorator1 = new (simple);
        ConcreteDecoratorB decorator2 = new (decorator1);

        Console.WriteLine("RESULT: " + decorator2.Operation());
    }

}

// The base AbstractComponent interface defines operations that can be altered by
// decorators.
public interface IComponent
{
    public string Operation();
}

// Concrete Components provide default implementations of the operations.
// There might be several variations of these classes.
class Component : IComponent
{
    public string Operation()
    {
        return "ConcreteComponent";
    }
}

// The base Decorator class follows the same interface as the other
// components. The primary purpose of this class is to define the wrapping
// interface for all concrete decorators. The default implementation of the
// wrapping code might include a field for storing a wrapped component and
// the means to initialize it.
abstract class AbstractDecorator : IComponent
{
    protected IComponent _component;

    public AbstractDecorator(IComponent component)
    {
        this._component = component;
    }

    public void SetComponent(IComponent component)
    {
        this._component = component;
    }

    // The Decorator delegates all work to the wrapped component.
    public string Operation()
    {
        if (this._component != null)
        {
            return this._component.Operation();
        }
        else
        {
            return string.Empty;
        }
    }
}

// Concrete Decorators call the wrapped object and alter its result in some
// way.
class ConcreteDecoratorA : AbstractDecorator
{
    public ConcreteDecoratorA(IComponent comp) : base(comp)
    {
    }

    // Decorators may call parent implementation of the operation, instead
    // of calling the wrapped object directly. This approach simplifies
    // extension of decorator classes.
    public new string Operation()
    {
        return $"ConcreteDecoratorA({base.Operation()})";
    }
}

// Decorators can execute their behavior either before or after the call to
// a wrapped object.
class ConcreteDecoratorB : AbstractDecorator
{
    public ConcreteDecoratorB(IComponent comp) : base(comp)
    {
    }

    public new string Operation()
    {
        return $"ConcreteDecoratorB({base.Operation()})";
    }
}

