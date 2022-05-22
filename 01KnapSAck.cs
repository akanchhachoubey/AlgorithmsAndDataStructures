using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class _01KnapSAck
    {
        public static int[] val;
        public static int[] wt;
        public static int W;
        public static int n;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(knap(n-1, W));
            Console.ReadLine();
        }

        public static int knap(int i, int j)
        {
            int a = 0, b = 0;
            if (j == 0 || i == 0)
                return 0;
            else
            {
                if(wt[i]>j)
                {
                    return knap(i - 1, j );
                }
                a = val[i] + knap(i - 1, j - wt[i]);
                b = knap(i - 1, j);
                return mAX(a, b);
            }
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
            n = val.Length;
        }
    }
}
