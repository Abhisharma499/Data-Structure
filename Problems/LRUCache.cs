using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class Node
    {
        public Node prev;
        public Node next;
        public int val;
        public int key;

        public Node(int key, int val)
        {
            this.prev = null;
            this.next = null;
            this.val = val;
            this.key = key;
        }
    }
    public class LRUCache
    {
        Dictionary<int, Node> keyValuePairs = new Dictionary<int, Node>();
        Node head;
        Node tail;
        readonly int MaxCacheLimit;
        static int counter = 0;
        public LRUCache(int capacity)
        {
            MaxCacheLimit = capacity;
        }
        public int Get(int key)
        {

            if (keyValuePairs.ContainsKey(key))
            {
                keyValuePairs[key] = BringNodeToFront(keyValuePairs[key]);
                return keyValuePairs[key].val;
            }

            return -1;
        }
        public Node BringNodeToFront(Node node)
        {
            if (node.next == null && node.prev == null)
            {
                head = node;
                return head;
            }

            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            else
            {
                tail = node.prev;
            }

            head.prev = node;
            node.next = head;
            node.prev = null;
            head = node;

            return head;
        }
        public void Put(int key, int value)
        {
            if (MaxCacheLimit == counter)
            {
                if (keyValuePairs.ContainsKey(key))
                {
                    keyValuePairs[key] = BringNodeToFront(keyValuePairs[key]);
                }
                else
                {

                    keyValuePairs.Remove(RemoveNodeFromEnd().key);
                    keyValuePairs.Add(key, AdNodeToTheBeggining(key, value));
                }
            }
            else
            {
                if (keyValuePairs.ContainsKey(key))
                {
                    keyValuePairs[key] = BringNodeToFront(keyValuePairs[key]);
                }
                else
                {
                    keyValuePairs.Add(key, AdNodeToTheBeggining(key, value));
                    counter++;
                }
            }
        }
        public Node RemoveNodeFromEnd()
        {
            if (tail.next == null && tail.prev == null)
            {
                head = null;
                return tail;
            }


            Node removeNoderemoveNode = tail;
            tail.prev.next = null;
            tail = tail.prev;

            return removeNoderemoveNode;
        }
        public Node AdNodeToTheBeggining(int key, int val)
        {
            Node Node = new Node(key, val);
            Node.prev = null;
            Node.next = head;
            if (head != null)
            {
                head.prev = Node;
            }
            head = Node;

            if (tail == null)
            {
                tail = head;
                tail.next = null;
            }

            return head;
        }
    }
}
