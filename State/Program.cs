class Program
{
    static void Main(string[] args)
    {
        var orderManager = new OrderManager();
        orderManager.PrintOrderState();

        orderManager.NextState();
        orderManager.PrintOrderState();

        orderManager.NextState();
        orderManager.PrintOrderState();

        Console.ReadLine();


    }

    class OrderManager
    {
        public IOrderState State { get; set; }

        public OrderManager()
        {
            State = new NewOrderState();
        }

        public void NextState()
        {
            State.Next(this);
        }

        public void PreviousState()
        {
            State.Previous(this);
        }

        public void PrintOrderState()
        {
            State.PrintStatus();
        }
    }

    interface IOrderState
    {
        void Next(OrderManager order);
        void Previous(OrderManager order);
        void PrintStatus();
    }

   

    record NewOrderState : IOrderState
    {
        public void Next(OrderManager order)
        {
            order.State = new ProcessingState();
        }

        public void Previous(OrderManager order)
        {
            Console.WriteLine("This is the initial state");
        }

        public void PrintStatus()
        {
            Console.WriteLine("Order is placed");
        }
    }

    record ProcessingState : IOrderState
    {
        public void Next(OrderManager order)
        {
            order.State = new OnTheWayState();
        }

        public void Previous(OrderManager order)
        {
            order.State = new NewOrderState();
        }

        public void PrintStatus()
        {
            Console.WriteLine("Order is being proccessed");
        }
    }

    record OnTheWayState : IOrderState
    {
        public void Next(OrderManager order)
        {
            order.State = new DeliveredState();
        }

        public void Previous(OrderManager order)
        {
            order.State = new ProcessingState();
        }

        public void PrintStatus()
        {
            Console.WriteLine("Order is on the way");
        }
    }

    record DeliveredState : IOrderState
    {
        public void Next(OrderManager order)
        {
            Console.WriteLine("This is the final state");
        }

        public void Previous(OrderManager order)
        {
            order.State = new OnTheWayState();
        }

        public void PrintStatus()
        {
            Console.WriteLine("Order is delivered");
        }
    }

 
  
}



