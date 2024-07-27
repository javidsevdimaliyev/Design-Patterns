using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    //Of course, the Template Method design pattern is a behavioural design pattern and defines the skeleton of an algorithm, 
    //but leaves the implementation of certain steps of this algorithm to subclasses.
    //This pattern allows many subclasses to show different behaviour using the same basic algorithm.
    internal class Sample2
    {
        public void Test()
        {
            Console.WriteLine("Making Coffee:");
            Coffee coffee = new();
            coffee.PrepareDrink();

            Console.WriteLine("\nMaking Tea:");
            Tea tea = new();
            tea.PrepareDrink();
        }

        // Abstract class which defining the Template method
        public abstract class HotDrink
        {
            // Template method
            public void PrepareDrink()
            {
                BoilWater();
                Brew();
                PourInCup();
                AddCondiments();
            }

           
            // Concrete methods
            void BoilWater()
            {
                Console.WriteLine("Boiling water");
            }

            void PourInCup()
            {
                Console.WriteLine("Pouring into cup");
            }

            // Abstract methods to be implemented by subclasses
            protected abstract void Brew();
            protected abstract void AddCondiments();
        }

        // Concrete subclass for Coffee
        class Coffee : HotDrink
        {
            protected override void Brew()
            {
                Console.WriteLine("Dripping Coffee through filter");
            }

            protected override void AddCondiments()
            {
                Console.WriteLine("Adding Sugar and Milk");
            }
        }

        // Concrete subclass for Tea
        class Tea : HotDrink
        {
            protected override void Brew()
            {
                Console.WriteLine("Steeping the tea");
            }

            protected override void AddCondiments()
            {
                Console.WriteLine("Adding Lemon");
            }
        }

    }
}
