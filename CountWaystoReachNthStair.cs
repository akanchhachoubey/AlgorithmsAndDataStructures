using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CountWaystoReachNthStair
    {
        public static void execute()
        {
            int s = 5;
            int m = 2;
            Console.WriteLine(ClimbStairs(s + 1, m));
            Console.ReadLine();
        }

        public static int ClimbStairs(int s, int m)
        {
            if (s <= 1)
                return s;
            int count = 0;
            for (int i = 1; i <=m && i<=s; i++)
            {
                count += ClimbStairs(s-i,m);
            }
            return count;
        }
    }
}
