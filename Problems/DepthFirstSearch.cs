using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public class DepthFirstSearch
    {
       static List<int> returnList = new List<int>();
        public static List<int> DFSPreorder(BNode root)
        {
            if(root!=null)
            {
                returnList.Add(root.value);

                if(root.left!=null)
                {
                    DFSPreorder(root.left);
                }
                if (root.right != null)
                {
                    DFSPreorder(root.right);
                }
            }
            else
            {
                return returnList;
            }

            return returnList;
        }

        public static List<int> DFSPosteorder(BNode root)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    DFSPosteorder(root.left);
                }
                if (root.right != null)
                {
                    DFSPosteorder(root.right);
                }

                returnList.Add(root.value);
            }
            else
            {
                return returnList;
            }

            return returnList;
        }

        public static List<int> DFSInOrder(BNode root)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    DFSPosteorder(root.left);
                }
                returnList.Add(root.value);

                if (root.right != null)
                {
                    DFSPosteorder(root.right);
                }

            }
            else
            {
                return returnList;
            }

            return returnList;
        }
    }
}
