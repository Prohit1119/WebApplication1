using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion
{

   public interface Discount
    {
        void ApplyDiscount(int amount);
    }
    internal class OpenClosed : Discount
    {
        public void ApplyDiscount(int amount)
        {
            Console.WriteLine(amount * 0.90 / 20);
        }

        
    }
    public class Closed : Discount
    {
        
        void Discount.ApplyDiscount(int amount)
        {
            Console.WriteLine(amount * 0.1 / 30);
        }
    }
}
