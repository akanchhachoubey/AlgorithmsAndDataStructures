using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class NonRecursiveLIS
    {
        public static int[] Arr;
        public static int[] LIS;
        public static int N;

        public static void execute()
        {
            TakeInputs();
            RunLIS(N - 1);
            int max = LIS[0];
            for (int i = 1; i < N; i++)
            {
                max = max > LIS[i] ? max : LIS[i];
            }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        public static void RunLIS(int n)
        {
            for (int i = 1; i < N; i++)
            {
                for(int j=0;j<i;j++)
                {
                    if (Arr[i] > Arr[j] && LIS[i] < LIS[j] + 1)
                        LIS[i] = LIS[j] + 1;
                }
            }

        }

        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            N = Convert.ToInt32(s);
            Arr = new int[N];
            LIS = new int[N];
            s = Console.ReadLine();
            string[] str = s.Split(' ');
            for (int i = 0; i < N; i++)
            {
                Arr[i] = Convert.ToInt32(str[i]);
                LIS[i] = 1;
            }
        }
    }
}
