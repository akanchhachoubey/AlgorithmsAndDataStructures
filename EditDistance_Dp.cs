using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class EditDistance_Dp
    {
        public static char[] M;
        public static char[] N;
        public static int[,] L;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(EditDist(M.Count(), N.Count() ));
            Console.ReadLine();
        }

        public static int EditDist(int m, int n)
        {
            L = new int[m + 1, n + 1];
            for(int i=0;i<=m;i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                        L[i, j] = j;
                    else if (j == 0)
                        L[i, j] = i;
                    else if (M[i-1] == N[j-1])
                        L[i, j] = L[i - 1, j - 1];
                    else L[i, j] = 1+ min(L[i, j - 1],
                        L[i - 1, j],
                        L[i - 1, j - 1]);
                }
            }
            return L[m, n];
        }

        public static int min(int i, int j, int k)
        {
            if (i > j && k > j)
                return j;
            else if (i > k && j > k)
                return k;
            else return i;
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
