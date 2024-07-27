
class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1.Age = 42;
        p1.BirthDate = Convert.ToDateTime("1977-01-01");
        p1.Name = "Jack Daniels";
        p1.Address = new Address("666");

        // Perform a shallow copy of p1 and assign it to p2.
        Person p2 = p1.ShallowCopy();
        // Make a deep copy of p1 and assign it to p3.
        Person p3 = p1.DeepCopy();

      
        // Change the value of p1 properties and display the values of p1,
        // p2 and p3.
       
        DisplayValues(p1);
        p1.Name = "Frank";
        p1.Address.Name = "7878";
        Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values (reference values have changed):");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values (everything was kept the same):");
        DisplayValues(p3);
    }

    public static void DisplayValues(Person p)
    {
        Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
            p.Name, p.Age, p.BirthDate);
        Console.WriteLine("      ID#: {0:d}", p.Address.Name);
    }
}


public class Person
{
    public int Age;
    public DateTime BirthDate;
    public string Name;
    public Address Address;

    public Person ShallowCopy() //Reference type members don't be created by Shallow Copy  
    {
        return (Person)this.MemberwiseClone();
    }

    public Person DeepCopy() 
    {
        Person clone = (Person)this.MemberwiseClone();
        clone.Name = String.Copy(Name);
        clone.Address = new Address(Address.Name);
       
        return clone;
    }
}

public class Address
{
    public string Name;

    public Address(string name)
    {
        this.Name = name;
    }
}

