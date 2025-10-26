using PaymentAPI.Interface;

namespace PaymentAPI.Service
{
    public class SmsNotification : INotificationService
    {
        public void Notify(string To, string Messages)
        {
            Console.WriteLine($"SMS Sent to {To} and {Messages}");
        }
    }
}
