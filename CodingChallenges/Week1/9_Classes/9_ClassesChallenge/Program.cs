using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human h1 = new Human();
            Human h2 = new Human("Sam", "Murphy");
           
            Human h3 = new Human("Trevor", "Berk", "Green");
            Human h4 = new Human("James", "Lang", 22);
            Human h5 = new Human("Jaelyn", "Brown", "Brown", 21);

            h1.Weight = 150;
            h2.Weight = 200;
            h3.Weight = 175;
            h4.Weight = 185;
            h5.Weight = 135;

            h1.AboutMe();
            h2.AboutMe();
            h3.AboutMe();
            h4.AboutMe();
            h5.AboutMe();
        }
    }
}
