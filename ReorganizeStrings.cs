namespace TestProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MyClass : IComparable<MyClass>
    {
        public char c;
        public int f;

        public MyClass(char c, int f)
        {
            this.c = c;
            this.f = f;
        }

        public int CompareTo(MyClass other)
        {
            return this.f.CompareTo(other.f);
        }
    }
    class ReorganizeStrings
    {
        public string ReorganizeString(string s)
        {

            string result = string.Empty;
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            List<MyClass> heap = new List<MyClass>();

            foreach (var pair in map)
            {
                heap.Add(new MyClass(pair.Key, pair.Value));
            }

            while (heap.Count > 1)
            {

                MyClass obj1 = heap.Max();
                heap.Remove(obj1);
                MyClass obj2 = heap.Max();
                heap.Remove(obj2);

                result = result + obj1.c.ToString();


                obj1.f = obj1.f - 1;

                if (obj1.f > 0)
                {
                    heap.Add(obj1);
                }

                result = result + obj2.c.ToString();

                obj2.f = obj2.f - 1;

                if (obj2.f > 0)
                {
                    heap.Add(obj2);
                }
            }

            if (heap.Count() == 1)
            {
                MyClass obj = heap.Max();

                if (obj.f > 1)
                {
                    return "";
                }
                else
                {
                    result = result + obj.c.ToString();
                }
            }

            return result;
        }
    }
}
