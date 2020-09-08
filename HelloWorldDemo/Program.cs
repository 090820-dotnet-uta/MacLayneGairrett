using System;

namespace HelloWorldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello MacLayne Gairrett");
            Console.WriteLine("What is your name?");
            string input = Console.ReadLine();
            System.Console.WriteLine($"Hello {input}");
            System.Console.WriteLine("Hello {0}", input);
        }
    }
}
