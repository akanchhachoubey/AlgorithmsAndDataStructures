using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class CutRodRecursive
    {
        public static int[] arr;
        public static int size;

        public static void execute()
        {
            arr = new int[] { 1, 5, 8, 9, 10, 17, 17, 20 };
            size = arr.Length;
            Console.WriteLine( CutRod(size));
            Console.ReadLine();
        }

        public static int CutRod(int n)
        {
            if (n <= 0)
                return 0;
            else
            {
                int max = int.MinValue;
                for (int i = 0; i < n; i++)
                {
                    int c = arr[i] + CutRod(n - (i + 1));
                    if (max < c)
                        max = c;
                }
                return max;
            }
        }
    }
}
