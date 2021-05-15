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

            if(root!= null)
            {
                tempQueue.Enqueue(root);

                while(tempQueue.Count > 0)
                {
                    DataNode = tempQueue.Dequeue();

                    result.Add(DataNode.value);

                    if(DataNode.left!=null)
                    {
                        tempQueue.Enqueue(DataNode.left);
                    }
                    if(DataNode.right!=null)
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

    }
}
