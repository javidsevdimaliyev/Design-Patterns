using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class WithoutMediatorScenario
    {
        public void Test()
        {
            Airplane airplane1 = new Airplane("Airplane 1");
            Airplane airplane2 = new Airplane("Airplane 2");
            Airplane airplane3 = new Airplane("Airplane 3");

            airplane1.AddAirplane(airplane2);
            airplane1.AddAirplane(airplane3);

            airplane2.AddAirplane(airplane1);
            airplane2.AddAirplane(airplane3);

            airplane3.AddAirplane(airplane1);
            airplane3.AddAirplane(airplane2);

            airplane1.RequestLanding();
        }

        public class Airplane
        {
            public string Name { get; set; }
            private List<Airplane> _airplanes;

            public Airplane(string name)
            {
                Name = name;
                _airplanes = new List<Airplane>();
            }

            public void AddAirplane(Airplane airplane)
            {
                _airplanes.Add(airplane);
            }

            public void RequestLanding()
            {
                foreach (var airplane in _airplanes)
                {
                    airplane.ReceiveLandingRequest(this);
                }
            }

            public void ReceiveLandingRequest(Airplane airplane)
            {
                Console.WriteLine($"{airplane.Name} is requesting to land.");
            }
        }

      

    }
}
