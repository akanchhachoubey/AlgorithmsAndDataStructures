using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class RecursiveLCS
    {
        public static char[] M;
        public static char[] N;
        //public static int[,] LCS;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine( LCS(M.Count()-1, N.Count()-1));
            Console.ReadLine();
        }

        public static int LCS(int m, int n)
        {
            if (m > 0 && n > 0)
            {
                if (M[m] == N[n])
                {
                    return 1 + LCS(m - 1, n - 1);
                }
                else return Max(LCS(m, n - 1), LCS(m - 1, n));
            }
            else
            {
                if (M[m] == N[n])
                    return 1;
                else return 0;
            }

        }

        public static int Max(int i,int j)
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
