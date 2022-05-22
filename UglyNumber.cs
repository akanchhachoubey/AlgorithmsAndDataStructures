using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class UglyNumber
    {
        public static List<int> i;
        public static int point2 = 2;
        public static int point3 = 3;
        public static int point5 = 5;
        public static int i2 = 0, i3 =0 , i5 = 0;
        public static void execute()
        {
            i = new List<int>();
            i.Add(1);
            int k=1;
            for (int j = 1; j < 150; j++)
            {
                k = Math.Min(point2, Math.Min(point3, point5));

                i.Add(k);

                if(k== point2)
                {
                    i2 = i2 + 1;
                    point2 = i[i2]*2;
                }
                if (k == point3)
                {
                    i3 = i3 + 1;
                    point3 = i[i3]*3;
                }
                if (k == point5)
                {
                    i5 = i5 + 1;
                    point5 = i[i5]*5;
                }
            }
            Console.WriteLine(k);

            Console.ReadLine();
        }

        public static int Maxdivide(int no, int div)
        {
            while (no % div == 0)
                no = no / div;
            return no;
        }
    }
}
