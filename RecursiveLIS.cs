using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class RecursiveLIS
    {
        public static int[] Arr;
        public static int[] LIS;
        public static int N;

        public static void execute()
        {
            TakeInputs();
            RunLIS(N-1);
            int max = LIS[0];
            for(int i=1;i<N;i++)
            {
                max = max > LIS[i] ? max : LIS[i];
            }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        public static void RunLIS(int n)
        {
            if (LIS[n] == 0 && n>0)
            {
                if (Arr[n] >= Arr[n - 1])
                {
                    if (LIS[n - 1] == 0)
                        RunLIS(n - 1);
                    LIS[n] = LIS[n - 1] + 1;
                }
                else
                {
                    int j = -1;
                    while (j > n || j==-1)
                        j = Arr.LastOrDefault(x => x < Arr[n]);
                    if (j != 0)
                    {
                        if(LIS[j]==0) RunLIS(j);
                        LIS[n] = LIS[j] + 1;
                    }
                    else
                    {
                        LIS[n] = 1;
                    }
                    if (LIS[n - 1] == 0)
                        RunLIS(n - 1);
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
                LIS[i] = 0;
            }
            LIS[0] = 1;
        }
    }
}
