using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class GetMinSquares
    {
        public static void execute()
        {
            Console.WriteLine(getMinSquares(225));
            Console.ReadLine();
        }

        public static int getMinSquares(int n)
        {
            if (n <= 3)
                return n;

            int res = n;
            int previous = 1;
            int x = 1;
            int temp = x * x;
                while (temp<n)
                {
                    previous = x;
                    x++;
                    temp = x * x;
                }
                res = Math.Min(res, 1 + getMinSquares(n - previous*previous));
               
            return res;
        }
    }
}
