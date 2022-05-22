using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class LongestPallindromeSequenceRecursive
    {
        public static char[] arr;
        public static int N;

        public static void execute()
        {
            string seq = "GEEKSFORGEEKS";
            arr = seq.ToCharArray();
            N = seq.Length;
            Console.WriteLine(   LCSUbS(0,N-1));
            Console.ReadLine();
        }

        public static int LCSUbS(int i,int j)
        {
            if (i == j)
                return 1;
            else if (i + 1 == j  && arr[i] == arr[j])
            {
                return 2;
            }
            else
            {
                if(arr[i]==arr[j])
                {
                    return LCSUbS(i + 1, j - 1) + 2;
                }
                else
                {
                    return max(LCSUbS(i, j-1), LCSUbS(i+1,j));
                }
            }
        }

        public static int max(int i, int j)
        {
            return i > j ? i : j;
        }
    }
}
