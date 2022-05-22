using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public struct node:IComparable
    {
        public int start;
        public int end;
        public int weight;

        //sort descending
        public int CompareTo(object obj)
        {
            node n = (node)obj;
            if (weight > n.weight)
                return -1;
            else if (weight < n.weight)
                return 1;
            else return 0;
        }
    }
    public class MinimalIntialVertices
    {
        public static int[,] grphs;
        public static bool[,] visibility;
        public static int N;
        public static int Max;
        public static List<node> nodes;

        public static void execute()
        {
            TakeInputs();
            nodes = new List<node>();
            FindMax();
            nodes.Sort();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!visibility[nodes[i].start, nodes[i].end])
                {
                    Console.Write(nodes[i].start + "," + nodes[i].end);
                    RunDFS(nodes[i]);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static void RunDFS(node nn)
        {
            if(!visibility[nn.start,nn.end])
            {
                visibility[nn.start, nn.end] = true;
                int n = nn.start;
                int m = nn.end;
                if (n+1<N && grphs[n+1,m]<=grphs[n,m] && !visibility[n+1,m])
                {
                    node _df = nodes.First(x => x.start == n + 1 && x.end == m);
                    RunDFS(_df);
                }
                if (m + 1 < N && grphs[n , m+1] <= grphs[n, m] && !visibility[n , m+1])
                {
                    node _df = nodes.First(x => x.start == n && x.end == m+1);
                    RunDFS(_df);
                }
                if (n-1>=0 && grphs[n -1, m] <= grphs[n, m] && !visibility[n -1, m])
                {
                    node _df = nodes.First(x => x.start == n - 1 && x.end == m);
                    RunDFS(_df);
                }
                if (m-1 >=0 && grphs[n, m-1] <= grphs[n, m] && !visibility[n , m-1])
                {
                    node _df = nodes.First(x => x.start == n && x.end == m-1);
                    RunDFS(_df);
                }
            }
        }

        public static void FindMax()
        {
            for (int i = 0; i < N; i++)  
            {
                for (int j = 0; j < N; j++)
                {
                    node n = new node();
                    n.start = i;
                    n.end = j;
                    n.weight = grphs[i, j];
                    nodes.Add(n);
                }
            }
        }

        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            N = Convert.ToInt32(s);
            s = Console.ReadLine();
            grphs = new int[N, N];
            visibility = new bool[N, N];
            string[] str;
            int j = 0;
            while (!String.IsNullOrEmpty(s))
            {
                str = s.Split(' ');

                for (int i = 0; i < str.Length; i++)
                {
                    grphs[j, i] = Convert.ToInt32(str[i]);
                }
                j++;
                s = Console.ReadLine();
            }

            for (j = 0; j < N; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    visibility[i, j] = false;
                }
            }
        }
    }
}
