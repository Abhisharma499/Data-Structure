namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Entry
    {
        public int key, val;
        public Entry(int k, int v)
        {
            key = k;
            val = v;
        }
    }
    public class MyHashMap
    {

        const int size = 769;
        List<Entry>[] map;
        /** Initialize your data structure here. */
        public MyHashMap()
        {
            map = new List<Entry>[size];
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            int index = key % size;

            if (map[index] == null)
            {
                map[index] = new List<Entry>();
            }

            List<Entry> bucket = map[index];

            foreach(Entry e in bucket)
            {
                if(e.key == key)
                {
                    e.val = value;
                    return;
                }
            }

            map[index].Add(new Entry(key, value));
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            int index = key % size;

            List<Entry> bucket = map[index];

            if (bucket == null)
            {
                return -1;
            }

            foreach (Entry e in bucket)
            {
                if (e.key == key)
                {
                    return e.val;
                }
            }

            return -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            int index = key % size;

            if (map[index] == null)
            {
                return;
            }

            Entry temp = null;

            List<Entry> bucket = map[index];

            foreach (Entry e in bucket)
            {
                if (e.key == key)
                {
                    temp = e;
                    break;
                }
            }

            if (temp != null)
            {
                map[index].Remove(temp);
            }
        }
    }
}
