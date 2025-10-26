using PaymentAPI.Interface;

namespace PaymentAPI.Service
{
    public class UpiPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"UPI Pyament{amount} using UPI");
        }
    }
}
