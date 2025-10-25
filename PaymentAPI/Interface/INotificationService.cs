namespace PaymentAPI.Interface
{
    public interface INotificationService
    {
        void Notify(string To, string Messages);
    }
}
