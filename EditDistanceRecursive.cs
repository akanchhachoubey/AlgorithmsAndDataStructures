using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class EditDistanceRecursive
    {
        public static char[] M;
        public static char[] N;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(EditDist(M.Count() - 1, N.Count() - 1));
            Console.ReadLine();
        }

        public static int EditDist(int m, int n)
        {
            if (m > 0 && n > 0)
            {
                if (M[m] == N[n])
                {
                    return EditDist(m - 1, n - 1);
                }
                else return min(EditDist(m, n - 1),
                                EditDist(m - 1, n),
                                EditDist(m-1,n-1));
            }
            else
            {
                if (M[m] == N[n])
                    return 0;
                else return 1;
            }

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
