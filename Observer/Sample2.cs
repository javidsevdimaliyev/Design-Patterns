using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Sample2
    {
        public void Test()
        {
            // Create a weather station
            WeatherStation weatherStation = new WeatherStation();

            // Create users and register them with the station
            User user1 = new User("Alice");
            User user2 = new User("Bob");
            weatherStation.Attach(user1);
            weatherStation.Attach(user2);

            // Provide weather updates
            weatherStation.SetTemperature(25.5f); // Example temperature update
        }

        // Subject interface
        interface IWeatherStation
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void NotifyObservers();
        }

        // Concrete Subject
        class WeatherStation : IWeatherStation
        {
            private float temperature;
            private List<IObserver> observers = new List<IObserver>();

            public void Attach(IObserver observer)
            {
                observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                observers.Remove(observer);
            }

            public void NotifyObservers()
            {
                foreach (var observer in observers)
                {
                    observer.Update(temperature);
                }
            }

            public void SetTemperature(float temperature)
            {
                this.temperature = temperature;
                NotifyObservers();
            }
        }

        // Observer interface
        interface IObserver
        {
            void Update(float temperature);
        }

        // Concrete Observer
        class User : IObserver
        {
            private string name;

            public User(string name)
            {
                this.name = name;
            }

            public void Update(float temperature)
            {
                Console.WriteLine($"Dear {name}, the current temperature is {temperature}°C");
            }
        }
    }
}
