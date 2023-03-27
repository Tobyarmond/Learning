using System;
using System.Dynamic;

namespace EventsExceptions.Classes
{
    public class Exceptions
    {
        // When something goes wrong within the program an exception is thrown. If this exception is not handled within the
        // current frame it will be passed up the stack until it is handled or until it gets back all the way to main()

        // To catch an exception you have to be looking for it.
        // By using the try command we can attempt something and then deal with it if it fails

        // Consider the following example
        internal int MakeException()
        {
            int usernumber = 0;
            while (usernumber < 1 || usernumber > 10)
            {
                try
                {
                    Console.WriteLine("Please enter a number between 1 and 10:");
                    string userResponse = Console.ReadLine();
                    usernumber = Convert.ToInt32(userResponse);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number");

                }
                catch (OverflowException)
                {
                    // This exception will be thrown if the number entered is above Int32.MaxValue and possibly if
                    // the value is below Int32.MinValue
                    Console.WriteLine("Please enter a smaller number");
                }
                catch (Exception e)
                {
                    // This catch clause is the "catch all" version which will catch any Exception.. yes thats right
                    // "Exception" is just a class that is within the core of the C# library. All of the other exceptions
                    // are derived from Exception.

                    // This type of catch should go at the bottom of all of the catch clauses as it is the most general
                    // and will only be used if none of the other clauses apply.
                    Console.WriteLine(e);
                    throw;
                    // The throw keyword indicates that we are done catching exceptions and should instead "throw this up
                    // the stack to the next frame and see if it can handle.
                }
            }
            return usernumber;
        }

        internal void CauseTrouble() // Always up to no good
        {
            throw new Exception("Just kicking up a Fuss");
        }
        // Throwing the simple Exception variety is often not a good idea and instead it's a beter idea to a more specific
        // type of exception. you can type in Ex into Rider and it will give all of the possible exceptions that are pre-
        // made. However you can also make your own exceptions..
    }

    public class NotEnoughCheeseException : Exception
    {
        public int CheeseStored { get; set; }

        public NotEnoughCheeseException(int cheeseStored)
        {
            CheeseStored = cheeseStored;
        }
    }
    
    // Now with our new custom Exception we can throw a not enough cheese error

    public class Example
    {
        public void StoreCheese(int cheese)
        {
            throw new NotEnoughCheeseException(cheese);
        }
        
        public void PutCheeseIn()
        {
            try
            {
                StoreCheese(56);
            }
            catch (NotEnoughCheeseException e) when(e.CheeseStored < 100) // this when keyword is like an if for catch statements
            // it allows you to check for some conditions.
            
            // This when statement is useful for preventing "rethrowing" an exception
            // because you can rethrow the exact same exception rather than going inside the catch statemnt then using an
            // if statement to check if cheese is less than 100 then rethrowing we can just not catch it instead. This serves
            // two purposes. firstly it does what you actually want it to do, secondly "rethrowing" means the stacktrace
            // starts from the rethrown position rather than where the exception was initially created. Which makes debugging
            // more difficult.
            {
                Console.WriteLine($"{e.CheeseStored} Pieces of cheese, is not enough cheese");
                throw;
            }
            finally // finally statements do not require a catch statement and can be written as try{} finally{}.
            {
               Console.WriteLine("This code is always ran"); // This code always runs regardless of what happens in the
               // try catch block error, return statement, just plain old finishes it will still be run.
            }
            
            // Additional notes about throwing exceptions
            // program flow can easily get messed up by exceptions, so they are not to be used when not really required
            // at least if you are throwing an exception you must close any open resources or clean up any other unused 
            // stuff a finally block can be utilised for this purpose
            
            // Secondly you will also need to try and revert the program back to a state where it can continue.
            // the finally block can also be turned toward this purpose.
        }
    }
}