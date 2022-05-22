using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class ShortestCommonSuperSequence
    {
        public static string str1 = "geek";
        public static string str2 = "eke";
        public static string common = "";
        public static string Super = "";
        public static void execute()
        {
            int len = RunLCS(str1.Length - 1, str2.Length - 1);
            Console.WriteLine(  len);
            Console.WriteLine(str1.Length+str2.Length-len);
            Console.ReadLine();
        }

        public static int RunLCS(int m , int n)
        {
            if (m == 0 || n == 0)
            {
                return str1[m] == str2[n] ? 1 : 0;
            }
            else if (str1[m] == str2[n])
            {
                return 1 + RunLCS(m - 1, n - 1);
            }
            else
            {
                int a = RunLCS(m, n - 1);
                int b = RunLCS(m - 1, n);
                int max = Math.Max(a, b);
                return max;
            }
        }
    }
}
