using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class CoinChange_DP
    {
        public static int[] arr;
        public static int[] cost;
        public static int m;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(CoinChangeCount(m, 4));
            Console.ReadLine();
        }

        public static int CoinChangeCount(int m, int n)
        {
            if (n == 0)
                return 1;
            else if (m <= 0)
                return 0;
            else if (n < 0 && m >= 0)
                return 0;
            else
            {
                cost = new int[n + 1];
                cost[0] = 1;
                for (int i=0;i<m;i++)
                {
                    for(int j= arr[i];j<=n;j++)
                    {
                        cost[j] += cost[j - arr[i]];
                    }
                }
                return cost[n];
            }
        }
        public static void TakeInputs()
        {
            arr = new[] { 1, 2, 3 };
            m = arr.Length;
        }
    }
}
