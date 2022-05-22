using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MinJumpsRecursive
    {
        public static int[] arr;
        public static int n;
        public static int count;
        public static void execute()
        {
            TakeInputs();
            //MinJumps(0,n-1);
            Console.WriteLine(MinJumps(0, n - 1));
            Console.ReadLine();
        }

        public static int MinJumps(int start, int end)
        {
            if (start == end && arr[start] != 0)
                return 0;
            else if (arr[start] == 0) return int.MaxValue;
            else if (start >= 0 && end <= n - 1)
            {
                int k = arr[start];
                int min = int.MaxValue;
                for (int i = start+1; i <= k+start && i<n; i++)
                {
                    int x = MinJumps(i, end);
                    if (x != int.MaxValue && x + 1 < min)
                        min = x + 1;
                }
                return min;
            }
            else return int.MaxValue;
        }

        public static void TakeInputs()
        {
            arr = new int[] { 1, 3, 6, 3, 2, 3, 6, 8, 9, 5 };
            n = arr.Length;
        }
    }
}
