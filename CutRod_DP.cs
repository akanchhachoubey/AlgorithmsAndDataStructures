using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CutRod_DP
    {
        public static int[] arr;
        public static int[] val;
        public static int size;

        public static void execute()
        {
            arr = new int[] { 1, 5, 8, 9, 10, 17, 17, 20 };
            size = arr.Length;
            val = new int[size + 1];
            for (int i = 0; i <= size; i++)
            {
                val[i] = int.MinValue;
            }
            Console.WriteLine(CutRod(size));
            Console.ReadLine();
        }

        public static int CutRod(int n)
        {
            val[0] = 0;

            // Build the table val[] in 
            // bottom up manner and return 
            // the last entry from the table 
            for (int i = 1; i <= n; i++)
            {
                int max_val = int.MinValue;
                for (int j = 0; j < i; j++)
                    max_val = Math.Max(max_val,
                              arr[j] + val[i - j - 1]);
                val[i] = max_val;
            }
            return val[n];
        }
    }
}
