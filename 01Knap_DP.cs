using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class _01Knap_DP
    {
        public static int[] val;
        public static int[] wt;
        public static int W;
        public static int N;
        public static int[,] K;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(knap(N , W));
            Console.ReadLine();
        }

        public static int knap(int n, int w)
        {
            int a = 0, b = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= w; j++)
                {
                    if (i == 0 || j == 0)
                        K[i, j] = 0;
                    else if(wt[i-1]<=j)
                    {
                        a = K[i - 1, j - wt[i-1]] + val[i-1];
                        b = K[i - 1, j];
                        K[i, j] = mAX(a, b);
                    }
                    else
                    {
                        K[i, j] = K[i - 1, j];
                    }
                }

            }
            return K[N, W];
        }

        public static int mAX(int i, int j)
        {
            if (i > j)
                return i;
            else return j;
        }

        public static void TakeInputs()
        {
            val = new int[] { 60, 100, 120 };
            wt = new int[] { 10, 20, 30 };
            W = 50;
            N = val.Length;
            K = new int[N + 1, W + 1];
        }
    }
}
