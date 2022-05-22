using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MaximumPointsInAGridUsingTwoGrids
    {
        public static int[,] arr = {{3, 6, 8, 2},
                    {5, 2, 4, 3},
                    {1, 1, 20, 10},
                    {1, 1, 20, 10},
                    {1, 1, 20, 10},
                    };

        public static int R,C;
        public static int[,,] memory;
        public static void execute()
        {
            Intialize();
            Console.WriteLine(  CallTraversal(0,0,C-1));
            Console.ReadLine();
        }

        public static bool isValid(int x, int y1, int y2)
        {
            return (x >= 0 && x < R && y1 >= 0 &&
                    y1 < C && y2 >= 0 && y2 < C);
        }

        public static int CallTraversal(int a, int b, int c)
        {
            if (!isValid(a, b, c))
                return int.MinValue;
            if (a == R - 1 && b == 0 && c == C - 1)
                return b == c ? arr[R - 1, b] :( arr[R - 1, b] + arr[R - 1, c]);
            if (a == R - 1)
                return int.MinValue;
            if (memory[a,b,c] != -1) return memory[a, b, c];
            int ans = int.MinValue;
            int temp = ((b == c) ? arr[R - 1, b] : (arr[R - 1, b] + arr[R - 1, c]));

            ans = Math.Max(ans, temp + CallTraversal(a + 1, b - 1, c));
            ans = Math.Max(ans, temp + CallTraversal(a + 1, b +1, c));
            ans = Math.Max(ans, temp + CallTraversal(a + 1, b , c));
            ans = Math.Max(ans, temp + CallTraversal(a + 1, b , c-1));
            ans = Math.Max(ans, temp + CallTraversal(a + 1, b , c+1));
            ans = Math.Max(ans, temp + CallTraversal(a + 1, b-1 , c-1));
            ans = Math.Max(ans, temp + CallTraversal(a + 1, b - 1, c+1));
            ans = Math.Max(ans, temp + CallTraversal(a + 1, b +1, c-1));
            ans = Math.Max(ans, temp + CallTraversal(a + 1, b +1, c+1));

            memory[a, b, c] = ans;
            return ans;
        }

        public static void Intialize()
        {
            R = 5; C = 4;
            memory = new int[R, C, C];
            for (int ii = 0; ii < R; ii++)
            {
                for (int jj = 0; jj < C; jj++)
                {
                    for (int kk = 0; kk < C; kk++)
                    {
                        memory[ii, jj, kk] = -1;
                    }
                }
            }
        }
    }
}
