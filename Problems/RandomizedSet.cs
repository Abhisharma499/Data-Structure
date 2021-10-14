namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RandomizedSet
    {
        Dictionary<int, int> map;
        List<int> list;

        /** Initialize your data structure here. */
        public RandomizedSet()
        {

            map = new Dictionary<int, int>();
            list = new List<int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (map.ContainsKey(val))
            {
                return false;
            }
            else
            {
                map.Add(val, list.Count());
                list.Add(val);
            }

            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!map.ContainsKey(val))
            {
                return false;
            }

            int index = map[val];
            int last = list[list.Count() - 1];

            int temp = list[index];
            list[index] = last;
            list[list.Count() - 1] = temp;


            list.RemoveAt(list.Count() - 1);
            map.Remove(val);

            if (map.ContainsKey(last))
            {
                map[last] = index;
            }

            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            Random rnd = new Random();
            int index = rnd.Next(list.Count());
            return list[index];
        }
    }
}
