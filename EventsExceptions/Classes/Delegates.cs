using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace EventsExceptions.Classes
{
    
    // From Internet MSDN guide
    
    
    // Delegates are wrappers that contain methods with alike paramaters and return types. To declare the delegate
    // is shown below.
    public delegate void DelTest(int num);
    // This delegate requires a single int param, and  does not return anything.
    
    public class Delegates
    {
        // Once we have declared a method which conforms to the delegates requirements.
        public static void DelMethod(int num)
        {
            Console.WriteLine(num.ToString());
        }

        // To assign a method to a new instance of a delegate
        private DelTest Handler = DelMethod;
        // here a new instance of a delegate has been created   
        
        // You can now create a "callback" method that will use our new delegate.
        public void MethodCallback(int value1, int value2, DelTest del)
        {
            del(value1 + value2);
        }
        
        

        // You can also use multiple methods within a delegate.
        // Additional methods can be added using the following syntax where newmeth is an additional method.
        // Handler = Handler + newmeth
        // Handler += newmeth

        // Delegates can also be removed from the handler by using the opposite of the above syntax.
        // Handler = Handler - newmeth
        // Handler -= newmeth

        // using multiple delegates within a single callback is also possible. In this instance
    }
}