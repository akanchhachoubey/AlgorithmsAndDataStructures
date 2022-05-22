using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class StronglyConnectedComponents
    {
        public static Dictionary<int, List<int>> AdjacencyList;
        public static int N;
        public static Stack<int> DFSList;
        public static bool[] Visited;
        public static Dictionary<int, List<int>> ReversedAdjacencyList;
        public static void execute()
        {
            AdjacencyList = new Dictionary<int, List<int>>();
            ReversedAdjacencyList = new Dictionary<int, List<int>>();
            DFSList = new Stack<int>();
            //take inputs
            TakeInput();
            //run DFS and push elements in stack
            for(int i=0;i<N;i++)
                RunDFS(i);
            //reverse arrows
            ReversedList();
            //intitalize visited again
            for (int i = 0; i < N; i++)
                Visited[i] = false;
            //call DFS on reveresed list
            while (DFSList.Count()>0)
            {
                int node = DFSList.Pop();
                if(!Visited[node])
                    PrintComponents(node);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static void ReversedList()
        {
            for(int i=0;i<N;i++)
            {
                if (AdjacencyList.ContainsKey(i))
                {
                    List<int> value = AdjacencyList[i];
                    for (int j = 0; j < value.Count(); j++)
                    {
                        int node = value[j];
                        if (!ReversedAdjacencyList.ContainsKey(node))
                        {
                            List<int> list = new List<int>();
                            list.Add(i);
                            ReversedAdjacencyList.Add(node, list);
                        }
                        else
                        {
                            ReversedAdjacencyList[node].Add(i);
                        }
                    }
                }
            }
        }

        public static void PrintComponents(int i)
        {
            if (!Visited[i])
            {
                Visited[i] = true;
                Console.Write(i + " ");
                if (ReversedAdjacencyList.ContainsKey(i))
                {
                    List<int> value = ReversedAdjacencyList[i];
                    for (int j = 0; j < value.Count; j++)
                    {
                        PrintComponents(value[j]);
                    }
                }
            }
        }

        public static void RunDFS(int i)
        {
            if (!Visited[i])
            {
                Visited[i] = true;
                if (AdjacencyList.ContainsKey(i))
                {
                    List<int> value = AdjacencyList[i];
                    for (int j = 0; j < value.Count; j++)
                    {
                        RunDFS(value[j]);
                    }
                }
                DFSList.Push(i);
            }
        }
        public static void TakeInput()
        {
            string s = Console.ReadLine();
            N = Convert.ToInt32(s);
            Visited = new bool[N];
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

            for (int i = 0; i < N; i++)
                Visited[i] = false;
        }


    }
}
