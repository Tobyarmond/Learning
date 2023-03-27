using System;

namespace Dynamic_Objects
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Dynamic objects allow you to add new objects, methods and properties at runtime, this also changes the
            // behaviour of the compiler for these objects. Instead of the compiler checking that the code is legal before
            // building the solution (static type checking, not to be confused with the static keyword)
            
            // With dynamic objects we can call methods etc. that do not exist and the compiler will not flag any errors
            // instead these will be flagged (if there is an error) at runtime.

            dynamic text = "hello world";
            text *= 1;
            text += Math.PI;
            //Console.WriteLine(text.cheeseMonster); Rider prevents this from compiling
            
            // If any of these fail (which they will) they will throw a RuntimeBinderException 
            
            


        }
    }
}