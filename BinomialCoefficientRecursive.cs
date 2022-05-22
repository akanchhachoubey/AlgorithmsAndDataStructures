using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class BinomialCoefficientRecursive
    {
        public static int N;
        public static int K;
        public static void execute()
        {
            TakeINputs();
            Console.WriteLine(GetCoefficient( N, K));
            Console.ReadLine();
        }


        public static int GetCoefficient(int n , int k)
        {
            if (k == n || k == 0)
                return 1;
            else
            {
                return GetCoefficient(n - 1, k) + GetCoefficient(n - 1, k - 1);
            }
        }
        public static void TakeINputs()
        {
            N = Convert.ToInt32(Console.ReadLine());
            K= Convert.ToInt32(Console.ReadLine());
        }
    }
}
