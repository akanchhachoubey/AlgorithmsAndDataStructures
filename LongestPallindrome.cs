using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class LongestPallindrome
    {
        public static char[] str;
        public static int n;
        public static int[,] len;

        public static void execute()
        {
            TakeINputs();
            RunPallindrome();
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    max = max > len[i, j] ? max : len[i, j];
                }
            }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        public static void RunPallindrome()
        {
            for (int i = 0; i < n; i++)
            {
                len[i, i] = 1;
            }
            for (int i = 0; i < n-1; i++)
            {
                if (str[i] == str[i + 1])
                    len[i, i + 1] = 2;
            }
            for (int l = 3; l < n; l++)
            {
                for (int i = 0; i < n-l+1; i++)
                {
                    int j = i + l - 1;
                    
                    if(len[i+1,j-1]!=-1 && str[i]==str[j])
                    {
                        len[i, j] = len[i + 1, j - 1] + 2;
                    }
                }
            }
        }

        public static void TakeINputs()
        {
            str = "forgeeksskeegfor".ToCharArray();
            n = str.Length;
            len = new int[n , n ];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    len[i, j] = -1;
                }
            }
        }
    }
}
