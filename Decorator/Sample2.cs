namespace Decorator
{

    public class Sample2
    {
        public void Test()
        {
            // Create simple coffee
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine(coffee.GetDescription() + " $" + coffee.GetCost());

            // Change it by adding milk on top
            coffee = new LatteCofeeDecorator(coffee);
            Console.WriteLine(coffee.GetDescription() + " $" + coffee.GetCost());

        }

        // Component interface
        public interface ICoffee
        {
            string GetDescription();
            double GetCost();
        }


        // Concrete Component
        class SimpleCoffee : ICoffee
        {
            public string GetDescription()
            {
                return "Simple Coffee";
            }

            public double GetCost()
            {
                return 1.0;
            }
        }

      
        // Decorator
        abstract class CoffeeDecorator : ICoffee
        {
            protected ICoffee _coffee;

            public CoffeeDecorator(ICoffee coffee)
            {
                _coffee = coffee;
            }

            public virtual string GetDescription()
            {
                return _coffee.GetDescription();
            }

            public virtual double GetCost()
            {
                return _coffee.GetCost();
            }
        }

        // Concrete Decorator
        class LatteCofeeDecorator : CoffeeDecorator
        {
            public LatteCofeeDecorator(ICoffee coffee) : base(coffee) { }

            public override string GetDescription()
            {
                return $"{base.GetDescription()}, Milk";
            }

            public override double GetCost()
            {
                return base.GetCost() + 0.5;
            }
        }

    }

  
}
