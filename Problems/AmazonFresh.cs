using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class AmazonFresh
    {
        public static bool IsCustomerWinner(List<List<string>> codeList, List<string> shoppingCart)
        {
            List<string> fruitList1 = codeList[0];
            List<string> fruitList2 = codeList[1];
            bool Ismatch = false;
            int j = 0;
            int i = 0;
            
            while(i< shoppingCart.Count && j< fruitList1.Count)
            {
                if(shoppingCart[i]!= fruitList1[j] && fruitList1[j] != "anything")
                {
                    if (j > 0)
                    {
                        j = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++;j++;
                }
            }

            if(j== fruitList1.Count)
            {
                j = 0;
            }
            else
            {
                return false;
            }

            while(i< shoppingCart.Count && j < fruitList2.Count)
            {
                if (shoppingCart[i] != fruitList2[j] && fruitList2[j] != "anything")
                {
                    if (j > 0)
                    {
                        j = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++; j++;
                }
            }

            if(j== fruitList2.Count)
            {
                return true;
            }

            return false;
        }
    }
}
