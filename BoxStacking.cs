using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public struct Box : IComparable
    {
        public int length;
        public int breadth;
        public int height;
        public int area;

        public int CompareTo(object obj)
        {
            Box b = (Box)obj;
            if (area > b.area)
                return -1;
            else if (area < b.area)
                return +1;
            else return 0;
        }
    }

    public class BoxStacking
    {
        public static List<Box> boxes;
        public static int[] maxheight;
        public static int[] boxtrack;
        public static void execute()
        {
            TakeInputs();
            GetAreaSorted();
            RunLIS();
            int max = maxheight[0];
            for (int i = 1; i < maxheight.Length; i++)
            {
                max = max > maxheight[i] ? max : maxheight[i];
            }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        public static void RunLIS()
        {
            for (int i = 1; i < boxes.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if(boxes[j].length> boxes[i].length && boxes[j].breadth>boxes[i].breadth)
                    {
                        maxheight[i] = maxheight[i] > (maxheight[j] + boxes[i].height) ? maxheight[i] : maxheight[j] + boxes[i].height;
                        if (maxheight[i] == maxheight[j] + boxes[i].height)
                            boxtrack[i] = j;
                    }
                }
            }
        }

        public static void GetAreaSorted()
        {
            boxes.Sort();
            for (int i = 0; i < boxes.Count; i++)
            {
                maxheight[i] = boxes[i].height;
                boxtrack[i] = i;
            }
        }

        public static void TakeInputs()
        {
            string s = Console.ReadLine();
            string[] str;
            int l, br, h, a = 0;
            boxes = new List<Box>();
            while (!string.IsNullOrEmpty(s))
            {
                str = s.Split(' ');
                Box b = new Box();
                l = Convert.ToInt32(str[0]);
                br = Convert.ToInt32(str[1]);
                h = Convert.ToInt32(str[2]);
                b.length = l;
                b.breadth = br;
                b.height = h;
                b.area = b.length * b.breadth;
                boxes.Add(b);
                Box b2 = new Box();
                b2.length = l;
                b2.breadth = h;
                b2.height = br;
                b2.area = b2.length * b2.breadth;
                boxes.Add(b2);
                Box b3 = new Box();
                b3.length = br;
                b3.breadth = h;
                b3.height = l;
                b3.area = b3.length * b3.breadth;
                boxes.Add(b3);
                s = Console.ReadLine();
            }
            maxheight = new int[boxes.Count];
            boxtrack = new int[boxes.Count];
            
        }

    }
}
