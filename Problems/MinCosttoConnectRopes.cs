using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
   public class MinCosttoConnectRopes
    {
        public static int  GetCost(int []ropes)
        {
            List<int> listRopes = ropes.ToList();
            int cost = 0;
            int first = 0;
            int second = 0;

            while(listRopes.Count()>=2)
            {
                first = listRopes.Min();
                listRopes.Remove(first);
                second = listRopes.Min();
                listRopes.Remove(second);
                cost =cost+ first + second;
                listRopes.Add(first + second);
            }

            return cost;
        }
    }
}
