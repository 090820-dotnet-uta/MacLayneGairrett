using System;
namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            string name = GetName();
            GreetFriend(name);

            //2
            double result1 = GetNumber();
            double result2 = GetNumber();
            int action1 = GetAction();
            double result3 = DoAction(result1, result2, action1);

            System.Console.WriteLine($"The result of your mathematical operation is {result3}.");

        }

        public static string GetName()
        {
            Console.WriteLine("What is your name?");
            string newName = Console.ReadLine();
            return newName;
            //throw new NotImplementedException();

        }

        public static void GreetFriend(string name)
        {
            //Greeting should be: Hello, nameVar. You are my friend
            //Ex: Hello, Jim. You are my friend
            Console.WriteLine($"Hello, {name}. You are my friend");
            return;    
            //throw new NotImplementedException();
        }
        public static double GetNumber()
        {
            //Should throw FormatException if the user did not input a number
            Console.WriteLine("Please input a number");
            string test = Console.ReadLine();
            double num;
        
            if(Double.TryParse(test, out num))
            {
                num = double.Parse(test);
                return num;
            }
            else
            throw new FormatException();
            //throw new NotImplementedException();
        }

        public static int GetAction()
        {
            int result;
            bool test;

            do
            {
            Console.WriteLine("Please input an integer for the corresponding acition:\n1)add\n2)subtract\n3)multiply\n4)divide");
            string response = Console.ReadLine();
            test = int.TryParse(response, out result);

            } while(!(result > 0 && result < 5) || test == false);

        return result;
        }   

        public static double DoAction(double x, double y, int z)
        {
            double final;
            if (z == 1){

                final = x + y;
                return final;
            }

            else if (z == 2){

                final = y - x;
                return final;
            }

            else if (z == 3){

                final = x * y;
                return final;
            }

            else if (z == 4){

                if (x ==0){
                    throw new FormatException();
                }

                final = y/x;
                return final;
            }

            else 

        throw new FormatException();
        }
    }
}