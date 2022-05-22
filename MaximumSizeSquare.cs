using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MaximumSizeSquare
    {
        public static int[,] M;
        public static int[,] N;
        public static int l, b;
        public static void execute()
        {
            TakeInputs();
            RunMaxSquare();
            int max = int.MinValue;
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(N[i,j]+" ");
                    max = max > N[i, j] ? max : N[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        public static void RunMaxSquare()
        {
            for (int i = 1; i < l; i++)
            {
                for (int j = 1; j < b; j++)
                {
                    if (M[i, j] == 1)
                    {
                        N[i, j] = Math.Min(N[i - 1, j - 1], Math.Min(N[i - 1, j], N[i, j - 1])) + 1;
                    }
                    else
                        N[i, j] = 0;
                }
            }
        }

        public static void TakeInputs()
        {
            M = new int[6, 5]{{0, 1, 1, 0, 1},
                    {1, 1, 0, 1, 0},
                    {0, 1, 1, 1, 0},
                    {1, 1, 1, 1, 0},
                    {1, 1, 1, 1, 1},
                    {0, 0, 0, 0, 0}};
            l = 6;
            b = 5;
            N = new int[6, 5];
            for (int i = 0; i < 6; i++)
            {
                N[i, 0] = M[i, 0];
            }

            for (int i = 0; i < 5; i++)
            {
                N[0,i] = M[0,i];
            }

        }
    }
}
