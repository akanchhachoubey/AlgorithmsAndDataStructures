using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class MCM_DP
    {
        public static int[] arr;
        public static int n;
        public static int[,] L_MCM;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(MCM(1, n - 1));
            Console.ReadLine();
        }

        public static int MCM(int i, int j)
        {
            if (i == j || i==0 || j==0)
                L_MCM[i,j]= 0;

            int a = 0, b = 0;
            for (int k = i; k < j; k++)
            {
                if (L_MCM[i, k] == int.MaxValue)
                {
                    L_MCM[i,k] = MCM(i, k);
                }

                a = L_MCM[i, k];
                if (L_MCM[k+1, j] == int.MaxValue)
                {
                    L_MCM[k+1, j] = MCM(k+1, j);
                }
                b = L_MCM[k + 1, j];
                int count = arr[i - 1] * arr[k] * arr[j] + a +b;

                if (L_MCM[i, j] > count)
                    L_MCM[i, j] = count;
            }
            return L_MCM[i, j];
        }

        public static void TakeInputs()
        {
            arr = new int[] { 1, 2, 3, 4, 3 };
            n = arr.Length;
            L_MCM = new int[n, n];
            for(int i=0;i<n;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    L_MCM[i, j] = int.MaxValue;
                }
            }
        }
    }
}
