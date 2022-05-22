using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class MinCost_DP
    {
        public static int[,] M;
        public static int[,] cost;
        public static void execute()
        {
            TakeInputs();
            Console.Write(minCost(2, 2));
            Console.ReadLine();
        }

        public static int minCost(int m, int n)
        {
            for(int i=0;i<=m;i++)
            {
                for(int j= 0;j<=n;j++)
                {
                    if (i == 0 && j == 0)
                        cost[i, j] = M[i, j];
                    else if (i == 0 && j != 0)
                        cost[i, j] = M[i, j] + cost[i, j - 1];
                    else if (i != 0 && j == 0)
                        cost[i, j] = M[i, j] + cost[i-1, j ];
                    else
                        cost[i, j] = M[i, j] + min(
                            cost[i - 1, j],
                            cost[i, j - 1],
                            cost[i - 1, j - 1]);
                }

            }
            return cost[m, n];
        }

        public static int min(int i, int j, int k)
        {
            if (i > j && k > j)
                return j;
            else if (i > k && j > k)
                return k;
            else return i;
        }

        public static void TakeInputs()
        {
            M = new int[,]{{ 1, 2, 3},
                       { 4, 8, 2},
                       { 1, 5, 3} };
            cost = new int[3, 3];
        }
    }
}
