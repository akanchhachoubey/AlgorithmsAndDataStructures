using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{

    public class FindMotherVertex
    {
        public static Dictionary<int, List<int>> AdjacencyList;
        public static int N;
        public static int MotherVertex;
        public static int[] starttime;
        public static int[] finishtime;
        public static int time = 0;
        public static void execute()
        {
            AdjacencyList = new Dictionary<int, List<int>>();
            TakeInput();
            Initializer();
            int components = 0;
            for (int i = 0; i < N; i++)
            {
                if (finishtime[i] == 0)
                {
                    components++;
                    RunDFS(i);
                }
            }
            if (components >= 1)
            
            {
                int max = 0;
                for (int i = 1; i < N; i++)
                { if (finishtime[max] < finishtime[i]) max = i; }

                Console.WriteLine("mother vertex "+max);
            }

            Console.ReadLine();
        }

        public static void RunDFS(int i)
        {
            if(starttime[i]==0)
            {
                starttime[i] = ++time;
                if (AdjacencyList.ContainsKey(i))
                {
                    List<int> value = AdjacencyList[i];
                    for (int j = 0; j < value.Count; j++)
                    {
                        RunDFS(value[j]);
                    }

                    finishtime[i] = ++time;
                }
            }
        }

        public static void Initializer()
        {
            starttime = new int[N];
            finishtime = new int[N];
            for(int i=0;i<N;i++)
            {
                starttime[i] = 0;
                finishtime[i] = 0;
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
            while(!string.IsNullOrEmpty(s))
            {
                str = s.Split(' ');
                key = Convert.ToInt32(str[0]);
                if (AdjacencyList.Any(x => x.Key == key))
                {
                    if (str.Length > 0)
                    {
                        value = Convert.ToInt32( str[1]);
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
        }

    }
}
