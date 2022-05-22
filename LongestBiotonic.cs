using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class LongestBiotonic
    {
        public static int[] Arr;
        public static int[] LIS;
        public static int[] DIS;
        public static int N;

        public static void execute()
        {
            TakeInputs();
            RunLIS(N - 1);
            RunDIS(0);
            int max = LIS[0]+DIS[0]-1;
            for (int i = 1; i < N; i++)
            {
                max = max > LIS[i]+DIS[i]-1 ? max : LIS[i] +DIS[i]-1;
            }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        public static void RunLIS(int n)
        {
            if (LIS[n] == 0 && n > 0)
            {
                if (Arr[n] > Arr[n - 1])
                {
                    if (LIS[n - 1] == 0)
                        RunLIS(n - 1);
                    LIS[n] = LIS[n - 1] + 1;
                }
                else
                {
                    if (LIS[n - 1] == 0)
                        RunLIS(n - 1);
                    LIS[n] = LIS[n - 1];
                }
            }

        }

        public static void RunDIS(int n)
        {
            if (DIS[n] == 0 && n <N)
            {
                if (Arr[n] > Arr[n + 1])
                {
                    if (DIS[n + 1] == 0)
                        RunDIS(n + 1);
                    DIS[n] = DIS[n + 1] + 1;
                }
                else
                {
                    if (DIS[n + 1] == 0)
                        RunDIS(n + 1);
                    DIS[n] = DIS[n + 1];
                }
            }

        }

        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            N = Convert.ToInt32(s);
            Arr = new int[N];
            LIS = new int[N];
            DIS = new int[N];
            s = Console.ReadLine();
            string[] str = s.Split(' ');
            for (int i = 0; i < N; i++)
            {
                Arr[i] = Convert.ToInt32(str[i]);
                LIS[i] = 0;
                DIS[i] = 0;
            }
            LIS[0] = 1;
            DIS[N - 1] = 1;
        }
    }
}
