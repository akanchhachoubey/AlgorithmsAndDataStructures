using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class TransitiveClosure
    {
        public static Dictionary<int, List<int>> AdjacencyList;
        public static int N;
        public static int[,] closure;
        public static bool[] Visited;
        public static void execute()
        {
            AdjacencyList = new Dictionary<int, List<int>>();
            TakeInput();
             for (int j = 0; j < N; j++)
                {
                    RunDFSClosure(j, j);
                }
            
            PrintOp();
            Console.ReadLine();
        }


        public static void PrintOp()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(closure[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void RunDFSClosure(int start, int i)
        {
            closure[start, i] = 1;
            if (AdjacencyList.ContainsKey(i))
            {
                List<int> value = AdjacencyList[i];
                for (int j = 0; j < value.Count; j++)
                {
                    if (closure[i,value[j]]==0)
                    {
                        RunDFSClosure(start, value[j]);
                    }
                    else
                        closure[start,value[j]] = 1;
                }
            }

        }

        public static void RunDFS(int i)
        {

            if (AdjacencyList.ContainsKey(i))
            {
                List<int> value = AdjacencyList[i];
                for (int j = 0; j < value.Count; j++)
                {
                    if (closure[i, value[j]] == 0)
                    {
                        closure[i, value[j]] = 1;
                        RunDFS(value[j]);
                    }
                    
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
                s = Console.ReadLine();
            }
            closure = new int[N, N];
            Visited = new bool[N];
            for (int i = 0; i < N; i++)
            {
                Visited[i] = false;
                closure[i, i] = 1;
            }
        }
    }
}
