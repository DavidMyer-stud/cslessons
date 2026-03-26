using System;
using System.IO;

namespace Task2
{
    class MessagePublisher
    {
        public event Action<string> MessageSent;

        public void Send(string message)
        {
            MessageSent?.Invoke(message);
        }
    }

    class FileLogger
    {
        private readonly string logFileName = "logPD22.txt";

        public void LogMessage(string message)
        {
            string logEntry = $"[{DateTime.Now:HH:mm:ss}] {message}\n";
            File.AppendAllText(logFileName, logEntry);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger();

            publisher.MessageSent += logger.LogMessage;

            Console.WriteLine("Введіть текст 4 рази:");

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Ввід {i + 1}/4: ");
                string input = Console.ReadLine();
                publisher.Send(input);
            }

            Console.WriteLine("Завдання 2 виконано!");
        }
    }
}