using System;

namespace fizzBuzz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string message = "";
            for (int i = 1; i < 100; i++)
            {
                message = "";
                if (i % 3 == 0)
                {
                    message += "Fizz";
                }
                if(i % 5 == 0)
                {
                    message += "Buzz";
                }
                if (message == "")
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}