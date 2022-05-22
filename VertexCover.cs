using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class VertexCoverNode
    {
        public VertexCoverNode left;
        public VertexCoverNode right;
        public int value;
        public int VCvalue;
    }

    public class VertexCover
    {
        public static VertexCoverNode r;
        public static void execute()
        {
            TakeInputs();
            Console.WriteLine(VC(r));
            Console.ReadLine();
        }

        public static int VC(VertexCoverNode root)
        {
            if (root == null)
                return 0;

            if (root.left == null && root.right == null)
                return 0;

            if (root.VCvalue != 0)
                return root.VCvalue;

            int includerootnode = 0;
            includerootnode = 1 + VC(root.left) + VC(root.right);

            int excluderootnode = 0;
            excluderootnode = 1 + (root.left == null ? 0 : VC(root.left.left))
                + (root.left == null ? 0 : VC(root.left.right));
            excluderootnode += 1 + (root.right == null ? 0 : VC(root.right.left))
                + (root.right == null ? 0 : VC(root.right.right));

            root.VCvalue = Math.Min(includerootnode, excluderootnode);
            return root.VCvalue;
        }
        public static void TakeInputs()
        {
            VertexCoverNode rlrl = craetenode(10, null, null);
            VertexCoverNode rlrr = craetenode(14, null, null);
            VertexCoverNode rlr = craetenode(12, rlrl, rlrr);
            VertexCoverNode rll = craetenode(4, null, null);
            VertexCoverNode rl = craetenode(8, rll, rlr);
            VertexCoverNode rrr = craetenode(25, null, null);
            VertexCoverNode rr = craetenode(22, null, rrr);
            r = craetenode(20, rl, rr);

        }

        public static VertexCoverNode craetenode(int value, VertexCoverNode left, VertexCoverNode right)
        {
            VertexCoverNode l = new VertexCoverNode();
            l.value = value;
            l.left = left;
            l.right = right;
            l.VCvalue = 0;
            return l;
        }
    }
}
