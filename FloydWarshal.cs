using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class FloydWarshal
    {
        public static int N;
        public static int[,] grphs;
        public static int[,] closure;
        public static void execute()
        {
            TakeInputs();
            WarshalAlgo();
            PrintOp();
            Console.ReadLine();
        }

        public static void WarshalAlgo()
        {
            for( int i=0;i<N;i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        closure[j, k] = (closure[j, k] != 0 || (closure[j, i] != 0 && closure[i, k] != 0)) ? 1 : 0;
                    }
                }
            }
        }

        public static void PrintOp()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write( closure[i,j] +" ");
                }
                Console.WriteLine();
            }
        }
        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            N = Convert.ToInt32(s);
            s = Console.ReadLine();
            grphs = new int[N,N];
            closure = new int[N, N];
            string[] str;
            int j = 0;
            while(!String.IsNullOrEmpty(s))
            {
                str = s.Split(' ');

                for(int i=0;i<str.Length;i++)
                {
                    grphs[j,i] = Convert.ToInt32(str[i]);
                }
                j++;
                s = Console.ReadLine();
            }

            for(j=0;j<N;j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if(j!=i)
                        closure[j, i] = grphs[j,i];
                    else
                        closure[j, i] = 1;
                }
            }
        }
    }
}
