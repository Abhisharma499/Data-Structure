using System;
using System.Diagnostics;
using System.IO.Ports;

namespace TestProject.Problems
{
    public class BNode
    {
        public int value = 0;
        public BNode left;
        public BNode right;
        public BNode next;
        public BNode()
        {
            this.value = 0;
            this.left = null;
            this.right = null;
            this.next = null;
        }

        public BNode(int val)
        {
            this.value = val;
            this.left = null;
            this.right = null;
            this.next = null;
        }
    }
    public class BinarySearchTree
    {
        public BNode root;

        public static int diameter = 0;
        public static int result = 0;

        public BNode Insert(int value)
        {
            BNode newNode = new BNode();
            newNode.value = value;

            if (root == null)
            {
                root = newNode;
                return root;
            }
            else
            {
                BNode current = root;

                while (true)
                {
                    if (current.value > value)
                    {
                        if (current.left == null)
                        {
                            current.left = newNode;

                            return root;
                        }

                        current = current.left;
                    }
                    else
                    {
                        if (current.right == null)
                        {
                            current.right = newNode;

                            return root;
                        }

                        current = current.right;
                    }
                }
            }

        }
        public BinarySearchTree()
        {
            root = null;
        }

        public bool Search(int number)
        {
            BNode current = root;

            while (true)
            {
                if (current == null)
                {
                    return false;
                }
                if (current.value < number)
                {
                    current = current.right;
                }
                else if (current.value > number)
                {
                    current = current.left;
                }
                else
                {
                    return true;
                }
            }
        }

        public int GetDiameter(BNode root)
        {
            if(root == null)
            {
                return 0;
            }
                
            int left = GetDiameter(root.left);
            int right = GetDiameter(root.right);
            int temp = Math.Max(left, right) + 1;
            int ans = Math.Max( left + right + 1,temp);
            diameter = Math.Max(diameter, ans);

            return temp;
        }

        public int GetHeight(BNode root)
        {
            if(root== null)
            {
                return 0;
            }

            int left = GetHeight(root.left);
            int right = GetHeight(root.right);

            if(left> right)
            {
                return left + 1;
            }

            return right + 1;

        }

        public void Print1to10(int number)
        {
            if(number == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine(number);
                Print1to10(number - 1);
            }
        }

        public int MaxPathSum(BNode root)
        {
            if(root== null)
            {
                return 0;
            }

            int leftTreeValue = MaxPathSum(root.left);
            int rightTreeValue = MaxPathSum(root.right);

            int  temp= Math.Max(leftTreeValue, rightTreeValue) + root.value;
            int ans = Math.Max(leftTreeValue + rightTreeValue + root.value, temp);
            result = Math.Max(result, ans);

            return temp;
        }

        /*
         * BinarySearchTree binarySearchTree = new BinarySearchTree();
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(10);
            binarySearchTree.Insert(1);
            binarySearchTree.Insert(6);
            binarySearchTree.Insert(14);
            binarySearchTree.Insert(4);
            binarySearchTree.Insert(7);
            binarySearchTree.Insert(13);

            List<int> result = DepthFirstSearch.DFSPreorder(binarySearchTree.root);
         */
    }
}
