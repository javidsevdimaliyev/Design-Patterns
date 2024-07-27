using System.Collections;

namespace Iterator
{
    internal class Sample2
    {
        public void Test()
        {
            // Creating menu items
            MenuItem[] items = new MenuItem[]
            {
            new MenuItem("Kabab", 20),
            new MenuItem("Xash", 10),
            new MenuItem("Plov", 15)
            };

            // Creating menu
            MenuList menu = new MenuList(items);

            // Iterating through the menu and printing each item
            foreach (MenuItem item in menu)
            {
                Console.WriteLine("Dish Name: " + item.Name + ", Price: " + item.Price);
            }
        }

        // Class representing menu items
        public class MenuItem
        {
            public string Name { get; }
            public decimal Price { get; }

            public MenuItem(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }

        // Class representing the menu collection
        public class MenuList : IEnumerable, IEnumerator
        {
            private MenuItem[] items;
            private int position = -1;
            public MenuList(MenuItem[] items)
            {
                this.items = items;
            }

            // GetEnumerator method required from the IEnumerable interface
            public IEnumerator GetEnumerator()
            {
                return this;
            }

            //Methods required from the IEnumerator interface        
            public bool MoveNext()
            {
                position++;
                return (position < items.Length);
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return items[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public void Reset()
            {
                position = -1;
            }
        } 

    }
}
