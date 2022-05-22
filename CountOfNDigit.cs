using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CountOfNDigit
    {
        public static int N = 2;
        public static int Sum = 5;
        public static void execute()
        {
            Console.WriteLine(  getFinalCount(N,Sum));
            Console.ReadLine();
        }

        public static int getFinalCount(int n, int sum)
        {
            int count = 0;
            for (int i =   1; i <= 9; i++)
            {
                if (sum - i >= 0)
                    count += getCount(n-1, sum - i);
            }
            return count;
        }

        public static int getCount(int n, int sum)
        {
            if (n == 0 && sum != 0)
                return 0;
            if (sum == 0)
                return 1;
            int count = 0;
            for (int i = 0; i <=9; i++)
            {
                if(sum-i>=0)
                    count += getCount(n - 1, sum - i);
            }
            return count;
        }
    }
}
