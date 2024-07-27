﻿class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Executing the client code with a real subject:");
        RealSubject realSubject = new RealSubject();
        realSubject.Request();

        Console.WriteLine();

        //Executing the same client code with a proxy:
        ConcreteProxy proxy = new ConcreteProxy(realSubject);
        proxy.Request();
    }
}

// The RealSubject contains some core business logic. Usually, RealSubjects
// are capable of doing some useful work which may also be very slow or
// sensitive - e.g. correcting input data. A Proxy can solve these issues
// without any changes to the RealSubject's code.
class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request.");
    }
}


// The Subject interface declares common operations for both RealSubject and
// the Proxy. As long as the client works with RealSubject using this
// interface, you'll be able to pass it a proxy instead of a real subject.
public interface ISubject
{
    void Request();
}

// The Proxy has an interface identical to the RealSubject.
class ConcreteProxy : ISubject
{
    private RealSubject _realSubject;

    public ConcreteProxy(RealSubject realSubject)
    {
        _realSubject = realSubject;
    }

    // The most common applications of the Proxy pattern are lazy loading,
    // caching, controlling the access, logging, etc. A Proxy can perform
    // one of these things and then, depending on the result, pass the
    // execution to the same method in a linked RealSubject object.
    public void Request()
    {
        if (CheckAccess())
        {
            _realSubject.Request();

            LogAccess();
        }
    }

    public bool CheckAccess()
    {
        // Some real checks should go here.
        Console.WriteLine("Proxy: Checking access prior to firing a real request.");

        return true;
    }

    public void LogAccess()
    {
        Console.WriteLine("Proxy: Logging the time of request.");
    }
}







