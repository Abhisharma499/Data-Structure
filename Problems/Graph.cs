using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class Graph
    {
        public Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();
        List<string> TraversalResult = new List<string>();
        Stack<string> NodeList = new Stack<string>();
        Queue<string> QueueNodeList = new Queue<string>();

        public void addVertex(string vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<string>();
            }
        }

        public void RemoveEdge(string vertex1, string vertex2)
        {
            if (adjacencyList.ContainsKey(vertex1))
            {
                adjacencyList[vertex1].Remove(vertex2);
            }
            if (adjacencyList.ContainsKey(vertex2))
            {
                adjacencyList[vertex2].Remove(vertex1);
            }
        }

        public void RemoveVertex(string vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                adjacencyList.Remove(vertex);
            }

            var listVertex = adjacencyList.Where(x => x.Value.Contains(vertex));

            foreach (var searchedVertex in listVertex)
            {
                searchedVertex.Value.Remove(vertex);
            }
        }

        public void addEdge(string vertex, string edge)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex].Add(edge);
            }
            else
            {
                addVertex(vertex);
                adjacencyList[vertex].Add(edge);
            }

            if (adjacencyList.ContainsKey(edge))
            {
                adjacencyList[edge].Add(vertex);
            }
            else
            {
                addVertex(edge);
                adjacencyList[edge].Add(vertex);
            }
        }

        public List<string> DFSRecursive(string startNode)
        {
            if (adjacencyList.ContainsKey(startNode))
            {
                TraversalResult.Add(startNode);
                foreach (string vertex in adjacencyList[startNode])
                {
                    if (!TraversalResult.Contains(vertex))
                    {
                        DFSRecursive(vertex);
                    }
                }
            }
            else
            {
                return TraversalResult;
            }

            return TraversalResult;
        }

        public List<string> DFSIterative(string startNode)
        {
            NodeList.Push(startNode);
            string currentNode = string.Empty;

            while (NodeList.Count() > 0)
            {
                currentNode = NodeList.Pop();

                if (!TraversalResult.Contains(currentNode))
                {
                    TraversalResult.Add(currentNode);
                }
                foreach (string node in adjacencyList[currentNode])
                {
                    if (!TraversalResult.Contains(node))
                    {
                        NodeList.Push(node);
                    }
                }

            }

            return TraversalResult;
        }

        public List<string> BFSIterative(string startNode)
        {
            QueueNodeList.Enqueue(startNode);
            string currentNode = string.Empty;

            while (QueueNodeList.Count() > 0)
            {
                currentNode = QueueNodeList.Dequeue();

                if (!TraversalResult.Contains(currentNode))
                {
                    TraversalResult.Add(currentNode);
                }
                foreach (string node in adjacencyList[currentNode])
                {
                    if (!TraversalResult.Contains(node))
                    {
                        QueueNodeList.Enqueue(node);
                    }
                }

            }

            return TraversalResult;
        }

        public static int[,] GetGraphFromUser()
        {
            Console.WriteLine("Enter Number of Vertex");
            int numVertex = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Number of Edges");
            int numEdges = int.Parse(Console.ReadLine());

            int[,] graphMatrix = new int[numVertex, numVertex];

            int startVertex, endVertex;

            for (int i = 0; i < numEdges; i++)
            {
                Console.WriteLine("Enter the startVertex");
                startVertex = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the endVertex");
                endVertex = int.Parse(Console.ReadLine());

                graphMatrix[startVertex, endVertex] = 1;

            }

            return graphMatrix;
        }

        public static void PrintBFSMyVersion(int[,] graphMatrix, int startingVertex, bool[] visited)
        {
            Queue<int> vertexes = new Queue<int>();
            vertexes.Enqueue(startingVertex);
            visited[startingVertex] = true;

            while (vertexes.Count() > 0)
            {
                int current = vertexes.Dequeue();
                Console.WriteLine(current);

                for (int i = 0; i <= graphMatrix.GetUpperBound(0); i++)
                {
                    if (graphMatrix[current, i] == 1 && visited[i] == false)
                    {
                        vertexes.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }

        public static void PrintDFSMyVersion(int[,] graphMatrix, int startingVertex, bool[] visited)
        {
            visited[startingVertex] = true;

            Console.WriteLine(startingVertex);

            for (int i = 0; i <= graphMatrix.GetUpperBound(0); i++)
            {
                if (graphMatrix[startingVertex, i] == 1 && visited[i] == false)
                {
                    PrintDFSMyVersion(graphMatrix, i, visited);
                }
            }
        }

        public static void PrintDFS(int[,] graphMatrix, int startingVertex, bool[] visited)
        {
            if (visited[startingVertex])
            {
                return;
            }

            visited[startingVertex] = true;

            Console.WriteLine(startingVertex);

            for (int i = 0; i <= graphMatrix.GetUpperBound(0); i++)
            {
                if (graphMatrix[startingVertex, i] == 1 && visited[i] == false)
                {
                    PrintDFS(graphMatrix, i, visited);
                }
            }
        }

        public static void PrintBFS(int[,] graphMatrix, int startingVertex, bool[] visited)
        {
            if (visited[startingVertex])
            {
                return;
            }

            visited[startingVertex] = true;
            Queue<int> vertexes = new Queue<int>();
            vertexes.Enqueue(startingVertex);

            while (vertexes.Count() > 0)
            {
                int current = vertexes.Dequeue();
                Console.WriteLine(current);
                for (int i = 0; i < graphMatrix.GetUpperBound(0) + 1; i++)
                {
                    if (graphMatrix[current, i] == 1 && visited[i] == false)
                    {
                        vertexes.Enqueue(i);
                        visited[i] = true;
                    }
                }

            }


        }

        public static bool DetectCycleUnDirectedGraph(int[,] graphMatrix, int startingVertex, bool[] visited, int parent)
        {
            visited[startingVertex] = true;

            Console.WriteLine(startingVertex);

            for (int i = 0; i <= graphMatrix.GetUpperBound(0); i++)
            {
                if (graphMatrix[startingVertex, i] == 1 && visited[i] == false)
                {

                    DetectCycleUnDirectedGraph(graphMatrix, i, visited, startingVertex);
                }

                else if (graphMatrix[startingVertex, i] == 1 && visited[i] == true)
                {
                    if (i != parent)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
