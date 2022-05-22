using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public struct Node
    {
        public int nodeValue;
        public int parent;
    }
    public struct Edge : IComparable
    {
        public Node start;
        public Node end;
        public int weight;
        public bool Visited;

        public int CompareTo(object obj)
        {
            Edge b = (Edge)obj;
            if (weight > b.weight)
                return 1;
            if (weight < b.weight)
                return -1;
            else return 0;
        }
    }

    public class KrushkalAlgorithm
    {
        static List<Edge> Grph;
        static List<Edge> MST;
        static List<Node> Nodes;
        static int N;
        public static void execute()
        {
            Grph = new List<Edge>();
            MST = new List<Edge>();
            Nodes = new List<Node>();
            AddVertexes();
            Grph.Sort();
            N = Grph.Count();
            RunKrushkal();
            PrintOP();
            Console.ReadLine();
        }

        public static void RunKrushkal()
        {
            while(Grph.Count!=0)
            {
                if (!CheckCycle(Grph[0]))
                {
                    MST.Add(Grph[0]);
                    Grph.Remove(Grph[0]);
                }
                else
                    Grph.Remove(Grph[0]);
            }
        }

        public static void PrintOP()
        {
            foreach (var e in MST)
                Console.WriteLine(e.start.nodeValue+" " +e.end.nodeValue);
        }
        public static bool CheckCycle(Edge e)
        {
            if (MST.Count() > 0)
            {
                return (
                    (MST.Any(x => x.start.nodeValue == e.start.nodeValue) && MST.Any(x => x.start.nodeValue == e.end.nodeValue))
                    || (MST.Any(x => x.end.nodeValue == e.start.nodeValue) && MST.Any(x => x.end.nodeValue == e.end.nodeValue))
                    || (MST.Any(x => x.end.nodeValue == e.start.nodeValue) && MST.Any(x => x.start.nodeValue == e.end.nodeValue))
                    || (MST.Any(x => x.start.nodeValue == e.start.nodeValue) && MST.Any(x => x.end.nodeValue == e.end.nodeValue))
                        );
            }
            return false;
        }
        public static void AddVertexes()
        {
            string s = Console.ReadLine();
            int nodes = Convert.ToInt32(s);
            for(int i=0;i<nodes;i++)
            {
                Node n = new Node();
                n.nodeValue = i;
                n.parent = i;
                Nodes.Add(n);
            }
            string[] str;
            int start;
            int end;
            int weight;
            s = Console.ReadLine();
            while (!string.IsNullOrEmpty(s))
            {
                str = s.Trim().Split(' ');
                start = Convert.ToInt32(str[0]);
                if (str.Length > 1)
                    end = Convert.ToInt32(str[1]);
                else
                    end = start;
                if (str.Length > 2)
                    weight = Convert.ToInt32(str[2]);
                else
                    weight = 0;
                Edge e = new Edge();
                e.start = Nodes[start];
                e.end = Nodes[end];
                e.weight = weight;
                //initialization done here
                e.Visited = false;

                Grph.Add(e);
                s = Console.ReadLine();
            }
        }
    }
}
