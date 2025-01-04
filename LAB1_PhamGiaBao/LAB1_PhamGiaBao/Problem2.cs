using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_PhamGiaBao
{
    internal class Problem2
    {
        //1 lan build chay duoc 1 main nen em comment may cai main nay nha thay:3

        /* public static void Main(string[] args)
         {
             int dividend = Convert.ToInt32(Console.ReadLine());
             int divisor = Convert.ToInt32(Console.ReadLine());
             if (Math.Pow(-2, 31) <= dividend || divisor <= Math.Pow(2, 31) + 1)
             {
                 int result = divide(dividend, divisor);
                 Console.WriteLine(result);
             }
             else
             {
                 Console.WriteLine("Wrong Input");

             }
         }*/

        public static int divide(int dividend, int divisor)
        {
            if (dividend > 0 && divisor > 0)
            {
                dividend = Math.Abs(dividend);
                int temp = dividend;
                divisor = Math.Abs(divisor);
                int count = 0;
                while (temp > divisor)
                {
                    temp -= divisor;
                    count += 1;
                }
                return count;
            }
            else
            {
                dividend = Math.Abs(dividend);
                int temp = dividend;
                divisor = Math.Abs(divisor);
                int count = 0;
                while (temp > divisor)
                {
                    temp -= divisor;
                    count -= 1;
                }
                return count;
            }
        }
    }
}
