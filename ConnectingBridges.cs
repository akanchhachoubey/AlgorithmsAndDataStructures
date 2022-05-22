using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class ConnectingBridges
    {
        public static List<int> CityA;
        public static List<int> CityB;
        public static Dictionary<int,int> Selected;
        public static int[] LIS;
        public static void execute()
        {
            TakeInputs();
            SortLists();
            Selected = new Dictionary<int, int>();
            RunLIS(CityA.Count-1);
            int max = LIS[0];
            for (int i = 1; i < LIS.Length; i++)
            {
                max= max > LIS[i] ? max : LIS[i];
            }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        public static int RunLIS(int i)
        {
            if (i == 0)
            {
                LIS[0] = 1;
                return 1;
            }
            else
            if (LIS[i] == 0 && i > 0)
            {
                if (LIS[i - 1] == 0) RunLIS(i - 1);

                if (CityA[i] >= CityA[i - 1])
                {
                    LIS[i] = LIS[i - 1] + 1;
                }
                else
                {
                    int j = -1;
                    while(j>i || j==-1)
                        j = CityA.LastOrDefault(x => x < CityA[i]);
                    if (j != 0)
                    {
                        if (LIS[j] == 0) RunLIS(j);
                        LIS[i] = LIS[j] + 1;
                    }
                    else
                        LIS[i] = 1;

                }
                return LIS[i];
            }
            else return LIS[i];

        }

        public static void SortLists()
        {
            for (int i = 0; i < CityA.Count; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if(CityB[i]<CityB[j])
                    {
                        int temp = CityA[i];
                        CityA[i] = CityA[j];
                        CityA[j] = temp;
                        temp = CityB[i];
                        CityB[i] = CityB[j];
                        CityB[j] = temp;
                    }
                }
            }
        }

        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            string[] str = s.Split(' ');
            string s1 = Console.ReadLine();
            string[] str1 = s1.Split(' ');
            LIS = new int[str.Length];
            CityA = new List<int>();
            CityB = new List<int>();
            for(int i=0;i<str.Length;i++)
            {
                CityA.Add(Convert.ToInt32(str[i]));
                CityB.Add(Convert.ToInt32(str1[i]));
                LIS[i] = 0;
            }
            
        }
    }

}
