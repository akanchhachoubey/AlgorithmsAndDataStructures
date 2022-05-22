using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MinPallindromePartitioning
    {
        public static int[,] P;
        public static bool[,] C;
        public static char[] Arr;
        public static int N;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(   CallMInPallindrome());
            Console.ReadLine();
        }

        public static int CallMInPallindrome()
        {
            for (int l = 2 ; l <= N; l++)
            {
                for (int i = 0; i < N-l+1; i++)
                {
                    int j = i + l - 1;
                    if(l==2)
                    {
                        C[i, j] = Arr[i] == Arr[j];
                    }
                    else
                    {
                        C[i, j] = Arr[i] == Arr[j] && C[i + 1, j - 1];
                    }

                    if (C[i, j])
                        P[i, j] = 0;
                    else
                    {
                        P[i, j] = int.MaxValue;
                        for (int k = i; k < j; k++)
                        {
                            P[i, j] = Math.Min(P[i, j], P[i,k]+P[k + 1, j]+1);
                        }
                    }

                }
            }
            return P[0, N-1];
        }

        public static void TakeInputs()
        {
            String str = "ababbbabbababa";
            Arr = str.ToCharArray();
            int n = Arr.Length;
            P = new int[n, n];
            C = new bool[n, n];
            N = n;
            for (int i = 0; i < n; i++)
            {
                P[i, i] = 0;
                C[i, i] = true;
            }
        }
    }
}
