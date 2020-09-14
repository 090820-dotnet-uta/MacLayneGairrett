using System;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UseFor();
            UseDoWhile();
            UseWhile();
        }
        
        public static void UseFor()
        {
            for (int n = 1; n < 50; n = n + 2){
                System.Console.WriteLine($"{n}");
            }
        }

        public static void UseDoWhile()
        {
            int n = 0;
            do{
                System.Console.WriteLine($"{n} ");
                n = n + 2;
            }
            while (n <= 50);
        }

        public static void UseWhile()
        {
            int n = 0;
            while(n < 100){
                n = n + 3;
                if(n > 100){
                break;
                }
                if (n % 5 == 0){
                System.Console.WriteLine("Skipping this number.");
                }
                else{
                System.Console.WriteLine(n);
                }
            }
        }
    }
}
// 2. create a do/while loop that displays the even integers from 0 to 50.
// 3. create a while loop that displays the multiples of 3 integers from 0 to 100. 
//     1. Design the loop so that when every multiple of 3 and 5 coincide(like 15, 30, etc), you print "skipping this number" instead of the number.
//     2. Design the loop so that when you get above 100 you automatically stop the loop with a break statement.