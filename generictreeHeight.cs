using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class generictreeHeight
    {
        public static int N;
        public static int[] Parent;
        public static Dictionary<int, List<int>> AdjacencyList;
        public static List<bool> Visited;
        public static List<int> Level;
        public static int level = 0;
        public static void execute()
        {
            TakeInputs();
            CreateAdjacencyList();
            BFSTraversal(0);
            int max = Level[0];
            for (int i = 0; i < N; i++)
            {
                if (Level[i] > max)
                    max = Level[i];
            }
            Console.WriteLine(max-1);
            Console.ReadLine();
        }

        public static void BFSTraversal(int node    )
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(node);
            Visited[node] = true;
            Level[node] = 1;
            while (qu.Count>0)
            {
                int vertex = qu.Dequeue();
                Visited[vertex] = true;
                foreach (var item in AdjacencyList[vertex])
                {
                    if (!Visited[item])
                    {
                        qu.Enqueue(item);
                        Level[item] = Level[vertex] + 1;
                    }
                }
            }
        }
        public static void CreateAdjacencyList()
        {
            AdjacencyList.Add(0, new List<int>());
            for (int i =  1  ; i < N; i++)
            {
                AdjacencyList.Add(i, new List<int>());
                AdjacencyList[Parent[i]].Add(i);
            }
        }
        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            N = Convert.ToInt32(s);
            s = Console.ReadLine();
            string[] str = s.Split(' ');
            Parent = new int[N];
            Visited = new List<bool>(N);
            Level = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                Parent[i] = Convert.ToInt32(str[i]);
                Visited.Add(false);
                Level.Add(0);
            }
            AdjacencyList = new Dictionary<int, List<int>>();
        }
    }
}
