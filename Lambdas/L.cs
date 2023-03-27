using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Lambdas
{
    public class L
    {
        // Lambda expressions cannot be used on there own within a method body, instead they are used in place of anonymous
        // functions. Lambdas do not have a return value and instead the left side of the lambda is what is returned.
        // most of the time you do not need to tell the compilier explicitly what type you are returning and it is inferred
        // however if the return type is ambiguous you can declare what type it will be like this (int value) => value*value
        internal static int[] numbers = {1, 2, 4, 2, 7, 4, 8, 4, 45, 6, 3};
        // Where is from the System.Linq library
        // You must use the IEnumerable interface when putting the result of a lambda. ??check validaity of this statement
        internal static IEnumerable<int> evens = numbers.Where(x => x % 2 == 0);
        internal static IEnumerable<int> byfour = evens.Where(x => x % 4 == 0);

        // While this is valid lambda syntax (with two parameters) it is not possible for you to just use it somewhere
        // instead it takes the place of an nanonymous function which you would use for small problems that you don't want
        // to declare a new method to solve.
        //(x,y) => x*x + y*y;
        // You can also Lambdas with no parameters
        public static void SayBlah() => Console.WriteLine("blah blah");

        // You can also replace these sort of methods with...
        public int ComputeSquare1(int value)
        {
            return value * value;
        }
        
        // This instead.
        // So what this is saying is Value goes to value*value
        public int ComputeSquare2(int value) => value * value;
        
        // All these examples so far are putting the lambda expression within methods, one important thing to remember
        // about lambdas is that they also have access to variables that are available from where the method is declared.
        // using normal methods would require us to pass these variables as a parameter to the method.
        
        
    }
}