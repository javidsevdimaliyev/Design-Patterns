using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Sample2
    {
        public void Test()
        {
            Lamp lamp = new Lamp();
         
            ICommand turnOnCommand = new TurnOnLampCommand(lamp);
            ICommand turnOffCommand = new TurnOffLampCommand(lamp);
          
            RemoteControl remoteControl = new RemoteControl();

            // Setting and triggering different commands
            remoteControl.PressButton(turnOnCommand); // Switching on the lamp

            remoteControl.PressButton(turnOffCommand); // Switching off the lamp
        }


        // Invoker class
        class RemoteControl
        {
            public void PressButton(ICommand command)
            {
                command.Execute();
            }
        }


        // Command interface
        interface ICommand
        {
            void Execute();
        }

        // Concrete command
        class TurnOnLampCommand : ICommand
        {
            private Lamp _lamp;

            public TurnOnLampCommand(Lamp lamp)
            {
                _lamp = lamp;
            }

            public void Execute()
            {
                _lamp.TurnOn();
            }
        }

        // Concrete command
        class TurnOffLampCommand : ICommand
        {
            private Lamp _lamp;

            public TurnOffLampCommand(Lamp lamp)
            {
                _lamp = lamp;
            }

            public void Execute()
            {
                _lamp.TurnOff();
            }
        }

        // Receiver class
        class Lamp
        {
            public void TurnOn()
            {
                Console.WriteLine("Lamp is on.");
            }

            public void TurnOff()
            {
                Console.WriteLine("Lamp is off.");
            }
        }
    }
}
