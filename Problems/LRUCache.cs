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
        Dictionary<int, Node> map;
        Node head;
        Node tail;
        int MaxCacheLimit;

        public LRUCache(int capacity)
        {
            head = new Node(0, 0);
            tail = new Node(0, 0);
            MaxCacheLimit = capacity;
            head.next = tail;
            tail.prev = head;
            map = new Dictionary<int, Node>();
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key))
            {
                return -1;
            }

            Node node = map[key];
            Remove(node); 
            Insert(node);
            return node.val;
        }

        public void Put(int key, int value)
        {
            if (!map.ContainsKey(key))
            {
                if (MaxCacheLimit == map.Count())
                {
                    Remove(tail.prev);
                }

                Node newNode = new Node(key, value);
                Insert(newNode);
            }
            else
            {
                Node curr = map[key];
                Remove(curr);
                Node newNode = new Node(key, value);
                Insert(newNode);
            }
        }

        public void Insert(Node node)
        {
            map.Add(node.key,node);
            node.next = head.next;
            head.next.prev = node;
            node.prev = head;
            head.next = node;
        }

        public void Remove(Node node)
        {
            map.Remove(node.key);
            node.next.prev = node.prev;
            node.prev.next = node.next;
        }
    }
}
