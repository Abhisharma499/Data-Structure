using System;
using System.IO;

namespace TestProject
{
    class Tuple
    {
        //int a = 10;
        //int b = 20;
        //(int a_plus_b, int a_mult_b) = Add_Multiply(a, b);
        //Console.WriteLine(a_plus_b);
        //Console.WriteLine(a_mult_b);

        public void TupleExample()
        {

            try
            {
                try
                {
                    var num = int.Parse("abc"); // Throws FormatException               
                }
                catch (FormatException fe)
                {
                    try
                    {
                        var openLog = File.Open("DoesNotExist", FileMode.Open);
                    }
                    catch
                    {
                        throw new FileNotFoundException("NestedExceptionMessage: File `DoesNotExist` not found.", fe);
                    }
                }
            }
            // Consider what exception is thrown: FormatException or FileNotFoundException?
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                // FormatException isn't caught because it's stored "inside" the FileNotFoundException
            }
            catch (FileNotFoundException fnfe)
            {
                string inMes = "", outMes;
                if (fnfe.InnerException != null)
                    inMes = fnfe.InnerException.Message; // Inner exception (FormatException) message
                outMes = fnfe.Message;
                Console.WriteLine($"Inner Exception:\n\t{inMes}");
                Console.WriteLine($"Outter Exception:\n\t{outMes}");
            }
        }
    }

    //private static (int a_plus_b, int a_mult_b) Add_Multiply(int a, int b)
    //{
    //    return (a + b, a * b);
    //}

    //private static Tuple<int, int> Add_Multiply(int a, int b)
    //{
    //    var tuple = new Tuple<int, int>(a + b, a * b);
    //    return tuple;
    //}
}

