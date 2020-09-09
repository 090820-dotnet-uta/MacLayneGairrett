using System;

namespace Delegates
{
    class Program
    {
        public delegate double PerformCalculation(double x, double y);

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            PerformCalculation pc = Multiply;

            System.Console.WriteLine(pc(5.0, 6.0));

            pc += divide;
            pc += Subtract;
            // System.Console.WriteLine(pc(5.0, 6.0));

            foreach (var item in pc.GetInvocationList())
            {
                System.Console.WriteLine(item.DynamicInvoke(5.0, 6.0));
            }
        }

        // method 1
        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        //method 2
        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        //method 3
        public static double divide(double x, double y)
        {
            return x / y;
        }

    }
}
