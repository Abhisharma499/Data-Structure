using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    public class OddEvenThread
    {
        public static async Task printEvenNumber(int n)
        {
           await Task.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i % 2 == 0)
                        Console.WriteLine(i);
                }
            });
        }

        private static async Task printOddNumbers(int n)
        {
            await Task.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i % 2 == 1)
                        Console.WriteLine(i);
                }
            });   
        }

        public async static Task printNumbers(int n)
        {

            Task evenNumbers = printEvenNumber(n);
            Task oddNumbers = printOddNumbers(n);

            List<Task> tasks = new List<Task>() { evenNumbers, oddNumbers };

           await Task.WhenAll(tasks);
        }
    }
}
