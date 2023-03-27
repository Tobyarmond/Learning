using System;
using System.Reflection.Metadata.Ecma335;

namespace EventsExceptions.Classes
{
    // From Players Guide.
    
    // Defining delegates is like defining a new type (Classes Structs) and therefore happens directly within the namespace
    // All delegates are part of the MulticastDelegate class which is derived from the Delegate Base class.
    public delegate int MathDelegate(int a, int b);
    // This delegate requires two int params and returns an int.
    // When declaring a delegate 
    
    public class Delegate2
    {
        // All of these methods satisfy the requirements of the MathDelegate Delegate and therefore can be added to it.
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Multi(int a, int b)
        {
            return a * b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }

        public static MathDelegate Mathoperation = Add;
        // Delegates can also be declared without assigning a value to them like below:
        // public MathDelegate Mathoperation;
        // Because a delegate variable can contain null it is worth checking for !null when using delegates.
        
        // The delegate can be called like a normal method call.
        // The only difference is that the delegate could contain any number of different methods depending on the situation
        int answer1 = Mathoperation(2, 3);
        // Behind the scenes the compiler converts to the follwing. This is also legal and might be preferential
        // To make it really obvious that you are invoking a delegates method.
        private int answer2 = Mathoperation.Invoke(2, 3);


    }
}