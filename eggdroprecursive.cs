using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class eggdroprecursive
    {
        public static int N, K;
        public static void execute()
        {
            N = 2;
            K = 10;

            Console.WriteLine(eggdrop(N, K));
            Console.ReadLine();
        }

        //k floors
        //n eggs
        public static int eggdrop(int n, int k)
        {
            if (k == 0 || k == 1)
                return 1;

            else if (n == 1)
                return k;

            else
            {
                int Min = int.MaxValue;
                for (int i = 1; i < k; i++)
                {
                    int a = max(eggdrop(n - 1, i - 1), eggdrop(n, k - i));
                    if (a < Min)
                        Min = a;
                }
                return Min+1;
            }
        }

        public static int max(int i,int j)
        {
            return i > j ? i : j;
        }

        public static int min(int i, int j)
        {
            return i > j ? j : i;
        }
    }
}
