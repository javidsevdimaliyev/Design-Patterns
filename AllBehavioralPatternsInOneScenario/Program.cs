/*
 Senaryo: Müşteri Sipariş Yönetimi

Bu senaryoda, bir e-ticaret platformunda müşterilerin siparişlerini yönetmek için tasarım kalıplarını kullanacağız.

Problemler:

Tek Yönlü Bağımlılık: Müşteri bilgileri ile siparişler arasında güçlü bir bağlantı var. Ancak, bu bilgileri değiştirdiğinizde siparişler de güncellenmelidir.

Esneklik ve Değişim: Siparişlerin durumu zamanla değişebilir ve bu değişikliklere esnek bir şekilde uyum sağlamak önemlidir.

Performans Optimizasyonu: Büyük miktarda siparişin işlenmesi sırasında performansın korunması kritiktir.

Çözümler:

Gözlemci (Observer) Tasarım Deseni:
Problemi Çözümleme:
Müşteri bilgileri veya siparişlerde yapılan değişiklikler diğerini etkilemelidir. Müşteri bilgileri güncellendiğinde, ilgili siparişlerin durumu da güncellenmelidir.

Çözüm:
Gözlemci deseni, nesneler arasında bir bağlantı kurar ve bir nesnedeki bir değişiklik, bağlı olan diğer nesneleri otomatik olarak günceller.
 */

// Subject (Gözlemleyen) arayüzü
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// ConcreteSubject (Somut Gözlemleyen) sınıfı
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
            Notify(); // Değişiklik olduğunda gözlemcileri bilgilendir
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

// Observer (Gözlemci) arayüzü
public interface IObserver
{
    void Update();
}

// ConcreteObserver (Somut Gözlemci) sınıfı
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
        _orderInfo = _customer.CustomerInfo; // Müşteri bilgileri güncellendiğinde siparişleri de güncelle
    }
}
