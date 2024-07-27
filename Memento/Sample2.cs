using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    /*
        The user adds items to a shopping cart.
        They may modify the cart by removing or changing the quantity of items.
        If the user accidentally empties the cart or wants to revert to a previous state,
        they can press an "Undo" button to revert.

        Problem:
        To track every change the user makes and allow easy reversion to a previous state when needed.

        Solution:
        By using the Memento design pattern, we can save each state of the shopping cart and revert to that saved state when necessary.
     */
    internal class Sample2
    {
        public void Test()
        {
            // Create a shopping cart
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem("Apple");
            cart.AddItem("Pear");
            cart.AddItem("Grapes");

            // Create a caretaker
            ShoppingCartCareTaker careTaker = new ShoppingCartCareTaker();

            // Save the initial state
            careTaker.Memento = cart.Save();

            // Print the cart items
            cart.PrintItems();

            // Remove an item from the cart
            cart.RemoveItem("Pear");

            // Print the updated cart items
            cart.PrintItems();

            // Revert to the previous state
            cart.Restore(careTaker.Memento);

            // Print the reverted cart items
            cart.PrintItems();

            Console.ReadLine();
        }

        // Originator class - The class that holds the state of the shopping cart
        class ShoppingCart
        {
            private List<string> items;

            public ShoppingCart()
            {
                items = new List<string>();
            }

            public void AddItem(string item)
            {
                items.Add(item);
            }

            public void RemoveItem(string item)
            {
                items.Remove(item);
            }

            public void PrintItems()
            {
                Console.WriteLine("Items in the cart:");
                foreach (var item in items)
                {
                    Console.WriteLine("- " + item);
                }
                Console.WriteLine();
            }

            // Create a memento
            public ShoppingCartMemento Save()
            {
                return new ShoppingCartMemento(new List<string>(items));
            }

            // Load a memento
            public void Restore(ShoppingCartMemento memento)
            {
                this.items = new List<string>(memento.GetItems());
            }
        }

        // Caretaker class - The class that stores and restores mementos
        class ShoppingCartCareTaker
        {
            private ShoppingCartMemento memento;

            public ShoppingCartMemento Memento
            {
                get { return memento; }
                set { memento = value; }
            }
        }

        // Memento class - The class that holds the state of the shopping cart
        class ShoppingCartMemento
        {
            private List<string> items;

            public ShoppingCartMemento(List<string> items)
            {
                this.items = items;
            }

            public List<string> GetItems()
            {
                return items;
            }
        }
    }
}
