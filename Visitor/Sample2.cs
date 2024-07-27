using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Sample2
    {
        public void Test()
        {
            List<IProduct> products = new List<IProduct>
            {
                new Book(50),
                new Cloth(100),
                new Electronics(500)
            };

            var taxVisitor = new TaxVisitor();
            foreach (var product in products)
            {
                product.Accept(taxVisitor);
            }
        }

        // Tax visitor interface with visit methods for different product types.
        public interface ITaxVisitor
        {
            void Visit(Book book);
            void Visit(Cloth cloth);
            void Visit(Electronics electronics);
        }

        // Concrete tax visitor that applies tax calculation logic for each product type.
        public class TaxVisitor : ITaxVisitor
        {
            public void Visit(Book book)
            {
                double tax = book.Price * 0.05; // 5% tax for books
                Console.WriteLine($"Book Tax: {tax:C}");
            }

            public void Visit(Cloth cloth)
            {
                double tax = cloth.Price * 0.10; // 10% tax for clothes
                Console.WriteLine($"Cloth Tax: {tax:C}");
            }

            public void Visit(Electronics electronics)
            {
                double tax = electronics.Price * 0.15; // 15% tax for electronics
                Console.WriteLine($"Electronics Tax: {tax:C}");
            }
        }

        // Product interface with Accept method that takes a visitor as an argument.
        public interface IProduct
        {
            void Accept(ITaxVisitor visitor);
        }

        // Different product types
        public class Book : IProduct
        {
            public double Price { get; set; }

            public Book(double price)
            {
                Price = price;
            }

            public void Accept(ITaxVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Cloth : IProduct
        {
            public double Price { get; set; }

            public Cloth(double price)
            {
                Price = price;
            }

            public void Accept(ITaxVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Electronics : IProduct
        {
            public double Price { get; set; }

            public Electronics(double price)
            {
                Price = price;
            }

            public void Accept(ITaxVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

       

        
    }
}
