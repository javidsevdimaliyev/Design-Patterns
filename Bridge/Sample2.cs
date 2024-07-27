using System;

namespace Bridge
{
    internal class Sample2
    {
        public void Test()
        {
            IMessageSender emailSender = new EmailSender();
            IMessageSender smsSender = new SMSSender();
            IMessageSender pushSender = new PushNotificationSender();

            Platform webPlatform = new WebPlatform(emailSender);
            Platform mobilePlatform = new MobilePlatform(pushSender);
            Platform desktopPlatform = new DesktopPlatform(smsSender);

            webPlatform.SendMessageOnPlatform("Email sent to the web platform.");
            mobilePlatform.SendMessageOnPlatform("A push notification was sent to the mobile platform.");
            desktopPlatform.SendMessageOnPlatform("SMS sent to the desktop platform.");

            Console.ReadLine();
        }

        #region Implementation
        // Message sender interface
        public interface IMessageSender
        {
            void SendMessage(string message);
        }

        // Email sender class
        public class EmailSender : IMessageSender
        {
            public void SendMessage(string message)
            {
                Console.WriteLine("E-mail sent: " + message);
            }
        }

        // SMS sender class
        public class SMSSender : IMessageSender
        {
            public void SendMessage(string message)
            {
                Console.WriteLine("SMS sent: " + message);
            }
        }

        // Push notification sender class
        public class PushNotificationSender : IMessageSender
        {
            public void SendMessage(string message)
            {
                Console.WriteLine("Push notification sent: " + message);
            }
        }
        #endregion

        #region Abstraction
        // Platform interface
        public abstract class Platform
        {
            protected IMessageSender messageSender;

            public Platform(IMessageSender sender)
            {
                this.messageSender = sender;
            }

            public abstract void SendMessageOnPlatform(string message);
        }

        // Web platform
        public class WebPlatform : Platform
        {
            public WebPlatform(IMessageSender sender) : base(sender)
            {
            }

            public override void SendMessageOnPlatform(string message)
            {
                Console.WriteLine("Via the web platform: ");
                messageSender.SendMessage(message);
            }
        }

        // Mobile platform
        public class MobilePlatform : Platform
        {
            public MobilePlatform(IMessageSender sender) : base(sender)
            {
            }

            public override void SendMessageOnPlatform(string message)
            {
                Console.WriteLine("Via mobile platform: ");
                messageSender.SendMessage(message);
            }
        }

        // Desktop platform
        public class DesktopPlatform : Platform
        {
            public DesktopPlatform(IMessageSender sender) : base(sender)
            {
            }

            public override void SendMessageOnPlatform(string message)
            {
                Console.WriteLine("Through the desktop platform: ");
                messageSender.SendMessage(message);
            }
        }
        #endregion
    }
}
