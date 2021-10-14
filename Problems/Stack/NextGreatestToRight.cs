using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems.Stack
{
   public class Test
    {
        public int pos;
        public int val;

        public Test(int p, int v)
        {
            this.pos = p;
            this.val = v;
        }
    }
    public class NextGreatestToRight
    {
        public static List<Test> NextSmallerToRight(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return new List<Test>();
            }

            List<Test> result = new List<Test>();
            Stack<Test> stack = new Stack<Test>();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (result.Count == 0)
                {
                    result.Add(new Test(-1,-1));
                    stack.Push(new Test(i,numbers[i]));
                }
                else if (stack.Peek().val < numbers[i])
                {
                    result.Add(stack.Peek());
                    stack.Push(new Test(i, numbers[i]));
                }
                else
                {
                    while (stack.Count() >0 && stack.Peek().val >= numbers[i])
                    {
                        stack.Pop();
                    }

                    if (stack.Count == 0)
                    {
                        result.Add(new Test(-1, -1));
                        stack.Push(new Test(i,numbers[i]));
                    }
                    else
                    {
                        result.Add(stack.Peek());
                        stack.Push(new Test(i, numbers[i]));
                    }
                }
            }
            result.Reverse();
            return result;


        }

        public static List<Test> NextSmallerToLeft(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return new List<Test>();
            }

            List<Test> result = new List<Test>();
            Stack<Test> stack = new Stack<Test>();

            for (int i = 0; i<numbers.Length; i++)
            {
                if (result.Count == 0)
                {
                    result.Add(new Test(-1, -1));
                    stack.Push(new Test(i, numbers[i]));
                }
                else if (stack.Peek().val < numbers[i])
                {
                    result.Add(stack.Peek());
                    stack.Push(new Test(i,numbers[i]));
                }
                else
                {
                    while (stack.Count() > 0 && stack.Peek().val >= numbers[i])
                    {
                        stack.Pop();
                    }

                    if (stack.Count == 0)
                    {
                        result.Add(new Test(-1, -1));
                        stack.Push(new Test(i, numbers[i]));
                    }
                    else
                    {
                        result.Add(stack.Peek());
                        stack.Push(new Test(i, numbers[i]));
                    }
                }
            }

            return result;


        }
    }
}
