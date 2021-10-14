namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class TwitterQuestion
    {
        public static void Test()
        {
            string[][] requests = new string[10][];
            requests[0] = new string[] { "create", "xyz", "1", "1619916081" };
            requests[1] = new string[] { "join", "xyz", "2", "1619916681" };
            requests[2] = new string[] { "create", "abc", "3", "1619916881" };
            requests[3] = new string[] { "leave", "xyz", "2", "1619920281" };
            requests[4] = new string[] { "join", "abc", "4", "1619920881" };
            requests[5] = new string[] { "create", "ghi", "5", "1619923999" };
            requests[6] = new string[] { "leave", "xyz", "1", "1619923881" };
            requests[7] = new string[] { "leave", "abc", "3", "1619927481" };
            requests[8] = new string[] { "leave", "abc", "4", "1619927481" };
            requests[9] = new string[] { "leave", "ghi", "5", "1619958001" };

            //xyz  
             //xyz 




            Dictionary<string, Dictionary<string, List<long>>> map = new Dictionary<string, Dictionary<string, List<long>>>();

            foreach (var entry in requests)
            {
                if (!map.ContainsKey(entry[1]))
                {
                    Dictionary<string, List<long>> inner = new Dictionary<string, List<long>>();

                    inner.Add(entry[2], new List<long>() { Convert.ToInt64(entry[3]) });
                    map.Add(entry[1], inner);
                }
                else
                {
                    Dictionary<string, List<long>> inner = map[entry[1]];

                    if (inner.ContainsKey(entry[2]))
                    {
                        inner[entry[2]].Add(Convert.ToInt64(entry[3]));
                    }
                    else
                    {
                        inner.Add(entry[2], new List<long>() { Convert.ToInt64(entry[3]) });
                    }
                }
            }

            //Dictionary<id,list<int>
            long sum = 0;

            Dictionary<string, long> answer = new Dictionary<string, long>();

            foreach (var pair in map)
            {
                foreach (var innerpair in map[pair.Key])
                {
                    sum += Math.Abs(innerpair.Value[1] - innerpair.Value[0]);

                }

                answer.Add(pair.Key, sum);
                sum = 0;
            }

            foreach (var pair in answer)
            {
                Console.Write(pair.Key);
                Console.WriteLine(pair.Value);
            }
        }
    }
}
