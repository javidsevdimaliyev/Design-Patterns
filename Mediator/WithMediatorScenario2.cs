using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class WithMediatorScenario2
    {
        public void Test()
        {
            ConcreteMediator mediator = new();

            Room room = new Room(mediator);
            Reservation reservation = new Reservation(mediator);
            Payment payment = new Payment(mediator);
            User user = new User(mediator);

            mediator.Register(user, room, reservation, payment);

            user.MakeReservation();
        }

        public interface IMediator
        {
            void Notify(object sender, string ev);
        }

        public class ConcreteMediator : IMediator
        {
            private User _user;
            private Room _room;
            private Reservation _reservation;
            private Payment _payment;

            public void Register(User user, Room room, Reservation reservation, Payment payment)
            {
                _user = user;               
                _room = room;               
                _reservation = reservation;                
                _payment = payment;               
            }

            public void Notify(object sender, string ev)
            {
                if (ev == "MakeReservation")
                {
                    if (_room.IsAvailable(_reservation))
                    {
                        _payment.Process();
                        _room.Book(_reservation);
                    }
                }
            }
        }

        public class User
        {
            private IMediator _mediator;

            public User(IMediator mediator)
            {
                _mediator = mediator;
            }

            public void MakeReservation()
            {
                _mediator.Notify(this, "MakeReservation");
            }
        }

        public class Room
        {
            private IMediator _mediator;

            public Room(IMediator mediator)
            {
                _mediator = mediator;
            }

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
            private IMediator _mediator;

            public Reservation(IMediator mediator)
            {
                _mediator = mediator;
            }

            // Rezervasyon detayları
        }

        public class Payment
        {
            private IMediator _mediator;

            public Payment(IMediator mediator)
            {
                _mediator = mediator;
            }

            public void Process()
            {
                // Ödeme işlemini gerçekleştir.
            }
        }

    }
}
