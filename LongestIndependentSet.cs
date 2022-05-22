using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class LISNode
    {
        public LISNode left;
        public LISNode right;
        public int value;
    }
    public class LongestIndependentSet
    {
        public static LISNode r;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(  LISS(r));
            Console.ReadLine();
        }

        public static int LISS(LISNode root)
        {
            if (root == null)
                return 0;
            int childLIS = LISS(root.left) + LISS(root.right);

            int grandchildLIS = (root.left == null ? (LISS(null) + LISS(null)) : (LISS(root.left.left) + LISS(root.left.right)))
                +
                        (root.right == null ? (LISS(null) + LISS(null)) : (LISS(root.right.left) + LISS(root.right.right)))
                        +1 ;
            return Math.Max(childLIS, grandchildLIS);
        }

        public static void TakeInputs()
        {
            LISNode rlrl = craetenode(10,null,null);
            LISNode rlrr = craetenode(14, null, null);
            LISNode rlr = craetenode(12, rlrl, rlrr);
            LISNode rll = craetenode(4, null, null);
            LISNode rl = craetenode(8, rll, rlr);
            LISNode rrr = craetenode(25, null, null);
            LISNode rr = craetenode(22, null, rrr);
            r = craetenode(20, rl, rr);

        }
        public static LISNode craetenode(int value, LISNode left, LISNode right)
        {
            LISNode l = new LISNode();
            l.value = value;
            l.left = left;
            l.right = right;
            return l;
        }
    }
}
