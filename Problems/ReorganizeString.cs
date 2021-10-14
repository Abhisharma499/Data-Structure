namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MyClass:IComparable<MyClass>
    {
        public char ch;
        public int freq;

        public MyClass(char c, int f)
        {
            ch = c;
            freq = f;
        }

        public int CompareTo(MyClass other)
        {
            if(this.freq < other.freq)
            {
                return -1;
            }
            else if(this.freq == other.freq)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

   public class MyReorganizeString
    {
        public string ReorganizeString(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            List<MyClass> list = new List<MyClass>();

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach(char ch in s)
            {
                if(map.ContainsKey(ch))
                {
                    map[ch]++;
                }
                else
                {
                    map.Add(ch, 1);
                }
            }

            foreach(var pair in map)
            {
                list.Add(new MyClass(pair.Key, pair.Value));
            }

            StringBuilder str = new StringBuilder();

            while(list.Count>1)
            {
                MyClass first = list.Max();

                list.Remove(first);

                MyClass second = list.Max();

                list.Remove(second);

                str.Append(first.ch.ToString() + second.ch.ToString());

                if(first.freq > 1)
                {
                    list.Add(new MyClass(first.ch, first.freq - 1));
                }

                if (second.freq > 1)
                {
                    list.Add(new MyClass(second.ch, second.freq - 1));
                }
            }

            if(list.Count()>0)
            {
                MyClass temp = list.Max();

                if(temp.freq>1)
                {
                    return "";
                }
                else
                {
                    str.Append(temp.ch.ToString());
                }
            }

            return str.ToString();
        }

        
    }
}
