using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Threads
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Dealing with induvidual threads as shown here is possible and maybe even preferrable if you only have a
            // couple of threads that you can run, however most of the time you are more likely to use the Asynchronous
            // programming features available in C# For more look at players guide pg 251.
            
            // Threads allow multiple independant pieces of code to be ran seperately and asynchronously.
            // Threads help use all of the computing power available.
            Thread thread = new Thread(CountTo100);
            Thread thread2 = new Thread(CountTo100);
            Thread thread3 = new Thread(Divide);
            
            // As you can see from this example below, you cannot know when the different threads will become live in
            // whats known as a context switch (threads being started at different times.)
            thread.Start();
            thread2.Start();
            thread.Join();
            thread2.Join();
            
            DivideProblem threadProb = new DivideProblem{Dividend = 8,Divisor = 2};
            thread3.Start(threadProb);
            thread3.Join();
            Console.WriteLine("Answer is:" + threadProb.Quotient);
            
            // This method conforms to the Thread Start delegate type, therefore it can be handed to a thread and that
            // thread can run it using the no return parameterless delegate type
            void CountTo100()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i + 1);
                }
            }
            // However you can also have a different type of method, like before it has no return value but unlike before
            // you can call it with a single parameter which is of the object type, which is basically the parent type of
            // everything.

            // What this means though is we have to write the method for an object object, then cast it to the type we
            // wish to actually use.
            
            // To get around the fact that we cannot return a value here we use an object which has a variable (property)
            // available for the answer to be placed in.
            void Divide(object problem)
            {
                DivideProblem divProblem = (DivideProblem) problem;
                divProblem.Quotient = divProblem.Dividend / divProblem.Divisor;
            }
        }
    }
}