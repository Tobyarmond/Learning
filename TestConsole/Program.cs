using System;
using System.Collections.Generic;
using UserInput; // Custom Library for asking user questons through console.

namespace TestConsole
{
    internal class Program
    {
        // Space for testing libraries
        public static void Main(string[] args)
        {
            
            int test = Input.ConsoleInt("Please enter a number:");
            Console.WriteLine(test);
            string strtest = Input.ConsoleString("What is your name?");
            Console.WriteLine($"Hello {strtest} pleased to meet you");
            Dictionary<int,string> dictest = new Dictionary<int, string>();
            dictest.Add(1, "Kill yourself");
            dictest.Add(2, "Drink Bleach");
            dictest.Add(3, "Whatever");
            string chosen = dictest[Input.ConsoleRadio(dictest)];
            Console.WriteLine(chosen);




        }
    }
}