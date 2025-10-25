using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string ar = Console.ReadLine();

            //Program.WordDetails(ar);
            LinqClass linq = new LinqClass();
            linq.Duplicated();

            LiskovSubString objList = new DrivedClass();
            objList.GetColor();
            Console.ReadLine();

           
        }
        public static void WordDetails(string ar)
        {

            StringBuilder stringBuilder = new StringBuilder();

            Console.WriteLine(ar);
            var arr = ar.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length>4)
                {
                    stringBuilder.Append('*', arr.Length);
                }
                else
                {
                    stringBuilder.Append(arr[i]);
                }
            }
            Console.Write(stringBuilder.ToString());
            Console.ReadLine();
        }
    }
}
