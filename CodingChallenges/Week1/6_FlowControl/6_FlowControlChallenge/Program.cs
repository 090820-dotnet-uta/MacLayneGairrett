using System;

namespace _6_FlowControl
{
    public class Program
    {
        //create global variables to hold users login data.
        public static string username;
        public static string password;

        static void Main(string[] args)
        {
        }

        // This method gets a valid temperaturebetween -40 asnd 135 inclusive 
        // and returns the valid int.
        public static int GetValidTemperature()
        {
            int temp_int;

            //This loop will make sure the user inputs an int between -40 & 130
            while(true){
                Console.WriteLine("Please enter an integer for Farenheit temperature between -40 and 130");
                string user_temp = System.Console.ReadLine();
                bool intResultTryParse = int.TryParse(user_temp, out temp_int);

                if(intResultTryParse && (temp_int > -40 && temp_int < 130))
                break;

                System.Console.WriteLine("\n\tEntry is not valid! Try entering an integer.");
            }
            return temp_int;
        }

        // This method has one int parameter
        // It gives outdoor activity advice and temperature opinion based on 20 degree
        // increments starting at -20 and ending at 135 
        // n < -20 = hella cold
        // -20 <= n < 0 = pretty cold
        //  0 <= n < 20 = cold
        // 20 <= n < 40 = thawed out
        // 40 <= n < 60 = feels like Autumn
        // 60 <= n < 80 = perfect outdoor workout temperature
        // 80 <= n < 90 = niiice
        // 90 <= n < 100 = hella hot
        // 100 <= n < 135 = hottest
        public static void GiveActivityAdvice(int temp)
        {
            switch(temp){
                case int n when (n < -20):
                System.Console.WriteLine("It's hella cold, don't go outside!");
                break;
                case int n when (n < 0):
                System.Console.WriteLine("It's pretty cold outside, wear as much clothes as possible.");
                break;
                case int n when (n < 20):
                System.Console.WriteLine("It's cold outside, wear a winter coat.");
                break;
                case int n when (n < 40):
                System.Console.WriteLine("It's thawed out finally, wear a hoodie and some jeans.");
                break;
                case int n when (n < 60):
                System.Console.WriteLine("It feels like Autumn, wear a t-shirt and some jeans.");
                break;
                case int n when (n < 80):
                System.Console.WriteLine("It's perfect outdoor workout temperature, wear shorts and t-shirt.");
                break;
                case int n when (n < 90):
                System.Console.WriteLine("It's niiice outside, wear a tank top, and sun glasses!");
                break;
                case int n when (n < 100):
                System.Console.WriteLine("It's hella hot outside, go swimming!");
                break;
                case int n when (n < 130):
                System.Console.WriteLine("It's the hottest outside, DO NOT GO OUTSIDE!");
                break;
            }
        }

        // This method gets a username and password from the user
        // and stores that data in the global variables of the 
        // names in the method.
        public static void Register()
        {
            System.Console.WriteLine("Please pick your username.");
            username = System.Console.ReadLine();
            System.Console.WriteLine("Please pick your password.");
            password = System.Console.ReadLine();
            System.Console.WriteLine("saved");

        }

        // This method gets username and password from the user and
        // compares them with the username and password global variables
        // or the names provided. If the password and username match,
        // the method returns true. If they do not match, the user is 
        // prompted again for the username and password.
        public static bool Login()
        {
            System.Console.WriteLine("Please enter your username.");
            string user = System.Console.ReadLine();
            System.Console.WriteLine("Please enter your password.");
            string pword = System.Console.ReadLine();

            if(user.Equals(username) && pword.Equals(password)){
                System.Console.WriteLine($"Welcome {user}");
                return true;
            }
            else return false; 
        }
        // This method as one int parameter.
        // It chack is the int is <=42, between 
        // 43 and 78 inclusive, or > 78.
        // For each temperature range, a different 
        // advice is given. 
        public static void GetTemperatureTernary(int temp)
        {
            temp = GetValidTemperature();
            string too_cold = $"{temp} is too cold!";
            string ok = $"{temp} is an ok temperature.";
            string too_hot = $"{temp} is too hot!";
            string answer;
            answer = (temp <= 42 ? too_cold : (temp <= 78 ? ok : too_hot));
            System.Console.WriteLine(answer);
        }
    }//end of Program()
}