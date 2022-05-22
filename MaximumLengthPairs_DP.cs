using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MaximumLengthPairs_DP
    {
        public static SortedDictionary<int, int> Pairs;
        public static Dictionary<int, int> Selected;
        public static void execute()
        {
            TakeInputs();
            RunLIS();
            foreach(var item in Selected)
            {
                Console.WriteLine(item.Key+" " +item.Value);
            }
            Console.Read();
        }


        public static void RunLIS()
        {
            if(Pairs.Count()>1)
                Selected.Add(Pairs.First().Key,Pairs.First().Value);
            foreach(var item in Pairs)
            {
               if(Selected.Last().Value<Pairs.Keys.First(x=>x == item.Key))
                {
                    Selected.Add(item.Key, item.Value);
                }
            }
        }
        public static void TakeInputs()
        {
            Pairs = new SortedDictionary<int, int>();
            Pairs.Add(5, 24);
            Pairs.Add(15, 25);
            Pairs.Add(27, 40);
            Pairs.Add(50, 60);
            Selected = new Dictionary<int, int>();
        }
    }
}
