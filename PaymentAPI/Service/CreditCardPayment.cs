using PaymentAPI.Interface;

namespace SolidPrincipleProject.Service
{
    public class CreditCardPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Credit Card.");
        }
    }
}
