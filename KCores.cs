using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class KCores
    {
        public static Dictionary<int, List<int>> AdjacencyList;
        public static int N;
        public static int K;

        public static void execute()
        {
            AdjacencyList = new Dictionary<int, List<int>>();
            TakeInput();
            //run DFS 
            int j = AdjacencyList.FirstOrDefault(x => x.Value.Count <= 2).Key;
            while(j>=0)
            {
                List<int> value = AdjacencyList[j];
                int i = value.Count-1;
                while (i >= 0)
                {
                    RunDFS(j, value[i]);
                    i = value.Count-1;
                }
                AdjacencyList.Remove(j);
                var node = AdjacencyList.FirstOrDefault(x => x.Value.Count <= 2);
                if (node.Value != null && node.Value.Count <= 2)
                    j = node.Key;
                else
                    j = -1;
            }
            j = AdjacencyList.FirstOrDefault().Key;
            while(AdjacencyList.ContainsKey(j))
            {
                Console.Write(j);
                List<int> value = AdjacencyList[j];
                for (int i=0;i< value.Count;i++)
                {
                    Console.Write("-->"+ value[i]);
                }
                AdjacencyList.Remove(j);
                j = AdjacencyList.FirstOrDefault().Key;
                Console.WriteLine( );
            }
            
            Console.ReadLine();
        }

        public static void RunDFS(int key, int value)
        {
            AdjacencyList[key].Remove(value);
            if(AdjacencyList.ContainsKey(value))
            {
                AdjacencyList[value].Remove(key);
                if (AdjacencyList[value].Count <= 2)
                {
                    RunDFS(value, AdjacencyList[value].First());
                }
            }            
        }

            public static void TakeInput()
        {
            string s = Console.ReadLine();
            N = Convert.ToInt32(s);
            s = Console.ReadLine();
            string[] str;
            int key;
            int value;
            while (!string.IsNullOrEmpty(s))
            {
                str = s.Split(' ');
                key = Convert.ToInt32(str[0]);
                if (AdjacencyList.Any(x => x.Key == key))
                {
                    if (str.Length > 0)
                    {
                        value = Convert.ToInt32(str[1]);
                        AdjacencyList[key].Add(value);
                    }
                }
                else
                {
                    List<int> v = new List<int>();
                    if (str.Length > 0)
                    {
                        value = Convert.ToInt32(str[1]);
                        v.Add(value);
                    }
                    AdjacencyList.Add(key, v);
                }
                if(str.Length>1)
                {
                    value = Convert.ToInt32(str[1]); ;
                    if (AdjacencyList.Any(x => x.Key == value))
                    {
                        AdjacencyList[value].Add(key);                        
                    }
                    else
                    {
                        List<int> v = new List<int>();
                        v.Add(key);
                        
                        AdjacencyList.Add(value, v);
                    }
                }

                s = Console.ReadLine();
            }

        }
    }
}
