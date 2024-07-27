using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public class AbstractFactoryScenario
    {
        public void Operate()
        {
            //Computer computer1 = new();

            //CPU cpu = new();
            //computer1.CPU = cpu;

            //RAM ram = new();
            //computer1.RAM = ram;

            //VideoCard videoCard = new();
            //computer1.VideoCard = videoCard;

            //Computer computer2 = new(new(), new(), new());

            //CPU cpu2 = new();
            //computer2.CPU = cpu2;

            //RAM ram2 = new();
            //computer2.RAM = ram2;

            //VideoCard videoCard2 = new();
            //computer2.VideoCard = videoCard2;

            ComputerCreator creator = new();
            Computer asus = creator.CreateComputer(ComputerType.Asus);
            Computer toshiba = creator.CreateComputer(ComputerType.Toshiba);
            Computer msi = creator.CreateComputer(ComputerType.MSI);
        }

        class Computer
        {
            public Computer(ICPU cPU, IRAM rAM, IVideoCard videoCard)
            {
                CPU = cPU;
                RAM = rAM;
                VideoCard = videoCard;
            }
            public Computer()
            {

            }

            public ICPU CPU { get; set; }
            public IRAM RAM { get; set; }
            public IVideoCard VideoCard { get; set; }
        }


        #region Abstract Products
        interface ICPU { }
        interface IRAM { }
        interface IVideoCard { }
        #endregion

        #region Concrete Products
        class CPU : ICPU
        {
            public CPU(string text)
                => Console.WriteLine(text);
        }
        class RAM : IRAM
        {
            public RAM(string text)
                => Console.WriteLine(text);
        }
        class VideoCard : IVideoCard
        {
            public VideoCard(string text)
                => Console.WriteLine(text);
        }
        #endregion

        #region Abstract Factory
        interface IComputerFactory
        {
            ICPU CreateCPU();
            IRAM CreateRAM();
            IVideoCard CreateVideoCard();
        }
        #endregion

        #region Cocnrete Factories
        class AsusFactory : IComputerFactory
        {
            public ICPU CreateCPU()
                => new CPU($"Asus CPU was created.");

            public IRAM CreateRAM()
                => new RAM("Asus RAM was created.");

            public IVideoCard CreateVideoCard()
                => new VideoCard("Asus Video Card was created");
        }
        class ToshibaFactory : IComputerFactory
        {
            public ICPU CreateCPU()
                => new CPU($"Toshiba CPU was created.");

            public IRAM CreateRAM()
                => new RAM("Toshiba RAM was created.");

            public IVideoCard CreateVideoCard()
                => new VideoCard("Toshiba Video Card was created");
        }
        class MSIFactory : IComputerFactory
        {
            public ICPU CreateCPU()
                => new CPU($"MSI CPU was created.");

            public IRAM CreateRAM()
                => new RAM("MSI RAM was created.");

            public IVideoCard CreateVideoCard()
                => new VideoCard("MSI Video Card was created");
        }
        #endregion

        #region Creator
        enum ComputerType
        {
            Asus,
            MSI,
            Toshiba
        }
        class ComputerCreator
        {
            ICPU _cpu;
            IRAM _ram;
            IVideoCard _videoCard;

            public Computer CreateComputer(ComputerType computerType)
            {
                IComputerFactory computerFactory = computerType switch
                {
                    ComputerType.MSI => new MSIFactory(),
                    ComputerType.Toshiba => new ToshibaFactory(),
                    ComputerType.Asus => new AsusFactory()
                };

                _cpu = computerFactory.CreateCPU();
                _ram = computerFactory.CreateRAM();
                _videoCard = computerFactory.CreateVideoCard();

                return new(_cpu, _ram, _videoCard);
            }
        }
        #endregion
    }
}
