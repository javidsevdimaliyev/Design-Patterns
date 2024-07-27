using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class PrototypeScenario
    {
        public void Operate()
        {
            Person person1 = new("Javid", "Sevdimaliyev", Department.C, 100, 10);
            //Person person2 = new("Parviz", "Aliyev", Department.B, 100, 10);


            Person person2 = person1.Clone();
            person2.Name = "Parviz";

            Console.WriteLine();
        }

        //Abstract Prototype
        interface IPersonCloneable
        {
            Person Clone();
        }

        //Concrete Prototype
        class Person : IPersonCloneable
        {
            public Person(string name, string surname, Department department, int salary, int premium)
            {
                Name = name;
                Surname = surname;
                Department = department;
                Salary = salary;
                Premium = premium;
                Console.WriteLine("Person instance was created");
            }

            public string Name { get; set; }
            public string Surname { get; set; }
            public Department Department { get; set; }
            public int Salary { get; set; }
            public int Premium { get; set; }

            public Person Clone()
            {
                return (Person)base.MemberwiseClone(); //or (Person)this.MemberwiseClone()
            }
        }

        enum Department
        {
            A, B, C
        }
    }
}
