using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MinCoins
    {
        public static int[] coins;
        public static int M;
        public static int V;
        public static int[] table;
        public static void execute()
        {
            TakeInputs();
            
            Console.WriteLine(MinCoinsRun(M, V));
            Console.ReadLine();
        }

        public static int MinCoinsRun(int m , int v)
        {
            for (int i = 1; i <=V; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if(i>=coins[j])
                    {
                        int sub_result = table[i - coins[j]];
                        if (sub_result != int.MaxValue && sub_result + 1 < table[i])
                            table[i] = sub_result+1;
                    }
                }
            }
            return table[V];
        }
        public static void TakeInputs()
        {
            coins = new int[] { 9, 6, 5, 1 };
            M = coins.Length;
            V = 11;
            table = new int[V + 1];
            for (int i = 0; i <= V; i++)
            {
                table[i] = int.MaxValue;
            }
            table[0] = 0;
        }
    }
}
