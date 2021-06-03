using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems.DictionaryTypes
{
    public class LearnCollections
    {
        public static void TypesOfCollection()
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
            SortedList<int, int> sortedList = new SortedList<int, int>();
            SortedSet<int> sortedSet = new SortedSet<int>();

            sortedDictionary.Add(3,3);
            sortedDictionary.Add(1,1);


        }
    }
}
