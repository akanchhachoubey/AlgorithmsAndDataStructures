using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.cs
{
    public class CoinChangeRecursive
    {
        public static int[] arr;
        public static int m;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(CoinChangeCount(m,4));
            Console.ReadLine();
        }

        public static int CoinChangeCount(int m, int n)
        {
            // If n is 0 then there is 1 solution  
            // (do not include any coin) 
            if (n == 0)
                return 1;

            // If n is less than 0 then no  
            // solution exists 
            if (n < 0)
                return 0;

            // If there are no coins and n  
            // is greater than 0, then no 
            // solution exist 
            if (m <= 0 && n >= 1)
                return 0; //if change is not teher but money to be changed is there then no solution
            else
                return CoinChangeCount(m-1, n) //either do  not include the soltion
                    + CoinChangeCount(m, n - arr[m-1]); //include the soltion and decrease the sum value

        }
        public static void TakeInputs()
        {
            arr = new[] { 1, 2, 3 };
            m = arr.Length;
        }
    }
}
