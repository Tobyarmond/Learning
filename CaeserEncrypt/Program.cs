using System;
using System.ComponentModel;

namespace CaeserEncrypt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char bob = 'a';
            Encrypt.GetInput();
            Console.WriteLine("The list currently contains:");
            foreach (var VARIABLE in Encrypt.ModifiedCharValues)   
            {
                Console.Write(VARIABLE);
            }
        }
    }
}