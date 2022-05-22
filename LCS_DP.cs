using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class LCS_DP
    {
        public static char[] M;
        public static char[] N;
        public static int[,] L;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(LCSDP());
            Console.ReadLine();
        }

        public static int LCSDP()
        {
            int m = M.Count() ;
            int n = N.Count() ;
            L = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else if (M[i - 1] == N[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = max(L[i - 1, j], L[i, j - 1]);
                }
            }
            return L[m, n];

        }

        public static int max(int i, int j)
        {
            if (i > j)
                return i;
            else return j;
        }

        public static int Max(int i, int j)
        {
            if (i > j)
                return i;
            else return j;
        }

        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            char[] str = s.ToCharArray();
            M = new char[str.Length];
            int i = 0;
            foreach (var item in str)
            {
                M[i++] = item;
            }
            i = 0;
            s = Console.ReadLine();
            str = s.ToCharArray();
            N = new char[str.Length];
            foreach (var item in str)
            {
                N[i++] = item;
            }
        }
    }
}
