using PaymentAPI.Interface;

namespace SolidPrincipleProject.Service
{
    public class LoggerService : ILogerService
    {
        public void Log(string Messages)
        {
            Console.WriteLine($"[LOG] : {Messages}");
        }
    }
}
