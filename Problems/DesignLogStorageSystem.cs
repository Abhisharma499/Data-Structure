using System;
using System.Collections.Generic;

namespace TestProject.Problems
{
    public class DesignLogStorageSystem
    {
        Dictionary<String, int> dir;
        public DesignLogStorageSystem()
        {
            dir = new Dictionary<String, int>();
        }

        public void Put(int id, String timestamp)
        {
            dir.Add(timestamp, id);
        }

        public List<int> Retrieve(String s, String e, String gra)
        {
            int numCharPick = -1;

            if (gra == "Year")
            {
                numCharPick = 4;
            }
            else if (gra == "Month")
            {
                numCharPick = 7;
            }
            else if (gra == "Day")
            {
                numCharPick = 10;
            }
            else if (gra == "Hour")
            {
                numCharPick = 13;
            }
            else if (gra == "Minute")
            {
                numCharPick = 16;
            }
            else if (gra == "Second")
            {
                numCharPick = 19;
            }

            List<int> result = new List<int>();

            string stime = s.Substring(0, numCharPick);
            string endTime = e.Substring(0, numCharPick);

            foreach (var timekeys in dir.Keys)
            {
                string t = timekeys.Substring(0, numCharPick);
                if (stime.CompareTo(t) <= 0 && endTime.CompareTo(t) >= 0)
                {
                    result.Add(dir[timekeys]);
                }
            }

            return result;
        }
    }
}
