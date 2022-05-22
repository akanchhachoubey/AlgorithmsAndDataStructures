using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class MCM_Recursive
    {
        public static int[] arr;
        public static int n;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(MCM(1, n - 1));
            Console.ReadLine();
        }

        public static int MCM(int i,int j)
        {
            if (i == j)
                return 0;
            int min = int.MaxValue;
            for (int k = i; k < j; k++)
            {
                int count = arr[i - 1] * arr[k] * arr[j] +
                    MCM(i, k) + MCM(k + 1, j);
                if (min > count)
                    min = count;
            }
            return min;
        }

        public static void TakeInputs()
        {
            arr = new int[] { 1, 2, 3, 4, 3 };
            n = arr.Length;
        }
    }
}
