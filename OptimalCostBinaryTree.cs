using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class OptimalCostBinaryTree
    {
        public static int[] keys = new int[]{ 10, 12, 20 };
        public static int[] freq = new int[]{ 34, 8, 50 };
        public static int n = 3;
        public static int[,] cost;
        public static void execute()
        {
            cost = new int[n+1,n+1];
            for (int i = 0; i < n; i++)
            {
                cost[i, i] = freq[i];
            }

            for (int l= 2;l<= n;l++)
            {
                for (int i = 0; i <= n-l+1; i++)
                {
                    int j = i + l - 1;
                    if (j == n) continue;
                    cost[i, j] = int.MaxValue;
                    for (int k = i; k <=j; k++)
                    {
                        int c = (k > i ? cost[i, k - 1] : 0)
                            + (j > k ? cost[k + 1, j] : 0)
                            + sum(i, j);
                        if (c < cost[i, j])
                            cost[i, j] = c;
                    }
                }
            }

            Console.WriteLine(cost[0,n-1]);
            Console.Read();
        }

        static int sum( int i, int j)
        {
            int s = 0;
            for (int k = i; k <= j; k++)
            {
                if (k >= freq.Length)
                    continue;
                s += freq[k];
            }
            return s;
        }

    }
}
