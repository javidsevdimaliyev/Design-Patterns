﻿class Program
{
    static void Main(string[] args)
    {
        // The client code may have some of the subsystem's objects already
        // created. In this case, it might be worthwhile to initialize the
        // Facade with these objects instead of letting the Facade create
        // new instances.
        Subsystem1 subsystem1 = new Subsystem1();
        Subsystem2 subsystem2 = new Subsystem2();
        OperationFacade facade = new OperationFacade(subsystem1, subsystem2);
        Console.Write(facade.Operation());
    }
}

public class Subsystem1
{
    public string operation1()
    {
        return "Subsystem1: Ready!\n";
    }

    public string operationN()
    {
        return "Subsystem1: Go!\n";
    }
}

// Some facades can work with multiple subsystems at the same time.
public class Subsystem2
{
    public string operation1()
    {
        return "Subsystem2: Get ready!\n";
    }

    public string operationZ()
    {
        return "Subsystem2: Fire!\n";
    }
}


// The Facade class provides a simple interface to the complex logic of one
// or several subsystems. The Facade delegates the client requests to the
// appropriate objects within the subsystem. The Facade is also responsible
// for managing their lifecycle. All of this shields the client from the
// undesired complexity of the subsystem.

public class OperationFacade
{
    protected Subsystem1 _subsystem1;

    protected Subsystem2 _subsystem2;

    public OperationFacade(Subsystem1 subsystem1, Subsystem2 subsystem2)
    {
        this._subsystem1 = subsystem1;
        this._subsystem2 = subsystem2;
    }

    // The Facade's methods are convenient shortcuts to the sophisticated
    // functionality of the subsystems. However, clients get only to a
    // fraction of a subsystem's capabilities.
    public string Operation()
    {
        string result = "Facade initializes subsystems:\n";
        result += this._subsystem1.operation1();
        result += this._subsystem2.operation1();
        result += "Facade orders subsystems to perform the action:\n";
        result += this._subsystem1.operationN();
        result += this._subsystem2.operationZ();
        return result;
    }
}

// The Subsystem can accept requests either from the facade or client
// directly. In any case, to the Subsystem, the Facade is yet another
// client, and it's not a part of the Subsystem.

