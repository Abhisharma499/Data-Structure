using System.Collections.Generic;
using System.Linq;

namespace TestProject.Problems
{
    public static class StackProblems
    {
        public static List<int> LargestIntergerToRight(List<int> array, Stack<int> myStack)
        {
            List<int> result = new List<int>();
            for (int i = array.Count() - 1; i >= 0; i--)
            {
                if (myStack.Count() == 0)
                {
                    result.Add(-1);
                    myStack.Push(array[i]);
                }
                else if (myStack.Peek() > array[i])
                {
                    result.Add(myStack.Peek());
                    myStack.Push(array[i]);
                }
                else
                {
                    while (myStack.Count() > 0)
                    {
                        if (myStack.Peek() > array[i])
                        {
                            result.Add(myStack.Peek());
                            myStack.Push(array[i]);
                            break;
                        }

                        myStack.Pop();
                    }
                }

                if (myStack.Count() == 0)
                {
                    result.Add(-1);
                    myStack.Push(array[i]);
                }

            }

            result.Reverse();

            return result;
        }

        public static List<int> LargestIntergerToLeft(List<int> array, Stack<int> myStack)
        {
            List<int> result = new List<int>();

            for (int i = 0; i <= array.Count() - 1; i++)
            {
                if (myStack.Count() == 0)
                {
                    result.Add(-1);
                    myStack.Push(array[i]);
                }
                else if (myStack.Peek() > array[i])
                {
                    result.Add(myStack.Peek());
                    myStack.Push(array[i]);
                }
                else
                {
                    while (myStack.Count() > 0)
                    {
                        if (myStack.Peek() > array[i])
                        {
                            result.Add(myStack.Peek());
                            myStack.Push(array[i]);
                            break;
                        }

                        myStack.Pop();
                    }
                }

                if (myStack.Count() == 0)
                {
                    result.Add(-1);
                    myStack.Push(array[i]);
                }

            }

            return result;
        }


        //100,80,60,70,60,75,85
        public static List<int> StockSpanProblem(List<int> array)
        {
            List<int> result = new List<int>();
            Stack<int> myStack = new Stack<int>();
            int count = 1;
            Stack<int> tempElements = new Stack<int>();
            for (int i = 0; i <= array.Count() - 1; i++)
            {
                if (myStack.Count() == 0)
                {
                    result.Add(count);
                    myStack.Push(array[i]);
                    continue;
                }

                if (array[i] >= myStack.Peek())
                {
                    while (myStack.Count > 0 && array[i] >= myStack.Peek())
                    {
                        count++;
                        tempElements.Push(myStack.Pop());
                    }

                    result.Add(count);
                    count = 1;

                    while (tempElements.Count() > 0)
                    {
                        myStack.Push(tempElements.Pop());
                    }

                    myStack.Push(array[i]);

                }
                else
                {
                    result.Add(count);
                    myStack.Push(array[i]);
                }
            }


            return result;
        }

        //0  1  2   3  4  5  6
        //100 80 60 70 60 75 85
        public static List<int> StockSpanProblemEfficient(List<int> prices)
        {
            List<int> span = new List<int>();
            Stack<int> myStack = new Stack<int>();
            span.Add(1);
            myStack.Push(0);

            //0  1  2   3  4  5  6
            //100 80 60 70 60 75 85
            for (int i = 1; i <= prices.Count() - 1; i++)
            {
                if (prices[i] <= prices[myStack.Peek()])
                {
                    span.Add(i - myStack.Peek());
                    myStack.Push(i);
                    
                }

                //0  1  2   3  4  5  6
                //100 80 60 70 60 75 85
                else if (prices[i] > prices[myStack.Peek()])
                {
                    while (myStack.Count() != 0)
                    {
                        if (prices[i] > prices[myStack.Peek()])
                        {
                            myStack.Pop();
                        }
                        else
                        {
                            span.Add(i - myStack.Peek());
                            myStack.Push(i);
                            break;
                        }
                    }

                    //0  1  2   3  4  5  6
                    //100 80 60 70 60 75 85

                    if (myStack.Count() == 0)
                    {
                        myStack.Push(i);
                        span.Add(1);
                    }

                }
            }


            return span;
        }


        public static List<int> NearestGreaterToRight(List<int> numbers)
        {
            Stack<int> elementsStack = new Stack<int>();
            List<int> result = new List<int>();

            //1 3 2 4
            //3 4  4 -1 
            for(int i=numbers.Count()-1;i>=0;i--)
            {
                if(elementsStack.Count()==0)
                {
                    elementsStack.Push(numbers[i]);
                    result.Add(-1);
                }
                else if(elementsStack.Peek()>= numbers[i])
                {
                    result.Add(elementsStack.Peek());
                    elementsStack.Push(numbers[i]);
                }
                else
                {
                    while(elementsStack.Count()>0)
                    {
                        if (elementsStack.Peek() < numbers[i])
                        {
                            elementsStack.Pop();
                        }
                        else
                        {
                            result.Add(elementsStack.Peek());
                            elementsStack.Push(numbers[i]);
                            break;
                        }
                    }
                }

                
            }

            result.Reverse();

            return result;

        }


        public static List<int> NearestGreaterToLeft(List<int> numbers)
        {
            Stack<int> elementsStack = new Stack<int>();
            List<int> result = new List<int>();

            //1 3 2 4
            //-1 -1 3 -1
            for (int i = 0; i<=numbers.Count()-1; i++)
            {
                if (elementsStack.Count() == 0)
                {
                    elementsStack.Push(numbers[i]);
                    result.Add(-1);
                }
                else if (elementsStack.Peek() >= numbers[i])
                {
                    result.Add(elementsStack.Peek());
                    elementsStack.Push(numbers[i]);
                }
                else
                {
                    while (elementsStack.Count() > 0)
                    {
                        if (elementsStack.Peek() < numbers[i])
                        {
                            elementsStack.Pop();
                        }
                        else
                        {
                            result.Add(elementsStack.Peek());
                            elementsStack.Push(numbers[i]);
                            break;
                        }
                    }

                    if(elementsStack.Count() ==0)
                    {
                        result.Add(-1);
                        elementsStack.Push(numbers[i]);
                    }
                }


            }

            return result;

        }


        public static List<int> NearestSmallerToLeft(List<int> numbers)
        {
            Stack<int> elementsStack = new Stack<int>();
            List<int> result = new List<int>();

            //1 3 2 4
            //-1 1 1 2
            for (int i = 0; i <= numbers.Count() - 1; i++)
            {
                if (elementsStack.Count() == 0)
                {
                    elementsStack.Push(numbers[i]);
                    result.Add(-1);
                }
                else if (elementsStack.Peek()<= numbers[i])
                {
                    result.Add(elementsStack.Peek());
                    elementsStack.Push(numbers[i]);
                }
                else
                {
                    while (elementsStack.Count() > 0)
                    {
                        if (elementsStack.Peek()> numbers[i])
                        {
                            elementsStack.Pop();
                        }
                        else
                        {
                            result.Add(elementsStack.Peek());
                            elementsStack.Push(numbers[i]);
                            break;
                        }
                    }

                    if (elementsStack.Count() == 0)
                    {
                        result.Add(-1);
                        elementsStack.Push(numbers[i]);
                    }
                }


            }

            return result;

        }


        public static List<int> NearestSmallerToRight(List<int> numbers)
        {
            Stack<int> elementsStack = new Stack<int>();
            List<int> result = new List<int>();

            //1 3 2 4
            //-1  2 -1 -1
            for (int i = numbers.Count() - 1; i >= 0; i--)
            {
                if (elementsStack.Count() == 0)
                {
                    elementsStack.Push(numbers[i]);
                    result.Add(-1);
                }
                else if (elementsStack.Peek() <= numbers[i])
                {
                    result.Add(elementsStack.Peek());
                    elementsStack.Push(numbers[i]);
                }
                else
                {
                    while (elementsStack.Count() > 0)
                    {
                        if (elementsStack.Peek() > numbers[i])
                        {
                            elementsStack.Pop();
                        }
                        else
                        {
                            result.Add(elementsStack.Peek());
                            elementsStack.Push(numbers[i]);
                            break;
                        }
                    }

                    if (elementsStack.Count() == 0)
                    {
                        result.Add(-1);
                        elementsStack.Push(numbers[i]);
                    }
                }


            }

            result.Reverse();

            return result;

        }
    }
}
