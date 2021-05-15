using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public class ReorderLogs
    {
        public static string[] ReOrder(string []logs)
        {

            List<string> LetterLogs = new List<string>();
            List<string> DigitsLogs = new List<string>();

            foreach(string log in logs)
            {
               string[] delimilitedLog = log.Split(new char[] { ' ' }, 2);

                if(Char.IsDigit(delimilitedLog[1][0]))
                {
                    DigitsLogs.Add(log);
                }
                else
                {
                    LetterLogs.Add(log);
                }    
            }

            string[] letterArray = LetterLogs.ToArray();
            Array.Sort(letterArray, (log1, log2) =>
            {

                string[] LetterdelimilitedLog1= log1.Split(new char[] { ' ' }, 2);
                string[] LetterdelimilitedLog2 = log2.Split(new char[] { ' ' }, 2);

                int comparison = LetterdelimilitedLog1[1].CompareTo(LetterdelimilitedLog2[1]);

                if(comparison == 0)
                {
                    return LetterdelimilitedLog1[0].CompareTo(LetterdelimilitedLog2[0]);              
                }
                else
                {
                    return comparison;
                }
            });

            LetterLogs = letterArray.ToList();
            LetterLogs.AddRange(DigitsLogs);

            return LetterLogs.ToArray();
        }

       


    }
}
