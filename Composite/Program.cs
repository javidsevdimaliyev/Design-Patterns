using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create products
        var product1 = new Product("Product 1", 10);
        var product2 = new Product("Product 2", 20);

        // Create boxes
        var box1 = new Box();
        box1.AddComponent(product1);
        box1.AddComponent(product2);

        var innerBox = new Box();
        innerBox.AddComponent(new Product("Inner Product", 5));
        box1.AddComponent(innerBox);

        //Create order
        var order = new Box();
        order.AddComponent(box1);

        // Calculate and print total price
        decimal totalPrice = order.CalculatePrice();
        Console.WriteLine("Total Price: " + totalPrice);
    }
}

// Component interface
public interface IComponent
{
    decimal CalculatePrice();
}

// Leaf class - Represents individual products
public class Product : IComponent
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public decimal CalculatePrice()
    {
        return Price;
    }
}

// Composite class - Represents boxes
public class Box : IComponent
{
    private List<IComponent> _components = new List<IComponent>();

    public void AddComponent(IComponent component)
    {
        _components.Add(component);
    }

    public void RemoveComponent(IComponent component)
    {
        _components.Remove(component);
    }

    public decimal CalculatePrice()
    {
        decimal totalPrice = 0;

        foreach (var component in _components)
        {
            totalPrice += component.CalculatePrice();
        }

        return totalPrice;
    }
}
