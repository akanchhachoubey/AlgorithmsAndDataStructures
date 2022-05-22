using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class BFS
    {
        static Dictionary<int,List<int>> AdjacencyList;
        static int Source;
        static int max;
        static bool[] Visited;
        public static void execute()
        {
            AdjacencyList = new Dictionary<int, List<int>>();
            AddVertexes();
            BFSTraversal();
        }


        public static void BFSTraversal()
        {
            int N = AdjacencyList.Count();
            Visited = new bool[max+1];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(Source);
            Visited[Source] = true;

            while (queue.Count!=0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " " );

                if (AdjacencyList.ContainsKey(vertex))
                    foreach (int vertexes in AdjacencyList[vertex])
                    {
                        if (!(Visited[vertexes]))
                        {
                            queue.Enqueue(vertexes);
                            Visited[vertexes] = true;
                        }
                    }
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
            while(!string.IsNullOrEmpty(s))
            {
                str = s.Trim().Split(' ');
                key = Convert.ToInt32(str[0]);
                value = Convert.ToInt32(str[1]);
                if (AdjacencyList.ContainsKey(key))
                    AdjacencyList[key].Add(value);
                else
                {
                    AdjacencyList.Add(key, new List<int>());
                    AdjacencyList[key].Add(value);
                }
                if (max < key)
                    max = key;
                if (max < value)
                    max = value;
                s= Console.ReadLine();
            }            
        }
    }
}
