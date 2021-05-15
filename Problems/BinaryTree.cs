using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Problems
{
    public class BinaryTree
    {
        public BinaryTree left;
        public BinaryTree right;
        public char value;
        public static List<char> nodes = new List<char>();
        public static int Count = 0;
        public int HoriZontalDisatnce;
        public static int nodeCount=0;
        public static Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        public static BinaryTree CreateTree()
        {
            BinaryTree root = new BinaryTree();

            root.value = 'e';
            root.left = new BinaryTree();
            root.left.value = 'd';
            root.right = new BinaryTree();
            root.right.value = 't';


            root.left.left = new BinaryTree();
            root.left.left.value = 'b';

            root.right.right = new BinaryTree();

            root.right.right.value = 'z';

            //root.left = new BinaryTree();
            //root.right = new BinaryTree();
            //root.value = 'a';
            //root.left.value = 'b';
            //root.right.value = 'c';

            //root.left.left = new BinaryTree();
            //root.left.right = new BinaryTree();
            //root.left.left.value = 'd';
            //root.left.right.value = 'e';

            //root.right.left = new BinaryTree();
            //root.right.right = new BinaryTree();
            //root.right.left.value = 'f';
            //root.right.right.value = 'g';

            //root.right.right.right = new BinaryTree();

            //root.right.right.right.value = 'k';

            //root.left.left.left = new BinaryTree();
            //root.left.left.left.value = 'h';

            //root.left.right.left = new BinaryTree();
            //root.left.right.left.value = 'i';

            //root.left.right.right = new BinaryTree();
            //root.left.right.right.value = 'j';

            return root;

        }

        public static bool CheckIfCompleteBinaryTree(BinaryTree root)
        {
            bool isEnd = false;
            Queue<BinaryTree> nodes = new Queue<BinaryTree>();
            BinaryTree currentNode = null;

            if (root == null)
            {
                return true;
            }

            nodes.Enqueue(root);

            while (nodes.Count() > 0)
            {
                currentNode = nodes.Dequeue();

                if (currentNode == null)
                {
                    isEnd = true;
                }
                else
                {
                    if (isEnd == true)
                    {
                        return false;
                    }

                    nodes.Enqueue(currentNode.left);
                    nodes.Enqueue(currentNode.right);
                }
            }

            return true;


        }

        public static void PrintBinaryNumber(int n)
        {
            if (n < 2)
            {
                Console.WriteLine(n);
                return;
            }

            PrintBinaryNumber(n / 2);

            Console.WriteLine(n % 2);

        }

        public static void PrintBinaryTreeLevelOrder(BinaryTree root)
        {
            if (root == null)
            {
                return;
            }
            Queue<BinaryTree> parsedNodes = new Queue<BinaryTree>();
            BinaryTree nodeToPrint;
            Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();
            int level = 0;
            parsedNodes.Enqueue(root);
            List<int> nodes = new List<int>();
            nodes.Add(root.value);
            keyValuePairs.Add(level, nodes);

            while (parsedNodes.Count() > 0)
            {

                int size = parsedNodes.Count();
                nodes = new List<int>();
                level++;

                while (size > 0)
                {
                    nodeToPrint = parsedNodes.Dequeue();

                    Console.Write(nodeToPrint.value);

                    if (nodeToPrint.left != null)
                    {
                        nodes.Add(nodeToPrint.left.value);
                        parsedNodes.Enqueue(nodeToPrint.left);
                        
                    }

                    if (nodeToPrint.right != null)
                    {
                        nodes.Add(nodeToPrint.right.value);
                        parsedNodes.Enqueue(nodeToPrint.right);
                    }

                    size--;
                }

                if (nodes.Count != 0)
                {
                    keyValuePairs.Add(level, nodes);
                }

                Console.WriteLine();
            }
        }

        public static void DFSIterativePreOrder(BinaryTree root)
        {
            Stack<BinaryTree> treeNodes = new Stack<BinaryTree>();

            if(root== null)
            {
                return;
            }

            while(true)
            {
                while(root!=null)
                {
                    Console.WriteLine(root.value);
                    treeNodes.Push(root);
                    root = root.left;
                }

                if(treeNodes.Count()==0)
                {
                    break;
                }

                BinaryTree node = treeNodes.Pop();
                root = node.right;
            }
        }

        public static void DFSIterativeInOrder(BinaryTree root)
        {
            Stack<BinaryTree> treeNodes = new Stack<BinaryTree>();

            if (root == null)
            {
                return;
            }

            while (true)
            {
                while (root != null)
                {
                    treeNodes.Push(root);
                    root = root.left;     
                }

                if (treeNodes.Count() == 0)
                {
                    break;
                }

                BinaryTree node = treeNodes.Pop();
                Console.WriteLine(node.value);
                root = node.right;
            }
        }

        public static void PrintPostDFS(BinaryTree root)
        {
            if(root == null)
            {
                return;
            }

            PrintPostDFS(root.left);        
            PrintPostDFS(root.right);
            Console.WriteLine(root.value);

        }

        public static void PrintBFS(BinaryTree root)
        {
            BinaryTree current;

            if (root == null)
            {
                return;
            }

            Queue<BinaryTree> queue = new Queue<BinaryTree>();

            queue.Enqueue(root);

            while (queue.Count() != 0)
            {
                current = queue.Dequeue();

                Console.WriteLine(current.value);

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

        }
        public static void PrintDFSPreOrder(BinaryTree root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.value);
            PrintDFSPreOrder(root.left);
            PrintDFSPreOrder(root.right);
        }
        public static void PrintDFSInOrder(BinaryTree root)
        {
            if (root == null)
            {
                return;
            }

            PrintDFSInOrder(root.left);
            Console.WriteLine(root.value);
            PrintDFSInOrder(root.right);
        }
        public static void PrintDFSPostOrder(BinaryTree root)
        {
            if (root == null)
            {
                return;
            }

            PrintDFSPreOrder(root.left);
            PrintDFSPreOrder(root.right);
            Console.WriteLine(root.value);
        }
        public static void PrintDFSPreOrderRecursive(BinaryTree root)
        {
            Stack<BinaryTree> tree = new Stack<BinaryTree>();
            while (true)
            {
                while (root != null)
                {
                    tree.Push(root);
                    Console.WriteLine(root.value);
                    root = root.left;
                }

                if (tree.Count() == 0)
                {
                    break;
                }

                BinaryTree node = tree.Pop();
                root = node.right;
            }
        }
        public static void PrintDFSInOrderRecursive(BinaryTree root)
        {
            Stack<BinaryTree> tree = new Stack<BinaryTree>();
            while (true)
            {
                while (root != null)
                {
                    tree.Push(root);

                    root = root.left;
                }

                if (tree.Count() == 0)
                {
                    break;
                }
                BinaryTree node = tree.Pop();
                Console.WriteLine(node.value);
                root = node.right;
            }
        }
        public static void PrintDFSPostOrderRecursive(BinaryTree root)
        {
            Stack<BinaryTree> tree = new Stack<BinaryTree>();
            while (true)
            {
                while (root != null)
                {
                    tree.Push(root);
                    root = root.left;
                }

                if (tree.Count() == 0)
                {
                    break;
                }

                BinaryTree node = tree.Pop();
                root = node.right;
                Console.WriteLine(node.value);
            }
        }
        public static void PrintRootToLeafPath(BinaryTree root)
        {
            if (root == null)
            {
                return;
            }

            nodes.Add(root.value);

            PrintRootToLeafPath(root.left);

            if (root.left == null && root.right == null)
            {
                PrintQueue(nodes);
            }

            PrintRootToLeafPath(root.right);

            nodes.RemoveAt(nodes.Count() - 1);
        }
        private static void PrintQueue(List<char> nodes)
        {
            foreach (char item in nodes.Select(x => x).ToList())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
        public static int CountNumberOfNodes(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                Count++;
            }
            CountNumberOfNodes(root.left);
            CountNumberOfNodes(root.right);

            return Count;
        }
        public static int SumOfAllNodes(BNode root)
        {

            if (root == null)
            {
                return 0;
            }

            Count = 0;
            Count += root.value;

            SumOfAllNodes(root.left);
            SumOfAllNodes(root.right);

            return Count;
        }
        public static bool CheckSumTree(BNode root)
        {
            if (root == null)
            {
                return true;
            }
            if (root.left == null && root.right == null)
            {
                return true;
            }

            int leftSum = SumOfAllNodes(root.left);
            int rightSum = SumOfAllNodes(root.right);

            if (root.value == leftSum + rightSum)
            {
                if (CheckSumTree(root.left) && CheckSumTree(root.right))
                {
                    return true;
                }
            }

            return false;
        }
        public static int DiametereOfBinaryTree(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }

            int LHeight = HeightOfATree(root.left);
            int RHeight = HeightOfATree(root.right);

            return Math.Max((LHeight + RHeight + 1), (Math.Max(DiametereOfBinaryTree(root.left), DiametereOfBinaryTree(root.right))));
        }
        public static int HeightOfATree(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }

            int LHeight = HeightOfATree(root.left);
            int RHeight = HeightOfATree(root.right);

            return Math.Max(LHeight, RHeight) + 1;
        }
        public static int CountNodes(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        public static bool FindTarget(BinaryTree root, int k)
        {
            if(root == null)
            {
                return false;
            }

            if(keyValuePairs.ContainsKey(k-root.value))
            {
                return true;
            }
            else
            {
                if (!keyValuePairs.ContainsKey(k))
                {
                    keyValuePairs.Add(k, k);
                }
            }

            return FindTarget(root.left, k) || FindTarget(root.right, k);

        }

        public static int GetHeight(BinaryTree root)
        {
            if(root== null)
            {
                return 0;
            }

            int leftCount = GetHeight(root.left);

            int righCount = GetHeight(root.right);

            if(leftCount > righCount)
            {
                return leftCount + 1;
            }

            return righCount + 1;
        }

        public static int GetDiameter(BinaryTree root)
        {
            if(root == null)
            {
                return 0;
            }

            int Lheight = GetHeight(root.left);
            int Rheight = GetHeight(root.right);

            return Math.Max((1 + Lheight + Rheight), Math.Max(GetDiameter(root.left), GetDiameter(root.right)));
        }

        public static void LevelOrderTraversalSingleLineOutput(BinaryTree root, Dictionary<int, List<char>> verticalTraversal)
        {
            if(root== null)
            {
                return;
            }

            Queue<BinaryTree> nodes = new Queue<BinaryTree>();

            root.HoriZontalDisatnce = 0;
            nodes.Enqueue(root);
            BinaryTree visitedNode = null;


            while (nodes.Count()>0)
            {
                visitedNode = nodes.Dequeue();
                //Console.WriteLine(visitedNode.value);
                 if(verticalTraversal.ContainsKey(visitedNode.HoriZontalDisatnce))
                {
                    verticalTraversal[visitedNode.HoriZontalDisatnce].Add(visitedNode.value);
                }
                else
                {
                    verticalTraversal.Add(visitedNode.HoriZontalDisatnce, new List<char>() { visitedNode.value });
                }

                if (visitedNode.left!=null)
                {
                    visitedNode.left.HoriZontalDisatnce = visitedNode.HoriZontalDisatnce - 1;
                    nodes.Enqueue(visitedNode.left);
                }

                if (visitedNode.right != null)
                {
                    visitedNode.right.HoriZontalDisatnce = visitedNode.HoriZontalDisatnce + 1;
                    nodes.Enqueue(visitedNode.right);
                }
            }
        }

        public static void LevelOrderTraversalMultilineOutput(BinaryTree root,List<List<char>> leverOrderDataAll)
        {
            List<char> leverOrderData = new List<char>();

            if (root == null)
            {
                return;
            }

            Queue<BinaryTree> nodes = new Queue<BinaryTree>();

            nodes.Enqueue(root);
            nodes.Enqueue(null);
            BinaryTree visitedNode = null;


            while (nodes.Count() > 0)
            {
                visitedNode = nodes.Dequeue();
                
                if(visitedNode!= null)
                {
                    Console.Write(visitedNode.value);

                    leverOrderData.Add(visitedNode.value);

                    if (visitedNode.left != null)
                    {
                        nodes.Enqueue(visitedNode.left);
                    }
                    if (visitedNode.right != null)
                    {
                        nodes.Enqueue(visitedNode.right);
                    }
                }
                else
                {
                    leverOrderDataAll.Add(leverOrderData);
                    leverOrderData = new List<char>();
                    nodes.Enqueue(null);
                    Console.WriteLine();
                }

                if(nodes.Count()==1 && nodes.Peek()==null)
                {
                    leverOrderDataAll.Add(leverOrderData);
                    nodes.Dequeue();
                }
            }
        }

        public static bool IsMirror(BinaryTree root1, BinaryTree root2)
        {
            if(root1 == null && root2 == null)
            {
                return true;
            }

            if(root1 == null || root2 == null )
            {
                return false;
            }

            if((root1.value == root2.value) && IsMirror(root1.left,root2.right) && IsMirror(root1.right, root2.left))
            {
                return true;
            }

            return false;
        }

        public static bool IsIdentical(BinaryTree root1, BinaryTree root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if (root1 == null || root2 == null)
            {
                return false;
            }

            if ((root1.value == root2.value) && IsMirror(root1.left, root2.left) && IsMirror(root1.right, root2.right))
            {
                return true;
            }

            return false;
        }

        public static bool IsBinarySeachTree(BinaryTree root, int min, int max)
        {
            
            if(root== null)
            {
                return true;
            }

            if (root.value >= max || root.value <= min)
            {
                return false;
            }


            if ((root.value > min && root.value< max) && (IsBinarySeachTree(root.left,min,root.value) && (IsBinarySeachTree(root.right, root.value, max))))
            {
                return true;
            }

            return false;
        }

        public static void getKthSmallestElementBST(BinaryTree node, int k, ref int result)
        {
            if (node == null)
            {
                return;
            }

            getKthSmallestElementBST(node.right,k, ref result);

            nodeCount++;

            if(k == nodeCount)
            {
                result= node.value;

                return;
            }

            getKthSmallestElementBST(node.left, k, ref result);

        }    

        public static void AllRootToLeafPaths(BinaryTree root, string path)
        {
            if(root == null)
            {
                return;
            }

            path = path + root.value;

            if(root.left == null && root.right== null)
            {
                Console.WriteLine("The Path is " + path);
                return;
               
            }

            AllRootToLeafPaths(root.left, path);
            AllRootToLeafPaths(root.right, path);

        }

        public static int MaxSumPathAnyNodeToAnyNode(BinaryTree root, ref int result)
        {
            if (root == null)
            {
                return 0;
            }

            if(root.left == null && root.right == null)
            {
                return root.value;
            }

            if(root.left == null)
            {
                return MaxSumPathAnyNodeToAnyNode(root.right,ref result) + root.value;
            }
            else if(root.right == null)
            {
                return MaxSumPathAnyNodeToAnyNode(root.left, ref result) + root.value;
            }

            int leftSum = MaxSumPathAnyNodeToAnyNode(root.left, ref result);
            int rightSum = MaxSumPathAnyNodeToAnyNode(root.right, ref result);

            int temp = Math.Max(leftSum, rightSum) + root.value;

            temp = Math.Max(temp, root.value);

            int answer = Math.Max((leftSum + rightSum + root.value), temp);

            result = Math.Max(result, answer);

            return temp;        
        }

        public static int MaxSumPathLeftNodeToLeafNode(BinaryTree root, ref int result)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null)
            {
                return root.value;
            }

            if (root.left == null)
            {
                return MaxSumPathLeftNodeToLeafNode(root.right, ref result) + root.value;
            }
            else if (root.right == null)
            {
                return MaxSumPathLeftNodeToLeafNode(root.left, ref result) + root.value;
            }

            int leftSum = MaxSumPathLeftNodeToLeafNode(root.left, ref result);
            int rightSum = MaxSumPathLeftNodeToLeafNode(root.right, ref result);

            
            int temp = Math.Max(leftSum, rightSum) + root.value;

            if (root.left == null && root.right == null)
            {
                temp = Math.Max(temp, root.value);
            }

            result = Math.Max(result, leftSum + rightSum + root.value);

            return temp;
        }
    }
}
