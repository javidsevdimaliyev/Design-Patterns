
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Same client code can work with different subclasses:");

        new ConcreteClass1().TemplateMethod(); 

        Console.Write("\n");

        Console.WriteLine("Same client code can work with different subclasses:");
        new ConcreteClass2().TemplateMethod();
    }
}



// The Abstract Class defines a template method that contains a skeleton of
// some algorithm, composed of calls to (usually) abstract primitive
// operations.
//
// Concrete subclasses should implement these operations, but leave the
// template method itself intact.
abstract class AbstractClass
{
    // The template method defines the skeleton of an algorithm.
    public void TemplateMethod()
    {
        this.BaseOperation1();
        this.RequiredOperation1();
        this.BaseOperation2();
        this.Hook1();
        this.RequiredOperation2();
        this.BaseOperation3();
        this.Hook2();
    }

    // These operations already have implementations.
    protected void BaseOperation1()
    {
        Console.WriteLine("AbstractClass says: I am doing the bulk of the work");
    }

    protected void BaseOperation2()
    {
        Console.WriteLine("AbstractClass says: But I let subclasses override some operations");
    }

    protected void BaseOperation3()
    {
        Console.WriteLine("AbstractClass says: But I am doing the bulk of the work anyway");
    }

    // These operations have to be implemented in subclasses.
    protected abstract void RequiredOperation1();

    protected abstract void RequiredOperation2();

    // These are "hooks." Subclasses may override them, but it's not
    // mandatory since the hooks already have default (but empty)
    // implementation. Hooks provide additional extension points in some
    // crucial places of the algorithm.
    protected virtual void Hook1() { }

    protected virtual void Hook2() { }
}




// Concrete classes have to implement all abstract operations of the base
// class. They can also override some operations with a default
// implementation.
class ConcreteClass1 : AbstractClass
{
    protected override void RequiredOperation1()
    {
        Console.WriteLine("ConcreteClass1 says: Implemented Operation1");
    }

    protected override void RequiredOperation2()
    {
        Console.WriteLine("ConcreteClass1 says: Implemented Operation2");
    }

    protected override void Hook2()
    {
        Console.WriteLine("ConcreteClass1 says: Overridden Hook2");
    }
}

// Usually, concrete classes override only a fraction of base class'
// operations.
class ConcreteClass2 : AbstractClass
{
    protected override void RequiredOperation1()
    {
        Console.WriteLine("ConcreteClass2 says: Implemented Operation1");
    }

    protected override void RequiredOperation2()
    {
        Console.WriteLine("ConcreteClass2 says: Implemented Operation2");
    }

    protected override void Hook1()
    {
        Console.WriteLine("ConcreteClass2 says: Overridden Hook1");
    }
}

