using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.Problems
{
    public static class RecursionProblems
    {
        static int[,] mem = new int[3, 3];
        static int[,] maze = new int[4, 4]
        {
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0}
        };

        public static int LCS(string s1, string s2, int n, int m)
        {
            if (n == 0 || m == 0)
            {
                return 0;
            }

            if (mem[n - 1, m - 1] != 0)
            {
                return mem[n - 1, m - 1];
            }

            if (s1[n - 1] == s2[m - 1])
            {
                return mem[n - 1, m - 1] = 1 + LCS(s1, s2, n - 1, m - 1);
            }
            else
            {
                return mem[n - 1, m - 1] = Math.Max(LCS(s1, s2, n - 1, m), LCS(s1, s2, n, m - 1));
            }
        }

        public static int LCSubstring(string s1, string s2, int n, int m, int count)
        {
            if (n == 0 || m == 0)
            {
                return 0;
            }

            if (mem[n - 1, m - 1] != 0)
            {
                return mem[n - 1, m - 1];
            }

            if (s1[n - 1] == s2[m - 1])
            {
                return count = mem[n - 1, m - 1] = 1 + LCSubstring(s1, s2, n - 1, m - 1, count + 1);
            }
            else
            {
                return count = mem[n - 1, m - 1] = Math.Max(LCSubstring(s1, s2, n - 1, m, 0), LCSubstring(s1, s2, n, m - 1, 0));
            }
        }

        public static string ReverseString(string input)
        {

            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            int k = 0;
            while (input[k].ToString() == " ")
                k++;

            input = input.Remove(0, k);

            String result = string.Empty;
            string temp = " ";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i].ToString() != " ")
                {
                    temp = input[i] + temp;
                }
                else
                {
                    if (temp != " ")
                    {
                        result = result + temp;
                        temp = string.Empty;
                        temp = " ";
                    }
                }
            }

            temp = temp.Remove(temp.Length - 1, 1);

            return result + temp;

        }

        public static List<List<int>> Subsets(int[] nums)
        {
            var result = new List<List<int>>();
            CombinationSum2(nums.ToList().OrderBy(x => x).ToList(), new List<int>(), result, 0, 8);
            PrintSubsets("12", "");

            return result; ;
        }

        public static void GenerateSubsets(List<int> numbers, List<int> subset, List<List<int>> output)
        {
            if (numbers.Count == 0)
            {
                output.Add(subset);
                return;
            }


            List<int> out1 = new List<int>();

            foreach (int item in subset)
            {
                out1.Add(item);
            }
            out1.Add(numbers[0]);


            List<int> out2 = new List<int>();

            foreach (int item in subset)
            {
                out2.Add(item);
            }

            numbers.RemoveAt(0);

            GenerateSubsets(numbers, out1, output);
            GenerateSubsets(numbers, out2, output);

        }

        public static void PrintSubsets(string input, string output)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(output);
                return;
            }

            string output1 = output + input[0];
            string output2 = output;
            input = input.Remove(0, 1);

            PrintSubsets(input, output1);
            PrintSubsets(input, output2);

        }




        public static void PrintSubsets2(List<int> input, List<int> output, List<List<int>> result)
        {
            if (input.Count == 0)
            {
                result.Add(output);

                return;
            }

            List<int> output1 = new List<int>();
            output1.AddRange(output);
            output1.Add(input[0]);
            List<int> output2 = new List<int>();
            output2.AddRange(output);
            input.RemoveAt(0);

            PrintSubsets2(input, output1, result);
            PrintSubsets2(input, output2, result);

        }

        public static void GenerateSubsets3(List<int> numbers, List<int> subset, List<List<int>> output, int index)
        {
            List<int> temp = new List<int>();
            temp.AddRange(subset);
            output.Add(temp);

            for (int i = index; i < numbers.Count; i++)
            {
                if (i > index)
                {
                    if (numbers[i] == numbers[i - 1])
                        continue;
                }

                subset.Add(numbers[i]);
                GenerateSubsets3(numbers, subset, output, i + 1);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        public static void GenerateSubsetsDuplicateremoval(List<int> numbers, List<int> subset, List<List<int>> output, int index)
        {
            List<int> temp = new List<int>();
            temp.AddRange(subset);
            output.Add(temp);

            for (int i = index; i < numbers.Count; i++)
            {
                if (i > index)
                {
                    if (numbers[i] == numbers[i - 1])
                        continue;
                }

                subset.Add(numbers[i]);
                GenerateSubsets3(numbers, subset, output, i + 1);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        public static void CombinationSum(List<int> numbers, List<int> subset, List<List<int>> output, int index, int target)
        {
            if (subset.Sum() == target)
            {
                List<int> temp = new List<int>();
                temp.AddRange(subset);
                output.Add(temp);
            }

            for (int i = index; i < numbers.Count; i++)
            {
                subset.Add(numbers[i]);

                if (subset.Sum() <= target)
                {
                    CombinationSum(numbers, subset, output, i, target);

                }

                subset.RemoveAt(subset.Count - 1);
            }
        }

        public static void CombinationSum2(List<int> numbers, List<int> subset, List<List<int>> output, int index, int target)
        {
            if (subset.Sum() == target)
            {
                List<int> temp = new List<int>();
                temp.AddRange(subset);
                output.Add(temp);
            }

            for (int i = index; i < numbers.Count; i++)
            {
                if (i > index && numbers[i] == numbers[i - 1])
                {
                    continue;
                }

                subset.Add(numbers[i]);

                if (subset.Sum() <= target)
                {
                    CombinationSum2(numbers, subset, output, i + 1, target);

                }

                subset.RemoveAt(subset.Count - 1);
            }
        }

        public static void PrintPermutationWithSpaces(string input, string output)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(output);
                return;
            }

            string output1 = output + "_" + input[0];
            string output2 = output + input[0];
            input = input.Remove(0, 1);

            PrintPermutationWithSpaces(input, output1);
            PrintPermutationWithSpaces(input, output2);

        }

        public static void PrintPermutationWithCase(string input, string output)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(output);
                return;
            }

            string output1 = output + input[0].ToString().ToLower();
            string output2 = output + input[0].ToString().ToUpper();
            input = input.Remove(0, 1);

            PrintPermutationWithCase(input, output1);
            PrintPermutationWithCase(input, output2);

        }

        public static void PrintPermutation(string input, string output)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(output);
                return;
            }

            string output1 = output + input[0].ToString();
            string output2 = output;
            input = input.Remove(0, 1);

            PrintPermutation(input, output1);
            PrintPermutation(input, output2);

        }

        public static void PrintPermutationWithLetterCase(string input, string output)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(output);
                return;
            }

            string output1 = string.Empty;
            string output2 = string.Empty;

            output1 = output + input[0].ToString().ToLower() + input[1].ToString();
            output2 = output + input[0].ToString().ToUpper() + input[1].ToString();


            input = input.Remove(0, 2);

            PrintPermutationWithLetterCase(input, output1);
            PrintPermutationWithLetterCase(input, output2);

        }

        public static void Permutation(List<int> input, List<int> output, List<List<int>> result)
        {
            if (input.Count == output.Count)
            {
                List<int> tempResult = new List<int>();
                tempResult.AddRange(output);
                result.Add(tempResult);
                return;
            }

            for (int i = 0; i < input.Count; i++)
            {

                if (output.Contains(input[i]))
                    continue;
                output.Add(input[i]);

                Permutation(input, output, result);

                output.RemoveAt(output.Count - 1);

            }
        }

        public static void PalindromePartitioning(string input, string output, List<string> result)
        {
            if (string.IsNullOrEmpty(input))
            {
                if (IsPalindrome(output))
                    result.Add(output);
                return;
            }

            string out1 = output;
            string out2 = output;

            out1 += input[0];

            input = input.Remove(0, 1);

            PalindromePartitioning(input, out1, result);
            PalindromePartitioning(input, out2, result);


        }

        public static bool IsPalindrome(string output)
        {
            if (output.Length == 0)
            {
                return false;
            }
            else if (output.Length == 1)
            {
                return true;
            }

            int j = output.Length - 1;
            for (int i = 0; i < output.Length / 2; i++)
            {
                if (output[i] != output[j])
                {
                    return false;
                }

                j--;
            }

            return true;
        }

        public static int CountNumberOfBits(int num)
        {
            int count = 0;

            if (num <= 0)
            {
                return 0;
            }

            for (int i = 0; i < 32; i++)
            {
                if ((num & 1) == 1)
                {
                    count++;
                }
                num = num >> 1;
            }

            return count;
        }

        public static int CountSetBits(int num)
        {
            int count = 0;

            if (num <= 0)
            {
                return 0;
            }

            while ((num & num - 1) != 0)
            {
                count++;
            }

            return count;
        }

        public static int PowerWithoutMultiplyAndDivideSign(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            int count = number - 1;

            int result = number;

            for (int i = 0; i < power - 1; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    result += number;
                }

                number = result;
            }

            return result;
        }

        public static int CompareVersion(string version1, string version2)
        {
            string[] v1 = version1.Split('.');
            string[] v2 = version2.Split('.');
            int maxLength = v1.Length > v2.Length ? v1.Length : v2.Length;

            int i = 0;
            int a, b;

            //7.5.2.4
            //7.5.3
            while (i < maxLength)
            {
                if (v1.Length > i)
                {
                    a = Convert.ToInt32(v1[i]);
                }
                else
                {
                    a = 0;
                }

                if (v2.Length > i)
                {
                    b = Convert.ToInt32(v2[i]);
                }
                else
                {
                    b = 0;
                }

                if (a > b)
                {
                    return 1;
                }
                else if (b > a)
                {
                    return -1;
                }

                i++;
            }

            return 0;
        }

        public static void SortArray(int[] array, int size)
        {
            if (size == 0)
            {
                return;
            }

            //SortArray(array, size-1);

            int maxIndex = SortWithMaxElement(array, size);
            int temp = 0;

            temp = array[size - 1];
            array[size - 1] = array[maxIndex];
            array[maxIndex] = temp;

            SortArray(array, size - 1);

        }

        //  {4,3,1,2,9,5}
        public static void SortStack(Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }

            int temp = stack.Pop();

            SortStack(stack);

            InsertAtCorrectPosition(stack, temp);
        }

        public static void InsertAtCorrectPosition(Stack<int> stack, int temp)
        {
            if (stack.Count == 0 || stack.Peek() < temp)
            {
                stack.Push(temp);
                return;
            }

            int top = stack.Pop();

            InsertAtCorrectPosition(stack, temp);

            stack.Push(top);

        }

        public static int SortWithMaxElement(int[] array, int size)
        {
            int max = array[0];
            int maxIndex = 0;

            for (int i = 1; i <= size - 1; i++)
            {
                if (array[i] > max)
                {
                    maxIndex = i;
                    max = array[i];
                }
            }

            return maxIndex;
        }
        //ABHISHEK
        public static void ReverseString(List<char> ReverseList)
        {
            if (ReverseList.Count == 0)
            {
                return;
            }

            char temp = ReverseList[0];
            ReverseList.RemoveAt(0);

            ReverseString(ReverseList);

            ReverseList.Add(temp);

        }
        public static void JosephusProblem(int k, List<int> personsList)
        {

            if (personsList.Count == 1)
            {
                return;
            }

            personsList.RemoveAt(k);

            if (k > personsList.Count - 1)
            {
                k = k % personsList.Count;
            }
            else
            {
                k++;
            }

            JosephusProblem(k, personsList);
        }

        public static void BalancedParanthesis(int open, int close, List<string> balanceParanthesisList, string output)
        {
            if (open == 0 && close == 0)
            {
                balanceParanthesisList.Add(output);
                return;
            }
            else
            {
                if (open > 0)
                {
                    BalancedParanthesis(open - 1, close, balanceParanthesisList, output + "(");
                }
                if (close > open && close > 0)
                {
                    BalancedParanthesis(open, close - 1, balanceParanthesisList, output + ")");
                }
            }
        }

        public static void PermutationCaseChange(string input, string output)
        {
            if (input.Length == 0)
            {
                Console.WriteLine(output);
                return;
            }

            string output1 = output;
            string output2 = output;

            output1 += input[0].ToString().ToLower();
            output2 += input[0].ToString().ToUpper();

            input = input.Remove(0, 1);

            PermutationCaseChange(input, output1);
            PermutationCaseChange(input, output2);

        }

        public static void PermutationLetterCase(string input, string output)
        {
            if (input.Length == 0)
            {
                Console.WriteLine(output);
                return;
            }

            string output1 = output;
            string output2 = output;

            output1 += input[0].ToString().ToLower() + input[1].ToString();
            output2 += input[0].ToString().ToUpper() + input[1].ToString();

            input = input.Remove(0, 2);

            PermutationLetterCase(input, output1);
            PermutationLetterCase(input, output2);

        }

        public static void permutationFind(String input, String output)
        {
            if (input.Length == 0)
            {
                Console.WriteLine(output);
                return;
            }
            String out1 = output;
            String out2 = output;

            out2 += input[0];

            input = input.Remove(0, 1);

            permutationFind(input, out1);
            permutationFind(input, out2);
        }

        private static void permutationWithSpaces(String input, String output)
        {
            if (input.Length == 0)
            {
                Console.WriteLine(output);
                return;
            }
            String out1 = output;
            String out2 = output;

            out1 += input[0];
            out2 += "_" + input[0];
            input = input.Remove(0, 1);

            permutationWithSpaces(input, out1);
            permutationWithSpaces(input, out2);
        }


        //1,2,3,4,5

        //5,4,3,2,1
        public static void ReverseAStack(Stack<int> stack)
        {
            if (stack.Count() == 0)
            {
                return;
            }


            int item = stack.Pop();

            ReverseAStack(stack);

            InsertInBeginning(stack, item);

        }

        public static void InsertInBeginning(Stack<int> stack, int item)
        {
            if (stack.Count() == 0)
            {
                stack.Push(item);
            }
            else
            {
                int itemTemp = stack.Pop();
                InsertInBeginning(stack, item);
                stack.Push(itemTemp);

            }
        }

        //{ 10, 11, 1, 3, -1, 8, 6 };


        public static void DeleteMidElementFromStack(Stack<int> stack, int mid)
        {
            if (stack.Count() == mid)
            {
                stack.Pop();
                return;
            }



            int temp = stack.Pop();

            DeleteMidElementFromStack(stack, mid);

            stack.Push(temp);

        }

        public static void SortList(List<int> mylist)
        {
            if (mylist.Count == 0)
            {
                return;
            }


            int temp = mylist[mylist.Count - 1];
            mylist.RemoveAt(mylist.Count - 1);

            SortList(mylist);
            GetMaxIndexInList(mylist, temp);


        }

        public static void GetMaxIndexInList(List<int> mylist, int temp)
        {
            if (mylist.Count == 0)
            {
                mylist.Add(temp);
                return;
            }

            if (mylist[mylist.Count - 1] < temp)
            {
                mylist.Add(temp);
                return;
            }
            else
            {
                int newtemp = mylist[mylist.Count - 1];
                mylist.RemoveAt(mylist.Count - 1);
                GetMaxIndexInList(mylist, temp);
                mylist.Add(newtemp);

            }

        }

        public static void TowerOfHanoi(int S, int H, int D, int N)
        {
            if (N == 1)
            {
                Console.WriteLine("Moving a Disk " + N + " from" + S.ToString() + " to " + D.ToString());

                return;
            }

            TowerOfHanoi(S, D, H, N - 1);

            Console.WriteLine("Moving a Disk " + N + " from" + S.ToString() + " to " + D.ToString());

            TowerOfHanoi(H, S, D, N - 1);

        }

        public static void PrintSubsets1(string input, string output)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(output);
                return;
            }

            string output1 = input[input.Length - 1] + output;
            string output2 = output;
            input = input.Substring(0, input.Length - 1);

            PrintSubsets(input, output2);
            PrintSubsets(input, output1);
        }

        //1,2,3,4,5
        //2
        public static void JosephusProblem(int k, List<int> personsList, int startIndex)
        {

            if (personsList.Count == 1)
            {
                return;
            }

            startIndex = (startIndex + k - 1) % personsList.Count;
            personsList.RemoveAt(startIndex);

            JosephusProblem(k, personsList, startIndex);
        }

        public static void NBitBinaryNumberWithOneGreaterThanEqualZero(int one, int zero, int n, string output)
        {
            if (n == 0)
            {
                Console.WriteLine(output);
                return;
            }

            NBitBinaryNumberWithOneGreaterThanEqualZero(one + 1, zero, n - 1, output + "1");


            if (one > zero)
            {
                NBitBinaryNumberWithOneGreaterThanEqualZero(one, zero + 1, n - 1, output + "0");
            }
        }

        public static IList<IList<int>> Subsets1(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);
            SubsetsLoop(nums, new List<int>(), result, 0, 7);

            return result;
        }

        public static void Combinations(List<int> numbers, List<int> output, List<IList<int>> subsets, int index, int countAllowed)
        {
            if (output.Count == countAllowed)
            {
                List<int> temp = new List<int>();
                temp.AddRange(output);
                subsets.Add(temp);

            return;
        }

            for (int i = index; i < numbers.Count(); i++)
            {
                output.Add(numbers[i]);
                Combinations(numbers, output, subsets, i + 1, countAllowed);
                output.RemoveAt(output.Count() - 1);
            }
        }

        public static void CombinationsSum(int[] numbers, List<int> output, List<IList<int>> subsets, int index, int target, int size)
        {
            if (output.Sum() == target && output.Count() == size)
            {
                List<int> temp = new List<int>();
                temp.AddRange(output);
                subsets.Add(temp);

                return;
            }

            for (int i = index; i < numbers.Length; i++)
            {
                if (i > index && numbers[i] == numbers[i - 1])
                {
                    continue;
                }
                if (output.Sum() + numbers[i] > target)
                {
                    continue;
                }

                output.Add(numbers[i]);
                CombinationsSum(numbers, output, subsets, i + 1, target, size);
                output.RemoveAt(output.Count() - 1);
            }
        }

        public static void Permutation(int[] numbers, List<int> output, List<IList<int>> subsets, bool[] used)
        {
            if (output.Count == numbers.Length)
            {
                List<int> temp = new List<int>();
                temp.AddRange(output);
                subsets.Add(temp);

                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    output.Add(numbers[i]);
                    Permutation(numbers, output, subsets, used);
                    output.RemoveAt(output.Count() - 1);
                    used[i] = false;
                }
            }
        }

        

        public static void Subsets1(int[] numbers, List<int> output, List<IList<int>> subsets, int index)
        {
            List<int> temp = new List<int>();
            temp.AddRange(output);

            subsets.Add(temp);
            for (int i = index; i < numbers.Length; i++)
            {
                if (i > index && numbers[i - 1] == numbers[i])
                {
                    continue;
                }

                output.Add(numbers[i]);
                Subsets1(numbers, output, subsets, i + 1);
                output.RemoveAt(output.Count() - 1);

            }
        }

        public static void Subsets(int[] numbers, List<int> result, List<IList<int>> subsets, int i)
        {
            if (numbers.Length == i && !subsets.Contains(result))
            {
                subsets.Add(result);
                return;
            }

            List<int> out1 = new List<int>() { };
            out1.AddRange(result);
            out1.Add(numbers[i]);
            List<int> out2 = new List<int>() { };
            out2.AddRange(result);

            Subsets(numbers, out1, subsets, i + 1);
            Subsets(numbers, out2, subsets, i + 1);

        }

        public static void SubsetsLoop(int[] numbers, List<int> result, List<IList<int>> subsets, int index, int target)
        {
            List<int> temp = new List<int>();
            temp.AddRange(result);

            if (temp.Sum() == target)
            {
                subsets.Add(temp);
            }

            for (int i = index; i < numbers.Length; i++)
            {
                result.Add(numbers[i]);
                if (result.Sum() <= target)
                {
                    SubsetsLoop(numbers, result, subsets, i, target);
                }
                result.Remove(numbers[i]);
            }
        }

        public static void PrintStringPermutaion(string input, string output)
        {
            if (input.Length == 0)
            {
                if (output.Length == 0)
                    return;
                Console.WriteLine(output);
                return;
            }

            string output1 = output;
            string output2 = output;

            output1 += input[0];

            input = input.Remove(0, 1);

            PrintStringPermutaion(input, output2);
            PrintStringPermutaion(input, output1);

        }

        public static void NQueenProblem()
        {
            int[,] board = new int[8, 8];

            bool result = SolveNQueen(board, 0);

        }

        public static bool SolveNQueen(int[,] board, int currentRow)
        {

            if (board.GetLength(0) == currentRow)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(0); j++)
                    {
                        if (board[i, j] == 1)
                        {
                            Console.Write("Q");

                        }
                        else
                        {
                            Console.Write("-");
                        }
                    }

                    Console.WriteLine();
                }


                return true;
            }

            for (int j = 0; j < board.GetLength(0); j++)
            {
                if (IsSafePlace(board, currentRow, j))
                {
                    board[currentRow, j] = 1;
                    if (SolveNQueen(board, currentRow + 1))
                    {
                        return true;
                    }
                    else
                    {
                        board[currentRow, j] = 0;
                    }
                }
            }

            return false;
        }
        public static bool IsSafePlace(int[,] board, int i, int j)
        {
            int row = i;
            int column = j;
            while (row >= 0)
            {
                if (board[row, column] == 1)
                {
                    return false;
                }
                row--;
            }

            row = i;
            column = j;

            while (row >= 0 && column >= 0)
            {
                if (board[row, column] == 1)
                {
                    return false;
                }
                row--;
                column--;
            }

            row = i;
            column = j;

            while (row >= 0 && column < board.GetLength(0))
            {
                if (board[row, column] == 1)
                {
                    return false;
                }
                row--;
                column++;
            }

            return true;
        }

        public static int RatInMaze(int startX, int startY, int endX, int endY)
        {
            if ((startX > endX || startY > endY) || (maze[startX, startY] == 1))
            {
                return 0;
            }
            else if (startX == endX && startY == endY)
            {
                return 1;
            }

            int rightPath = RatInMaze(startX + 1, startY, endX, endY);
            int LeftPath = RatInMaze(startX, startY + 1, endX, endY);



            return rightPath + LeftPath;
        }
        public static int UniquePaths(int startX, int startY, int endX, int endY)
        {
            if ((startX > endX || startY > endY))
            {
                return 0;
            }
            else if (startY == endX && startY == endY)
            {
                return 1;
            }

            if (mem[startX, startY] != 0)
            {
                return mem[startX, startY];
            }

            int bottomPath = UniquePaths(startX + 1, startY, endX, endY);
            int rightPath = UniquePaths(startX, startY + 1, endX, endY);

            return mem[startX, startY] = bottomPath + rightPath;
        }

        public static int UniquePathsWithObstacles(int[][] inputArray)
        {
            //int[,] myarray = To2D(inputArray);
            int testrow = mem.GetUpperBound(0) + 1;
            int testcol = mem.GetUpperBound(1) + 1;
            var row = inputArray.GetUpperBound(0) + 1;
            var column = inputArray[0].Length;
            mem = new int[row, column];
            int result = NumberOfUniqueWays(0, 0, row - 1, column - 1, row - 1, column - 1, inputArray);
            return result;

        }

        public static int NumberOfUniqueWays(int startx, int starty, int endx, int endy, int rows, int column, int[][] obstacleGrid)
        {
            if (startx > rows || starty > column || obstacleGrid[startx][starty] == 1)
            {
                return 0;
            }

            if (mem[startx, starty] != 0)
            {
                return mem[startx, starty];
            }

            if (startx == endx && starty == endy)
            {
                return 1;
            }

            int bottonAnswer = NumberOfUniqueWays(startx + 1, starty, endx, endy, rows, column, obstacleGrid);
            int RightAnswer = NumberOfUniqueWays(startx, starty + 1, endx, endy, rows, column, obstacleGrid);

            return mem[startx, starty] = bottonAnswer + RightAnswer;
        }

        static int[,] To2D(int[][] source)
        {
            try
            {
                int FirstDim = source.Length;
                int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new int[FirstDim, SecondDim];
                for (int i = 0; i < FirstDim; ++i)
                    for (int j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            }
        }

        public static void PrintAllPaths(int[][] maze, int rows, int columns, int x, int y, string output, List<string> result)
        {
            if (x >= rows || y >= columns)
            {
                return;
            }

            if (x == rows - 1 && y == columns - 1)
            {
                Console.WriteLine(output);
                result.Add(output);
                return;
            }

            PrintAllPaths(maze, rows, columns, x + 1, y, output + "V", result);
            PrintAllPaths(maze, rows, columns, x, y + 1, output + "H", result);

        }

        public static IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            Generate(n, n, "", result);
            return result;
        }

        public static bool WordBreak(string s, IList<string> wordDict, Dictionary<string, bool> mapper)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            if (mapper.ContainsKey(s))
            {
                return mapper[s];
            }

            for (int i = 1; i <= s.Length; i++)
            {
                if (wordDict.Contains(s.Substring(0, i)) && WordBreak(s.Substring(i), wordDict, mapper))
                {

                    return mapper[s] = true;
                }
            }

            return mapper[s] = false;

        }

        public static int MinPathSum(int[][] grid)
        {
            int rows = grid.GetUpperBound(0) + 1;
            int col = grid[0].Length;

            return Test(grid, rows, col, 0, 0);
        }

        public static int Test(int[][] grid, int rows, int col, int sx, int sy)
        {
            if (sx >= rows || sy >= col)
            {
                return int.MaxValue - 1;
            }

            if (sx == rows - 1 && sy == col - 1)
            {
                return grid[rows - 1][col - 1];
            }

            int leftAnswer = Test(grid, rows, col, sx + 1, sy);
            int rightAnswer = Test(grid, rows, col, sx, sy + 1);

            return grid[sx][sy] + Math.Min(leftAnswer, rightAnswer);

        }

        public static int Test2(BinaryTree root, ref int result)
        {
            if (root == null)
            {
                return 0;
            }

            int leftresult = Test2(root.left, ref result);
            int rightresult = Test2(root.right, ref result);

            int temp = 1 + Math.Max(leftresult, rightresult);
            int ans = 1 + leftresult + leftresult;

            result = Math.Max(result, ans);

            return temp;


        }
        public static void Generate(int left, int right, string output, List<string> result)
        {
            if (left == 0 && right == 0)
            {
                result.Add(output);

                return;
            }

            if (left > 0)
            {
                Generate(left - 1, right, output + "(", result);
            }

            if (right > 0 && right > left)
            {
                Generate(left, right - 1, output + ")", result);
            }
        }

        public static void CombinationsPractice(int[] numbers, List<int> output, List<IList<int>> subsets, int index, int target)
        {
            List<int> test = new List<int>();
            test.AddRange(output);
            subsets.Add(test);

            for (int i = index; i < numbers.Length; i++)
            {
                output.Add(numbers[i]);

                //if (output.Sum() <= target)
                //{
                CombinationsPractice(numbers, output, subsets, i + 1, target);
                //}

                output.Remove(numbers[i]);
            }

        }

        public static void SubsetsLoop1(int[] numbers, List<int> result, List<IList<int>> subsets, int index, int target)
        {
            List<int> temp = new List<int>();
            temp.AddRange(result);

            if (temp.Sum() == target)
            {
                subsets.Add(temp);
            }

            for (int i = index; i < numbers.Length; i++)
            {
                result.Add(numbers[i]);
                if (result.Sum() <= target)
                {
                    SubsetsLoop(numbers, result, subsets, i, target);
                }

                result.Remove(numbers[i]);
            }
        }

        public static void Test1239(List<string> numbers, string output, List<string> test)
        {
            if (numbers.Count() == 0)
            {
                test.Add(output);
                return;
            }

            string output1 = output + numbers[0];
            string output2 = output;

            numbers.RemoveAt(0);

            Test1239(numbers, output1,test);
            Test1239(numbers, output2,test);
        }


        public static void Test1239New(List<string> numbers, List<string> output, List<string> test, int index)
        {
            if (output.Count() <= 2 && output.Count()!=0)
            {
                if (output.Count == 1)
                {
                    test.Add(output[0]);
                }
                else
                {
                    test.Add(output[0] + output[1]);
                }
            }

            for(int i= index;i<numbers.Count();i++)
            {

                output.Add(numbers[i]);

                Test1239New(numbers, output, test, i + 1);

                output.Remove(numbers[i]);
            }
        }
    }
}
