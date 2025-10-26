using PaymentAPI.Interface;

namespace PaymentAPI.Service
{
    public class PayPalAmount : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid is Card {Convert.ToDecimal(amount)} using paypal card payament");
        }
    }
}
