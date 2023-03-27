using System;

namespace ReverseIt
{
    internal class Program
    {
        // Works 
        public static void Main(string[] args)
        {
            TheArray.FillList();
            while (TheArray.Finished != true)
            {
                TheArray.Play();
            }
            Console.WriteLine("You have Won!");
        }
    }
}