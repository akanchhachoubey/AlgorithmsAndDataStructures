using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class binomialcoeff_DP
    {
        public static int N;
        public static int K;
        public static int[,] arr;
        public static void execute()
        {
            TakeINputs();
            Console.WriteLine(GetCoefficient(N, K));
            Console.ReadLine();
        }


        public static int GetCoefficient(int n, int k)
        {
            for (int i = 0; i <=n; i++)
            {
                for (int j = 0; j <= min(i,k); j++)
                {
                    if (j == 0 || j == n)
                        arr[i, j] = 1;
                    else
                        arr[i, j] = arr[i - 1, j] + arr[i - 1, j - 1];
                }
            }
            return arr[n, k];
        }

        public static int min(int i, int j)
        {
            if (i > j) return j;
            else return i;
        }
        public static void TakeINputs()
        {
            N = Convert.ToInt32(Console.ReadLine());
            K = Convert.ToInt32(Console.ReadLine());
            arr = new int[N + 1, K + 1];
        }
    }
}
