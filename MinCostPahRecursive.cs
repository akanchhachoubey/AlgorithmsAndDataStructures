using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class MinCostPahRecursive
    {
        public static int[,] M;
        public static void execute()
        {
            TakeInputs();
            Console.Write(minCost(2, 2));
            Console.ReadLine();
        }

        public static int minCost(int i,int j)
        {
            if (i < 0 || j < 0)
                return int.MaxValue;
            else if (i == 0 && j == 0)
                return M[i, j];
            else return M[i, j] + min(
                minCost(i, j - 1),
                minCost(i - 1, j),
                minCost(i - 1, j - 1));
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
        }
    }
}
