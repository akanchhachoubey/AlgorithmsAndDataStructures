using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MaxProfitBuyingandSellingShareTwice
    {
        public static int[] price = { 10, 22, 5, 75, 65, 80 };
        //public static int[] price = { 2, 30, 15, 10, 8, 25, 80 };
        public static int N;
        public static void execute()
        {
            N = price.Length;
            Console.WriteLine(   RunAlgo(N - 1, 2));
            Console.WriteLine(RunAlgo2(0,N-1,2));
            Console.WriteLine(maxProfit(N));
            Console.ReadLine();
        }

        public static int RunAlgo(int len, int count)
        {
            if (count <= 0 || len<=0)
                return 0;

             int min = price[len];
                int max = price[len];
                int profit = 0;
                while (len > 0 && price[len] > price[len - 1])
                {
                    max = max > price[len - 1] ? max : price[len - 1];
                    min = min < price[len - 1] ? min : price[len - 1];
                len--;
                }
                profit = profit>(max - min)?profit:(max-min);
                int remain = Math.Max(RunAlgo(len-1 , count - 1) + profit, RunAlgo(len-1 , count));
                return remain;
            
        }

        public static int RunAlgo2(int start, int len, int count)
        {
            if (count <= 0 || len <= 0 ||start<0 || len>N)
                return 0;

            int min = price[len];
            int max = price[len];
            int minindex = len;
            int maxindex = len;
            int profit = 0;
            int remain = 0;
            while (len > start)
            {
                max = max > price[len - 1] ? max : price[len - 1];
                if (max == price[len - 1]) maxindex = len - 1;
                min = min < price[len - 1] ? min : price[len - 1];
                if (min == price[len - 1]) minindex = len - 1;
                len--;
            }
            if (maxindex > minindex)
            {
                profit = profit > (max - min) ? profit : (max - min);
                remain = RunAlgo2(start,minindex - 1, count - 1) + profit;
            }
            else
            {
                remain = RunAlgo2(start, maxindex, count - 1) + RunAlgo2(minindex, len, count - 1);
            }
            return remain;

        }

        public static int maxProfit( int n)
        {

            int[] profit = new int[n];
            for (int i = 0; i < n; i++)
                profit[i] = 0;

            int max_price = price[n - 1];

            for (int i = n - 2; i >= 0; i--)
            {

                if (price[i] > max_price)
                    max_price = price[i];

                profit[i] = Math.Max(profit[i + 1],
                              max_price - price[i]);
            }

            int min_price = price[0];

            for (int i = 1; i < n; i++)
            {
                
                if (price[i] < min_price)
                    min_price = price[i];

                profit[i] = Math.Max(profit[i - 1],
                           profit[i] + (price[i]
                                  - min_price));
            }
            int result = profit[n - 1];

            return result;
        }

    }
}
