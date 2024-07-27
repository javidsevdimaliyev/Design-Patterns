namespace Proxy
{
    internal class Sample
    {
        public void Test()
        {
            ILogger logger = new BufferedFileLoggerProxy(5);
            logger.Log("Hello world");
        }
        class BufferedFileLoggerProxy : ILogger
        {
            private readonly int bufferSize;
            private readonly FileLogger fileLogger;
            private List<string> buffer;

            public BufferedFileLoggerProxy(int bufferSize)
            {
                this.bufferSize = bufferSize;
                fileLogger = new FileLogger();
                buffer = new List<string>(capacity: bufferSize);
            }

            public void Log(string message)
            {
                buffer.Add(message);

                if (buffer.Count >= bufferSize)
                {
                    fileLogger.Log(buffer);
                    buffer.Clear();
                }
            }

            public void Log(IEnumerable<string> messages)
            {
                fileLogger.Log(messages);
            }
        }

        class FileLogger : ILogger
        {
            public void Log(string message)
            {
                message = $"[{DateTime.Now:dd.MM.yyyy}] - {message}";
                File.AppendAllText("messages.log", message);
            }

            public void Log(IEnumerable<string> messages)
            {
                File.AppendAllText("messages.log", string.Join(Environment.NewLine, messages));
            }
        }


        interface ILogger
        {
            void Log(string message);

            void Log(IEnumerable<string> messages);
        }
    }
}
