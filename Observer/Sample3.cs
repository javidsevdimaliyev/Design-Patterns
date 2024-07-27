using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Sample3
    {
        /*
 
        Problem:
        Birtərəfli asılılıq: Müştəri məlumatları və sifarişlər arasında güclü əlaqə var. Ancaq bu məlumatı dəyişdirdiyiniz zaman sifarişlər də yenilənməlidir.

        Çeviklik və Dəyişiklik: Sifarişlərin vəziyyəti zamanla dəyişə bilər və bu dəyişikliklərə çevik şəkildə uyğunlaşmaq vacibdir.

        Performansın optimallaşdırılması: Böyük həcmli sifarişləri emal edərkən performansın qorunması vacibdir.
      
       
        Problemin həlli:  Observer Design Pattern
        Müştəri məlumatlarına və ya sifarişlərə edilən dəyişikliklər digərinə təsir etməlidir. Müştəri məlumatları yeniləndikdə, müvafiq sifarişlərin statusu da yenilənməlidir.

        Observer nümunəsi obyektlər arasında əlaqə yaradır və bir obyektdə dəyişiklik avtomatik olaraq digər əlaqəli obyektləri yeniləyir.
         */


        public void Test()
        {
            Customer customer = new Customer();

            Order order = new Order(customer);
        }

        // Abstract Subject 
        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }

        // Concrete Subject 
        public class Customer : ISubject
        {
            private List<IObserver> _observers = new List<IObserver>();
            private string _customerInfo;

            public string CustomerInfo
            {
                get { return _customerInfo; }
                set
                {
                    _customerInfo = value;
                    Notify(); // Inform observers of any changes
                }
            }

            public void Attach(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                _observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update();
                }
            }
        }

        // Abstract Observer 
        public interface IObserver
        {
            void Update();
        }

        // Concrete Observer 
        public class Order : IObserver
        {
            private string _orderInfo;
            private Customer _customer;

            public Order(Customer customer)
            {
                _customer = customer;
                _customer.Attach(this);
            }

            public void Update()
            {
                _orderInfo = _customer.CustomerInfo; // Update orders when customer information is updated
            }
        }

    }
}
