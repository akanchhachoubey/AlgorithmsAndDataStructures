using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MobileNumericKeypad
    {
        public static int[,] keypad = new int[4, 3] {
        {1,2,3 },
        {4,5,6 },
        {7,8,9 },
        { -1,0,-1}
        };

        public static int[] row = { 0, 0, -1, 0, 1 };
        public static int[] col = { 0, -1, 0, 1, 0 };

        public static int N = 2;
        public static void execute()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int k = 0;
                    if (keypad[i, j] != -1)
                        k = RunDFS(i, j, N);
                    else
                        k = 0;
                    count += k;
                }
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }

        public static int RunDFS(int n, int m, int l)
        {
            if (l <= 0)
                return 0;

            // From a given key, only one  
            // number is possible of length 1 
            if (l == 1)
                return 1;

            int k = 0, move = 0, ro = 0, co = 0, totalCount = 0;

            // move left, up, right, down 
            // from current location and if 
            // new location is valid, then  
            // get number count of length 
            // (n-1) from that new position  
            // and add in count obtained so far 
            if(l>1)
                for (move = 0; move < 5; move++)
                {
                    ro = n + row[move];
                    co = m + col[move];
                    if (ro >= 0 && ro <= 3 && co >= 0 && co <= 2 &&
                    keypad[ro, co] != -1 && keypad[ro, co] != -1)
                    {
                        totalCount += RunDFS( ro, co, l - 1);
                    }
                }
            return totalCount;
        }
    }
}
