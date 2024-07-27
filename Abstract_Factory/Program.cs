// The Abstract Factory interface declares a set of methods that return
// different abstract products. These products are called a family and are
// related by a high-level theme or concept. Products of one family are
// usually able to collaborate among themselves. A family of products may
// have several variants, but the products of one variant are incompatible
// with products of another.




class Program
{
    static void Main(string[] args)
    {
        var factory = new ConcreteFactory1();
        var productA = factory.CreateProductA();
        var productB = factory.CreateProductB();

        Console.WriteLine(productA.OperationA());
        Console.WriteLine(productB.OperationB());
        Console.WriteLine(productB.AnotherOperationB(productA));
    }
}


#region Abstract Products
// Each distinct product of a product family should have a base interface.
// All variants of the product must implement this interface.
public interface IAbstractProductA
{
    string OperationA();
}

// Here's the the base interface of another product. All products can
// interact with each other, but proper interaction is possible only between
// products of the same concrete variant.
public interface IAbstractProductB
{
    // Product B is able to do its own thing...
    string OperationB();

    // ...but it also can collaborate with the ProductA.
    //
    // The Abstract Factory makes sure that all products it creates are of
    // the same variant and thus, compatible.
    string AnotherOperationB(IAbstractProductA collaborator);
}

#endregion

#region Concrete Products

// Concrete Products are created by corresponding Concrete Factories.
class ConcreteProductA1 : IAbstractProductA
{
    public string OperationA()
    {
        return "The result of the product A1.";
    }
}


class ConcreteProductA2 : IAbstractProductA
{
    public string OperationA()
    {
        return "The result of the product A2.";
    }
}


// Concrete Products are created by corresponding Concrete Factories.
class ConcreteProductB1 : IAbstractProductB
{
    public string OperationB()
    {
        return "The result of the product B1.";
    }

    // The variant, Product B1, is only able to work correctly with the
    // variant, Product A1. Nevertheless, it accepts any instance of
    // AbstractProductA as an argument.
    public string AnotherOperationB(IAbstractProductA collaborator)
    {
        var result = collaborator.OperationA();

        return $"The result of the B1 collaborating with the ({result})";
    }
}

class ConcreteProductB2 : IAbstractProductB
{
    public string OperationB()
    {
        return "The result of the product B2.";
    }

    public string AnotherOperationB(IAbstractProductA collaborator)
    {
        var result = collaborator.OperationA();

        return $"The result of the B2 collaborating with the ({result})";
    }
}

#endregion

#region Abstract Factory
public interface IAbstractFactory
{
    IAbstractProductA CreateProductA();

    IAbstractProductB CreateProductB();
}

#endregion

#region Concrete Factories
// Concrete Factories produce a family of products that belong to a single
// variant. The factory guarantees that resulting products are compatible.
// Note that signatures of the Concrete Factory's methods return an abstract
// product, while inside the method a concrete product is instantiated.
class ConcreteFactory1 : IAbstractFactory
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IAbstractProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

// Each Concrete Factory has a corresponding product variant.
class ConcreteFactory2 : IAbstractFactory
{
    public IAbstractProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public IAbstractProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}

#endregion

