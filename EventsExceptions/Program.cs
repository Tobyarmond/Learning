using System;
using System.Security.Cryptography.X509Certificates;
using EventsExceptions.Classes;

namespace EventsExceptions
{
    // The .NET Platform packages two types of generic delegate
    // This is the generic Action delegate. The action generic delegate is not allowed to contain any methods with return values
    // the T1.. etc. refers to a generic type. The Action delegate is able to accept up to 16 parameters given to it
    public delegate void Action<T1,T2,T3>(T1 arg1, T2 arg2, T3 arg3);
    
    // To create a generic delegate which does have a retun value use the Func generic instead
    // TResult is the Variable that will contain the returned value.
    public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);
    
    class Program
    {
        static void Main(string[] args)
        {
            LogEventHandler logHandlers = LogEvent.LogToFile;
            // Add a method to the delgate
            logHandlers += LogEvent.LogToConsole;
            // Because at this stage both methods are assigned to this delegate both are called
            logHandlers(new LogEvent("hello"));
            // Remove a method from the delegate
            logHandlers -= LogEvent.LogToFile;

            // The issue with multicast delegates is related to dealing with return values from the methods that it calls.
            // Only the last methods return value is returned all others are ignored. This makes them not very useful for
            // methods that have a return value.

            // The other issue is related to exceptions, if one of the methods conatined within the delegate throws an
            // exception, none of the other methods will be invoked. Therefore you should attempt to prevent any delegate
            // from throwing an exception.

            // Although you can define your own delegates whenever you wish in practice it is not required very often
            // as instead we can just use the generic Action and Func types - These are shown at the top of this file.
            
            
            // PointChanged EVENTS
            Point.PointChanged += Point.HandlePointChanged;
            Point example = new Point();
            example.OnPointChanged();
        }        
    }
}