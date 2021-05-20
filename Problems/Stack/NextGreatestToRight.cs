using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems.Stack
{
   public class NextGreatestToRight
    {
        public static List<int> NextGreaterToRight(int [] numbers)
        {
            if(numbers.Length == 0)
            {
                return new List<int>();
            }

            List<int> result = new List<int>();
            Stack<int> stack = new Stack<int>();

            for(int i = numbers.Length-1;i>=0;i--)
            {
                if(result.Count == 0)
                {
                    result.Add(-1);
                    stack.Push(numbers[i]);
                }
                else if(stack.Peek()>numbers[i])
                {
                    result.Add(stack.Peek());
                    stack.Push(numbers[i]);
                }
                else
                {
                    while(stack.Peek()<=numbers[i])
                    {
                        stack.Pop();
                    }

                    if(stack.Count==0)
                    {
                        result.Add(-1);
                        stack.Push(numbers[i]);
                    }
                    else
                    {
                        result.Add(stack.Peek());
                        stack.Push(numbers[i]);
                    }
                }
            }

            return result;


        }
    }
}
