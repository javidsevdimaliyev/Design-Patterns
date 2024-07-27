// The AbstractBuilder interface specifies methods for creating the different parts
// of the Product objects.

class Program
{
    static void Main(string[] args)
    {
        // The client code creates a builder object, passes it to the
        // director and then initiates the construction process. The end
        // result is retrieved from the builder object.
        ProductDirector director = new();
        var product = director.Build(new Product1Builder());
    }
}

// It makes sense to use the AbstractBuilder pattern only when your products are
// quite complex and require extensive configuration.
//
// Unlike in other creational patterns, different concrete builders can
// produce unrelated products. In other words, results of various builders
// may not always follow the same interface.

//Product
public class Product
{
    public string Name { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }


}

//Abstract AbstractBuilder
public abstract class AbstractBuilder
{
    public Product Product { get; private set; }
    public AbstractBuilder() => Product = new Product();

    public abstract AbstractBuilder SetName();
    public abstract AbstractBuilder SetModel();
    public abstract AbstractBuilder SetPrice();

}

// The Concrete Builder classes follow the Builder interface and provide
// specific implementations of the building steps. Your program may have
// several variations of Builders, implemented differently.

//Concrete Builder
public class Product1Builder : AbstractBuilder
{
    public override AbstractBuilder SetModel()
    {
        Product.Model = "";
        return this;
    }

    public override AbstractBuilder SetName()
    {
        Product.Name = "";
        return this;
    }

    public override AbstractBuilder SetPrice()
    {
        Product.Price = 40000;
        return this;
    }
}

public class Product2Builder : AbstractBuilder
{
    public override AbstractBuilder SetModel()
    {
        Product.Model = "";
        return this;
    }

    public override AbstractBuilder SetName()
    {
        Product.Name = "";
        return this;
    }

    public override AbstractBuilder SetPrice()
    {
        Product.Price = 38000;
        return this;
    }
}


// The Director is only responsible for executing the building steps in a
// particular sequence. It is helpful when producing products according to a
// specific order or configuration. Strictly speaking, the Director class is
// optional, since the client can control builders directly.
public class ProductDirector
{
    public Product Build(AbstractBuilder builder)
    {
        builder.SetModel()
               .SetName()
               .SetPrice();
        return builder.Product;
    }
}

