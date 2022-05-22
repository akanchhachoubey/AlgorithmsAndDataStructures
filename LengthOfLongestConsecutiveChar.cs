using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class LengthOfLongestConsecutiveChar
    {
        public static char[,] mat;
        public static int row, col;
        public static int[] x = { 0, 1, 1, -1, 1, 0, -1, -1 };
        public static int[] y = { 1, 0, 1, 1, -1, -1, 0, -1 };
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(getLen( 'a'));
            Console.WriteLine(getLen( 'e'));
            Console.WriteLine(getLen( 'b'));
            Console.WriteLine(getLen( 'f'));
            Console.Read(); 
        }
        public static int getLen(char c)
        {
            int max = int.MinValue;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mat[i, j] == c)
                    {
                        int val = getlonlen(c,i,j);
                        max = max > val ? max : val;
                    }
                }
            }
            return max==int.MinValue?0:max;
        }

        public static bool isvalid(int i, int j)
        {
            if (i < 0 || j < 0 || i >= row || j >= col)
                return false;
            return true;
        }

        public static bool isadjacent(char prev, char curr)
        {
            return ((curr - prev) == 1);
        }
        public static int getlonlen(char c, int i, int j)
        {
            int count = 1;
            for (int span = 0; span < x.Length; span++)
            {
                int nextvalidx = i + x[span];
                int nextvalidy = j + y[span];

                if (!isvalid(nextvalidx, nextvalidy) || !(isadjacent(c, mat[nextvalidx, nextvalidy])))
                    continue;
                count = 1+ getlonlen(mat[nextvalidx, nextvalidy], nextvalidx, nextvalidy);
            }
            return count;
        }

        public static void TakeInputs()
        {
            mat = new [,]{ {'a','c','d'},
                        { 'h','b','a'},
                        { 'i','g','f'}};

            row = 3;
            col = 3;
        }
    }
}
