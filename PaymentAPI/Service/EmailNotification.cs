using PaymentAPI.Interface;

namespace PaymentAPI.Service
{
    public class EmailNotification : INotificationService
    {
        public void Notify(string To, string Messages)
        {
            Console.WriteLine($"Email Send to {To} and {Messages}");
        }
    }
}
