using System.Collections.Generic;


namespace TestProject.Problems
{
    public class BreathFirstSearch
    {
        public static List<int> BFS(BNode root)
        {
            Queue<BNode> tempQueue = new Queue<BNode>();
            BNode DataNode = root;
            List<int> result = new List<int>();

            if (root != null)
            {
                tempQueue.Enqueue(root);

                while (tempQueue.Count > 0)
                {
                    DataNode = tempQueue.Dequeue();

                    result.Add(DataNode.value);

                    if (DataNode.left != null)
                    {
                        tempQueue.Enqueue(DataNode.left);
                    }
                    if (DataNode.right != null)
                    {
                        tempQueue.Enqueue(DataNode.right);
                    }
                }
            }
            else
            {
                return result;
            }

            return result;
        }

        public static List<List<int>> BFSTest(BNode root)
        {
            List<List<int>> output = new List<List<int>>();

            List<int> result = new List<int>();

            if(root == null)
            {
                return output;
            }

            BNode temp = new BNode();

            Queue<BNode> elements = new Queue<BNode>();
            elements.Enqueue(root);
            int count = 0;
            bool isRightSidePrint = true;

            while(elements.Count>0)
            {
                count = elements.Count;

                while(count > 0)
                {
                    temp = elements.Dequeue();

                    result.Add(temp.value);

                    if (!isRightSidePrint)
                    {

                        if (temp.left != null)
                        {
                            elements.Enqueue(temp.left);
                        }

                        if (temp.right != null)
                        {
                            elements.Enqueue(temp.right);
                        }
                    }
                    else
                    {
                        if (temp.right != null)
                        {
                            elements.Enqueue(temp.right);
                        }
                        if (temp.left != null)
                        {
                            elements.Enqueue(temp.left);
                        }

                    }
                    count--;
                }

                isRightSidePrint = !isRightSidePrint;
                output.Add(result);
                result = new List<int>();
            }

            return output;
        }

        public static void JoinNextPointers(BNode root)
        {
            if(root == null)
            {
                return;
            }

            Queue<BNode> queue = new Queue<BNode>();

            queue.Enqueue(root);
            int size = 0;
            BNode current = null;
            BNode prev = null;

            while (queue.Count>0)
            {
                size = queue.Count;

                while(size>0)
                {
                    current = queue.Dequeue();

                    if(prev == null)
                    {
                        prev = current;
                    }
                    else
                    {
                        prev.next = current;
                    }

                    if(current.left!= null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }

                    prev = current;
                    size--;
                }
                prev = null;
            }
        }

        public static BNode CopyRandomPointers(BNode root)
        {
            if(root ==null)
            {
                return root;
            }

            Dictionary<BNode, BNode> keyValuePairs = new Dictionary<BNode, BNode>();

            BNode firstListRoot = root;
            BNode tempNode = null;
            BNode SecondHead = null;
            BNode SecondTemp = null;

            while(firstListRoot!= null)
            {
                tempNode = new BNode(firstListRoot.value);

                if(SecondHead == null)
                {
                    SecondHead = tempNode;
                    SecondTemp = tempNode;
                }
                else
                {
                    SecondTemp.next = tempNode;
                    SecondTemp = tempNode;

                }

                keyValuePairs.Add(firstListRoot, tempNode);
                firstListRoot = firstListRoot.next;
            }

            foreach(var pair in keyValuePairs)
            {
                pair.Value.next = keyValuePairs[pair.Key.next];
            }

            return SecondHead;
        }
    }
}
