using Iterator;
using System;
using System.Collections;


class Program
{
    static void Main(string[] args)
    {
        //var ss = new Sample2();
        //ss.Test();
        // Creating customer array
        Customer[] customers = new Customer[]
        {
            new Customer("Cavid"),
            new Customer("Parviz"),
            new Customer("Camal"),
            new Customer("Natiq")
        };

        // Creating customer list
        CustomerList customerList = new CustomerList(customers);

        // Travelling through the customers and printing each customer name
        foreach (Customer customer in customerList)
        {
            Console.WriteLine("Customer name: " + customer.Name);
        }
    }
}

// Class representing the customer
public class Customer
{
    public string Name { get; }

    public Customer(string name)
    {
        Name = name;
    }
}

// Class representing the customer list
public class CustomerList : IEnumerable
{
    private Customer[] customers;

    public CustomerList(Customer[] customers)
    {
        this.customers = customers;
    }

    // GetEnumerator method required from the IEnumerable interface
    public IEnumerator GetEnumerator()
    {   
        return new CustomerListIterator(customers);
    }
}

// Iterator class for traversing the customer list
public class CustomerListIterator : IEnumerator
{
    private Customer[] customers;
    private int position = -1;

    public CustomerListIterator(Customer[] customers)
    {
        this.customers = customers;
    }
    public bool MoveNext()
    {
        position++;
        return (position < customers.Length);
    }

    public object Current
    {
        get
        {
            try
            {
                return customers[position];
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


