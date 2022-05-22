using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class GetShortestPathBetweenTwoPrimes
    {
        public static Dictionary<int, bool> IsPrime;
        public static Dictionary<int, List<int>> AdjacencyList;
        public static Dictionary<int,bool> Visited;
        public static Dictionary<int, int> Path;
        public static int count = 0;
        public static int N1;
        public static int N2;
        public static void execute()
        {
            IsPrime = new Dictionary<int, bool>();
            AdjacencyList = new Dictionary<int, List<int>>();
            Visited = new Dictionary<int, bool>();
            Path = new Dictionary<int, int>();
            TakeInputs();
            SieveOfEratosthenes();
            CreateGraph();
            BFSTraversal(N1, N2);
            Console.WriteLine(Path[N2]);
            Console.Read();
        }
        public static void SieveOfEratosthenes()
        {
            for (int i = 2; i <= 9999; i++)
                IsPrime.Add(i, true);
            int p = 2;

            while (p*p < 9999)
            {
                for (int j = p * p; j < 9999; j += p)
                {
                    IsPrime[j] = false;
                }
                p = IsPrime.First(x => x.Key > p && x.Value).Key;
            }
        }

        public static void CreateGraph()
        {
            foreach(var p in IsPrime)
            {
                if (p.Value && p.Key>1000)
                {
                    AdjacencyList.Add(p.Key, new List<int>());
                    Visited.Add(p.Key, false);
                }
            }
            
            foreach(var i in AdjacencyList)
            {
                foreach (var j in AdjacencyList)
                {
                    if(ValidCount(i.Key,j.Key))
                    {
                        AdjacencyList[i.Key].Add(j.Key);
                        AdjacencyList[j.Key].Add(i.Key);
                    }
                }
            }
        }

        public static bool ValidCount(int i,int j)
        {
            string s1 = i.ToString();
            string s2 = j.ToString();
            int num = 0;
            if (s1[0] != s2[0]) num++;
            if (s1[1] != s2[1]) num++;
            if (s1[2] != s2[2]) num++;
            if (s1[3] != s2[3]) num++;
            if (num == 1) return true;
            return false;
        }

        public static void TakeInputs()
        {
            string s= Console.ReadLine();
            string[] str = s.Split(' ');
            N1 = Convert.ToInt32(str[0]);
            N2 = Convert.ToInt32(str[1]);
        }

        public static void BFSTraversal(int n1,int n2)
        {
            int N = AdjacencyList.Count();
            
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n1);
            Visited[n1] = true;
            Path[n1] = 0;
            while (queue.Count != 0)
            {
                int vertex = queue.Dequeue();

                if (AdjacencyList.ContainsKey(vertex))
                    foreach (int vertexes in AdjacencyList[vertex])
                    {
                        if (!(Visited[vertexes]))
                        {
                            queue.Enqueue(vertexes);
                            Visited[vertexes] = true;
                            Path[vertexes] = Path[vertex] + 1;

                        }
                        if (vertexes == n2)
                            return ;
                    }
            }
        }
    }
}
