using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MinJumps_DP
    {
        public static int[] arr;
        public static int n;
        public static int count;
        public static int[] jumps;
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
            {
                jumps[start] = 0;
                return 0;
            }
            else if (arr[start] == 0)
            {
                jumps[start] = int.MaxValue;
                return int.MaxValue;
            }
            else if (start >= 0 && end <= n - 1)
            {
                for (int i = 1; i <= end; i++)
                {
                    jumps[i] = int.MaxValue;
                    for (int j = 0; j <i; j++)
                    {
                        if (i <= j + arr[j] && jumps[j] != int.MaxValue)
                        {
                            jumps[i] = Math.Min(jumps[i], jumps[j] + 1);
                            break;
                        }
                    }
                }
                return jumps[n - 1];
            }
            else return int.MaxValue;
        }

        public static void TakeInputs()
        {
            arr = new int[] { 1, 3, 6, 3, 2, 3, 6, 8, 9, 5 };
            n = arr.Length;
            jumps = new int[n];
            jumps[0] = 0;
        }
    }
}
