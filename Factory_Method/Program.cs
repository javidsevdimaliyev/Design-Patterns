// The Creator class declares the factory method that is supposed to return
// an object of a Product class. The Creator's subclasses usually provide
// the implementation of this method.

class Program
{
    static void Main(string[] args)
    {
        var factory = new ConcreteFactory1();
        var product = factory.CreateInstance();
        Console.WriteLine(product.Operation());
    }
}

#region Abstract Product
// The Product interface declares the operations that all concrete products
// must implement.
public interface IProduct
{
    string Operation();
}
#endregion

#region Concrete Products
// Concrete Products provide various implementations of the Product
// interface.
class ConcreteProduct1 : IProduct
{
    public string Operation()
    {
        return "{Operation Result of ConcreteProduct1}";
    }
}

class ConcreteProduct2 : IProduct
{
    public string Operation()
    {
        return "{Operation Result of ConcreteProduct2}";
    }
}


#endregion

#region Abstract Factory
abstract class AbstractFactory
{
    // Note that the Creator may also provide some default implementation of
    // the factory method.
    public abstract IProduct CreateInstance();

}

#endregion

#region Concrete Factories

// Concrete Creators override the factory method in order to change the
// resulting product's type.
class ConcreteFactory1 : AbstractFactory
{
    // Note that the signature of the method still uses the abstract product
    // type, even though the concrete product is actually returned from the
    // method. This way the Creator can stay independent of concrete product
    // classes.
    public override IProduct CreateInstance()
    {
        return new ConcreteProduct1();
    }
}

class ConcreteFactory2 : AbstractFactory
{
    public override IProduct CreateInstance()
    {
        return new ConcreteProduct2();
    }
}


#endregion




