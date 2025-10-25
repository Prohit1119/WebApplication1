using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion
{

    public class LiskovSubString
    {
        public void GetColor()
        {
            Console.WriteLine("LiskovSubString");
        }
    }

    public class DrivedClass :LiskovSubString
    {
        public void GetColor()
        {
            Console.WriteLine("DrivedClass");
        }
    }
}
