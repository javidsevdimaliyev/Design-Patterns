using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public  class BuilderDesignPatternScenario
    {
        public void Operate()
        {
            /*
            ////Mercedes
            //Car mercedes = new();
            //mercedes.KM = 0;
            //mercedes.Brand = "Mercedes";
            //mercedes.Model = "...";
            //mercedes.IsPlugInHybrid = true;

            ////BMW
            //Car bmw = new();
            //bmw.KM = 10;
            //bmw.Brand = "BMW";
            //bmw.Model = "...";
            //bmw.IsPlugInHybrid = false;
            */

            CarDirector director = new();
            Car opel = director.Build(new OpelBuilder());
            opel.ToString();
            Car mercedes = director.Build(new MercedesBuilder());
            mercedes.ToString();
            Car bmw = director.Build(new BMWBuilder());
            bmw.ToString();
        }

        //Director
        class CarDirector
        {
            public Car Build(CarBuilder CarBuilder)
            {
                //CarBuilder.SetBrand();
                //CarBuilder.SetModel();
                //CarBuilder.SetKM();
                //CarBuilder.SetIsPlugInHybrid();
                CarBuilder.SetBrand()
                    .SetModel()
                    .SetKM()
                    .SetIsPlugInHybrid();
                return CarBuilder.Car;
            }
        }


        //Product
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public double KM { get; set; }
            public bool IsPlugInHybrid { get; set; }
            public override string ToString()
            {
                Console.WriteLine($"{IsPlugInHybrid} in {Brand} make Car {Model} model with {KM} kilometres Manufactured as IsPlugInHybrid.");
                return base.ToString();
            }
        }

        //Abstract Builder
        abstract class CarBuilder
        {
            public CarBuilder() => Car = new();

            public Car Car { get; private set; }

            public abstract CarBuilder SetBrand();
            public abstract CarBuilder SetModel();
            public abstract CarBuilder SetKM();
            public abstract CarBuilder SetIsPlugInHybrid();
        }
        //Concrete Builder
        class OpelBuilder : CarBuilder
        {
            public override CarBuilder SetKM()
            {
                Car.KM = 0;
                return this;
            }

            public override CarBuilder SetBrand()
            {
                Car.Brand = "Opel";
                return this;
            }

            public override CarBuilder SetModel()
            {
                Car.Model = "Insignia";
                return this;
            }

            public override CarBuilder SetIsPlugInHybrid()
            {
                Car.IsPlugInHybrid = true;
                return this;
            }
        }
        //Concrete Builder
        class MercedesBuilder : CarBuilder
        {
            public override CarBuilder SetKM()
            {
                Car.KM = 100;
                return this;
            }

            public override CarBuilder SetBrand()
            {
                Car.Brand = "Mercedes";
                return this;
            }

            public override CarBuilder SetModel()
            {
                Car.Model = "E220";
                return this;
            }

            public override CarBuilder SetIsPlugInHybrid()
            {
                Car.IsPlugInHybrid = true;
                return this;
            }
        }
        //Concrete Builder
        class BMWBuilder : CarBuilder
        {
            public override CarBuilder SetKM()
            {
                Car.KM = 10;
                return this;
            }

            public override CarBuilder SetBrand()
            {
                Car.Brand = "BMW";
                return this;
            }

            public override CarBuilder SetModel()
            {
                Car.Model = "520e";
                return this;
            }

            public override CarBuilder SetIsPlugInHybrid()
            {
                Car.IsPlugInHybrid = false;
                return this;
            }
        }

      
    }
}
