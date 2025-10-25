using SolidPrincipleProject.Interface;

namespace SolidPrincipleProject.Service
{
    public class UpiPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"UPI Pyament{amount} using UPI");
        }
    }
}
