using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class FindAllPaths
    {
        public static Dictionary<int, List<int>> AdjacencyList;
        public static int N;
        public static bool[] Visited;
        public static int Source;
        public static int Destination;
        public static int Count = 0;
        public static void execute()
        {
            AdjacencyList = new Dictionary<int, List<int>>();
            TakeInput();
            DFSTraversal(Source);
            Console.WriteLine(Count);
            Console.ReadLine();
        }

        public static void DFSTraversal(int node)
        {
            if(node==Destination)
            {
                Count++;
                return;
            }
            if(!Visited[node])
            {
                Visited[node] = true;
                if(AdjacencyList.ContainsKey(node))
                {
                    List<int> list = AdjacencyList[node];
                    for(int j=0;j<list.Count;j++)
                    {
                        int value = list[j];
                        DFSTraversal(value);
                    }
                }

            }
            Visited[node] = false;
        }

        public static void TakeInput()
        {
            string s = Console.ReadLine();
            N = Convert.ToInt32(s);
            s = Console.ReadLine();
            Source = Convert.ToInt32(s);
            s = Console.ReadLine();
            Destination = Convert.ToInt32(s);
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
                s = Console.ReadLine();
            }

            Visited = new bool[N];
            for (int i = 0; i < N; i++)
            {
                Visited[i] = false;
            }
        }
    }
}
