using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Sample3
    {
        public void Test()
        {
            var paymentOptions = new PaymentOptions()
            {
                CardNumber = "1234123412341234",
                CardHolderName = "Javid Sevdimaliyev",
                ExpirationDate = "12/25",
                Cvv = "123",
                Amount = 1000
            };

            var paymentService = new PaymentService();

            do
            {
                Console.Write("Choose Bank Type (1: Kapital, 2: Pasha, 3: Unibank): ");
                var bank = Console.ReadLine();

                IPaymentStrategy bankPaymentStrategy = null;

                switch (bank)
                {
                    case "1":
                        bankPaymentStrategy = new KapitalBankPaymentService();
                        break;
                    case "2":
                        bankPaymentStrategy = new PashaBankPaymentService();
                        break;
                    case "3":
                        bankPaymentStrategy = new UnibankPaymentService();
                        break;
                    default:
                        Console.WriteLine("Nonavailable bank choice.");
                        break;
                }

                paymentService.SetPaymentStrategy(bankPaymentStrategy);
                paymentService.PayViaStrategy(paymentOptions);

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

      

        class PaymentService
        {
            private IPaymentStrategy paymentService;

            public PaymentService() { }
           
            public PaymentService(IPaymentStrategy paymentService)
            {
                this.paymentService = paymentService;
            }

            public void SetPaymentStrategy(IPaymentStrategy paymentService)
            {
                this.paymentService = paymentService;
            }

            public bool PayViaStrategy(PaymentOptions options)
            {
                return paymentService.Pay(options);
            }
        }

        interface IPaymentStrategy
        {
            bool Pay(PaymentOptions paymentOptions);
        }



        public class KapitalBankPaymentService : IPaymentStrategy
        {
            public bool Pay(PaymentOptions paymentOptions)
            {
                Console.WriteLine("Payment was made with KapitalBank");
                return true;
            }
        }

        public class PashaBankPaymentService : IPaymentStrategy
        {
            public bool Pay(PaymentOptions paymentOptions)
            {
                Console.WriteLine("Payment was made with PashaBank");
                return true;
            }
        }

        public class UnibankPaymentService : IPaymentStrategy
        {
            public bool Pay(PaymentOptions paymentOptions)
            {
                Console.WriteLine("Payment was made with Unibank");
                return true;
            }
        }



      
        public class PaymentOptions
        {
            public string CardNumber { get; set; }
            public string CardHolderName { get; set; }
            public string ExpirationDate { get; set; }
            public string Cvv { get; set; }
            public decimal Amount { get; set; }
        }

    }
}
