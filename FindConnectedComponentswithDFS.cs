using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class FindConnectedComponentswithDFS
    {
        static Dictionary<int, List<int>> AdjacencyList;
        static int Source;
        static int max;
        static bool[] Visited;
        static int components;
        public static void execute()
        {
            AdjacencyList = new Dictionary<int, List<int>>();
            AddVertexes();
            Visited = new bool[max + 1];
            components = 0;
            foreach (var v in AdjacencyList)
            {
                if (!Visited[v.Key])
                {
                    components++;
                    DFSTraversal(v.Key);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Number of Components"+components);
            Console.ReadLine();
        }


        public static void DFSTraversal(int vertex)
        {
            Visited[vertex] = true;
            Console.Write(vertex+" ");
            if(AdjacencyList.ContainsKey(vertex))
                foreach(var v in AdjacencyList[vertex])
                {
                    if(!Visited[v])
                        DFSTraversal(v);
                }

        }
        public static void AddVertexes()
        {
            string s = Console.ReadLine();
            Source = Convert.ToInt32(s);
            s = Console.ReadLine();
            string[] str;
            int key = 0;
            int value = 0;
            max = 0;
            while (!string.IsNullOrEmpty(s))
            {
                str = s.Trim().Split(' ');
                key = Convert.ToInt32(str[0]);
                if(str.Length>1)
                    value = Convert.ToInt32(str[1]);
                if (AdjacencyList.ContainsKey(key))
                    AdjacencyList[key].Add(value);
                else
                {
                    AdjacencyList.Add(key, new List<int>());
                    if(str.Length > 1)
                        AdjacencyList[key].Add(value);
                }
                if (max < key)
                    max = key;
                if (str.Length > 1 && max < value)
                    max = value;
                s = Console.ReadLine();
            }
        }
    }
}
