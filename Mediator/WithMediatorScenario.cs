using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{

    internal class WithMediatorScenario
    {
        public void Test()
        {
            AirTrafficMediator mediator = new();

            Airplane airplane1 = new Airplane("Airplane 1", mediator);
            Airplane airplane2 = new Airplane("Airplane 2", mediator);
            Airplane airplane3 = new Airplane("Airplane 3", mediator);

            airplane1.RequestLanding();
        }

        public interface IAirTrafficMediator
        {
            void Notify(Airplane airplane);
            void AddAirplane(Airplane airplane);
        }

        //ConcreteMediator
        public class AirTrafficMediator : IAirTrafficMediator
        {
            private List<Airplane> _airplanes;

            public AirTrafficMediator()
            {
                _airplanes = new List<Airplane>();
            }

            public void AddAirplane(Airplane airplane)
            {
                _airplanes.Add(airplane);
            }

            //Notify process
            public void Notify(Airplane airplane)
            {
                foreach (var a in _airplanes)
                {
                    if (a != airplane)
                    {
                        a.ReceiveLandingRequest(airplane);
                    }
                }
            }
        }

        public class Airplane
        {
            public string Name { get; set; }
            private IAirTrafficMediator _mediator;

            public Airplane(string name, IAirTrafficMediator airTrafficMediator)
            {
                Name = name;
                _mediator = airTrafficMediator;
                _mediator.AddAirplane(this);
            }

            public void RequestLanding()
            {
                _mediator.Notify(this);
            }

            public void ReceiveLandingRequest(Airplane airplane)
            {
                Console.WriteLine($"{airplane.Name} is requesting to land.");
            }
        }

      

    }


}
