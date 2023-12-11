//simple test

//Test 

namespace Domain
{
    public interface ILogger
    {
        void Log(string stuff);
        void Error(string message, Exception? ex = null);
        void Warning(string message);
    }
}
