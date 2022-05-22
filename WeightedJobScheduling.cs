using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class Job:IComparable
    {
        public int start, finish, profit;

        public int CompareTo(object obj)
        {
            Job j = (Job)obj;

            if (finish > j.finish)
                return 1;
            else if (finish < j.finish)
                return -1;
            else return 0;
        }
    };
    public class WeightedJobScheduling
    {
        public static List<Job> arr = new List<Job>();
        
        public static void execute()
        {
            arr.Add(new Job() { start = 3, finish = 10, profit = 20 });
            arr.Add(new Job() { start = 1, finish = 2, profit = 50 });
            arr.Add(new Job() { start = 6, finish = 19, profit = 100 });
            arr.Add(new Job() { start = 2, finish = 100, profit = 200 });
            arr.Sort();
            Console.WriteLine(GetMaxProfit(arr.Count-1));
            Console.Read();            
        }

        public static int FindNextValid(int i)
        {
            for (int j = i-1; j >=0; j--)
            {
                if (arr[j].finish <= arr[i].start)
                    return j;
            }
            return -1;
        }

        public static int GetMaxProfit(int i)
        {
            if (i == 0) return arr[i].profit;
            if (i < 0) return 0;
            //including job
            int includedprofit = arr[i].profit;
            int j = FindNextValid(i);
            if(j!=-1) includedprofit += GetMaxProfit(j);

            int excludedprofit = GetMaxProfit(i - 1);

            return Math.Max(includedprofit, excludedprofit);
        }
    }
}
