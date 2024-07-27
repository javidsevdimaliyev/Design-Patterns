using System;

namespace Decorator
{
    internal class Sample3
    {
        public void Test()
        {
            // Create base notifier
            INotification notifier = new Notifier();

            // Extend with SMS and Facebook notifications
            var smsDecorator = new SMSDecorator(notifier);
            var fbDecorator = new FacebookDecorator(notifier);

            // Send notifications
            smsDecorator.Send("Critical issue detected!");
            fbDecorator.Send("Dear Facebook users, Critical issue detected!");
        }

        // Base notification interface
        interface INotification
        {
            void Send(string message);
        }

        // Base notification class
        class Notifier : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"Email notification sent: {message}");
            }
        }

        // Abstract Decorator class
        abstract class NotificationDecorator : INotification
        {
            protected INotification _notification;

            public NotificationDecorator(INotification notification)
            {
                _notification = notification;
            }

            public virtual void Send(string message)
            {
                _notification.Send(message);
            }
        }

        #region Concrete Decorators
        // SMS notification decorator
        class SMSDecorator : NotificationDecorator
        {
            public SMSDecorator(INotification notification) : base(notification) { }

            public override void Send(string message)
            {
                //Some Operations here
                base.Send(message);
                //Some Operations here
                Console.WriteLine($"SMS notification sent: {message}");
            }
        }

        // Facebook notification decorator
        class FacebookDecorator : NotificationDecorator
        {
            public FacebookDecorator(INotification notification) : base(notification) { }

            public override void Send(string message)
            {
                //Some Operations here
                base.Send(message);
                //Some Operations here
                Console.WriteLine($"Facebook notification sent: {message}");
            }
        }

        // Slack notification decorator
        class SlackDecorator : NotificationDecorator
        {
            public SlackDecorator(INotification notification) : base(notification) { }

            public override void Send(string message)
            {
                //Some Operations here
                base.Send(message);
                //Some Operations here
                Console.WriteLine($"Slack notification sent: {message}");
            }
        }

        #endregion
    }
}
