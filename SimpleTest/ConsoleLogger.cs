//simple test

//Test 

namespace Domain
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string message, Exception? ex = null)
        {
            Console.WriteLine($"Error: {message}: {ex}");
        }

        public void Log(string stuff)
        {
            Console.WriteLine(stuff);
        }

        public void Warning(string message)
        {
            Console.WriteLine($"Warning: {message}");
        }
    }
}
