using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChainOfResponsibility
{

    public class ChainOfResScenario2
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

            //stockHandler.SetNext(paymentHandler);
            //paymentHandler.SetNext(invoiceHandler);
            //invoiceHandler.SetNext(shippingHandler);

            stockHandler.SetNext(paymentHandler).SetNext(invoiceHandler).SetNext(shippingHandler);

            stockHandler.Handle(order);
        }


        public interface IHandler
        {
            IHandler SetNext(IHandler handler);

            object Handle(object request);
        }

        // The default chaining behavior can be implemented inside a base handler
        // class.
        public abstract class AbstractHandler : IHandler
        {
            public IHandler _nextHandler;

            public IHandler SetNext(IHandler handler)
            {
                this._nextHandler = handler;

                // Returning a handler from here will let us link handlers in a
                // convenient way like this:
                // monkey.SetNext(squirrel).SetNext(dog);
                return handler;
            }

            public virtual object Handle(object request)
            {
                if (this._nextHandler != null)
                {
                    return this._nextHandler.Handle(request);
                }
                else
                {
                    return null;
                }
            }
        }


        public class StockHandler : AbstractHandler
        {
            public override object Handle(object request)
            {
                bool stockAvailable = true; // Check stock service
                if (base._nextHandler != null && stockAvailable)
                {
                    return base.Handle(request);
                }
                return stockAvailable;
            }
        }


        public class PaymentHandler : AbstractHandler
        {
            public override object Handle(object request)
            {
                bool paymentSuccess = true; // Check payment service
                if (base._nextHandler != null && paymentSuccess)
                {
                    return base.Handle(request);
                }

                return paymentSuccess;
            }
        }


        public class InvoiceHandler : AbstractHandler
        {
            public override object Handle(object request)
            {
                bool invoiceCreated = true;
                if (base._nextHandler != null && invoiceCreated)
                {
                    return base.Handle(request);
                }
                return invoiceCreated;
            }
        }

        public class ShippingHandler : AbstractHandler
        {
            public override object Handle(object request)
            {
                bool shippingSuccess = true;
                if (base._nextHandler != null && shippingSuccess)
                {
                    return base.Handle(request);
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
