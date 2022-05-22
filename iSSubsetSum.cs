using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class iSSubsetSum
    {
        public static int[] val;
        public static int sum;
        public static int n;
        public static void execute()
        {
            TakeInputs();
            if (sum % 2 == 1)
                Console.WriteLine("false");
            else
            {
                Console.WriteLine(isSubset(n - 1, sum/2));
            }
            Console.ReadLine();
        }

        public static bool isSubset(int i, int j)
        {
            if (i < 0 && j > 0)
                return false;
            if (j == 0)
                return true;
            if(j>val[i])
            {
                return isSubset(i - 1, j);
            }
            else
            {
                return isSubset(i - 1, j) || isSubset(i - 1, j - val[i]);
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
            val = new int[] { 60, 100, 42 };
            n = val.Length;
            sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += val[i];
            }
        }
    }
}
