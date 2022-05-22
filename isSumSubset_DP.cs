using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class isSumSubset_DP
    {
        public static int[] val;
        public static bool[,] isPossible;
        public static int sum;
        public static int n;
        public static void execute()
        {
            TakeInputs();
            if (sum % 2 == 1)
                Console.WriteLine("false");
            else
            {
                isPossible = new bool[sum / 2 +1, n + 1];
                Console.WriteLine(isSubset( sum /2 +1,n+1));
            }
            Console.ReadLine();
        }

        public static bool isSubset(int m, int n)
        {
            for (int i = 0; i < n; i++)
            {
                isPossible[0, i] = true;
            }

            for (int i = 1; i < m; i++)
            {
                isPossible[i,0] = false;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (i < val[j-1])
                        isPossible[i, j] = isPossible[i, j - 1];
                    else
                    {
                        isPossible[i, j] = isPossible[i, j - 1] || isPossible[i - val[j-1], j - 1];
                    }
                }
            }

            return (isPossible[m-1, n-1]);
        }

        public static int mAX(int i, int j)
        {
            if (i > j)
                return i;
            else return j;
        }

        public static void TakeInputs()
        {
            val = new int[] { 60, 100, 40 };
            n = val.Length;
            sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += val[i];
            }

        }
    }
}
