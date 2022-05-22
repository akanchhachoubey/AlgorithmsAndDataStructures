using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CountofBinaryStringswithoutConsecutiveOnes
    {
        public static void execute()
        {
            CallFunc(3);
            Console.Read();
        }

        public static void CallFunc(int n)
        {
            int[] a = new int[n];
            int[] b = new int[n];
            a[0] = 1;
            b[0] = 1;
            for (int i = 1; i < n; i++)
            {
                a[i] = a[i - 1] + b[i - 1];
                b[i] = a[i - 1];
            }

            Console.WriteLine(a[n-1]+b[n-1]);
        }
    }
}
