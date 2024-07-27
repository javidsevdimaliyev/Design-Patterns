using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
  
    public class ChainOfResScenario
    {
        // Chain of Responsibility Design Pattern - Behavioral Category //

        // StockHandler -> Payment -> Invoice -> Shipping
        public void Operate()
        {
            var order = new Order();

            var stockHandler = new StockHandler();
            var paymentHandler = new PaymentHandler();
            var invoiceHandler = new InvoiceHandler();
            var shippingHandler = new ShippingHandler();

            stockHandler.SetNext(paymentHandler);
            paymentHandler.SetNext(invoiceHandler);
            invoiceHandler.SetNext(shippingHandler);

            stockHandler.Handle(order);
        }

        public interface IOrderHandler
        {
            void SetNext(IOrderHandler next);
            bool Handle(Order order);
        }


        public class StockHandler : IOrderHandler
        {
            private IOrderHandler next;
            public void SetNext(IOrderHandler next)
            {
                this.next = next;
            }

            public bool Handle(Order order)
            {
                Console.WriteLine("StockHandler called");
                bool stockAvailable = true; // Check stock service

                if (next is not null && stockAvailable)
                {
                    return next.Handle(order);
                }

                return stockAvailable;
            }
        }


        public class PaymentHandler : IOrderHandler
        {
            private IOrderHandler next;
            public void SetNext(IOrderHandler next)
            {
                this.next = next;
            }

            public bool Handle(Order order)
            {
                Console.WriteLine("PaymentHandler called");
                bool paymentSuccess = true; // Check payment service

                if (next is not null && paymentSuccess)
                {
                    return next.Handle(order);
                }

                return paymentSuccess;
            }
        }


        public class InvoiceHandler : IOrderHandler
        {
            private IOrderHandler next;

            public void SetNext(IOrderHandler next)
            {
                this.next = next;
            }

            public bool Handle(Order order)
            {
                Console.WriteLine("InvoiceHandler called");
                bool invoiceCreated = true;

                if (invoiceCreated && next != null)
                {
                    return next.Handle(order);
                }

                return invoiceCreated;
            }
        }

        public class ShippingHandler : IOrderHandler
        {
            private IOrderHandler next;

            public void SetNext(IOrderHandler next)
            {
                this.next = next;
            }

            public bool Handle(Order order)
            {
                Console.WriteLine("ShippingHandler called");
                bool shippingSuccess = true;

                if (shippingSuccess && next != null)
                {
                    return next.Handle(order);
                }

                return shippingSuccess;
            }
        }


        public class Order
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }
    }
}
