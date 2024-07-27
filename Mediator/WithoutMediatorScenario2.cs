using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class WithoutMediatorScenario2
    {
        public void Test()
        {
      
            Room room = new Room();
            Reservation reservation = new Reservation();
            Payment payment = new Payment();

            User user = new User();

            user.MakeReservation(room, reservation, payment);
        }

        public class User
        {
            public void MakeReservation(Room room, Reservation reservation, Payment payment)
            {
                if (room.IsAvailable(reservation))
                {
                    payment.Process();
                    room.Book(reservation);
                }
            }
        }

        public class Payment
        {
            public void Process()
            {

            }
        }


        public class Room
        {
            public bool IsAvailable(Reservation reservation)
            {
                return true;
            }

            public void Book(Reservation reservation)
            {
                
            }
        }

      

        public class Reservation
        {
            
        }

      
    }
}
