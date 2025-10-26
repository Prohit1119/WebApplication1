using PaymentAPI.Interface;

namespace PaymentAPI.Service
{
    public class LoggerService : ILogerService
    {
        public void Log(string Messages)
        {
            Console.WriteLine($"[LOG] : {Messages}");
        }
    }
}
