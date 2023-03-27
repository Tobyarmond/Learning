using System;
using System.IO;

namespace EventsExceptions.Classes
{

    public delegate void LogEventHandler(LogEvent logEvent);
    
    // This Class is called LogEvent only because the book had it called that, and is not associated with event learning
    public class LogEvent
    {
        public string Text { get; }

        public LogEvent(string text)
        {
            Text = text;
        }

        public static void LogToConsole(LogEvent logEvent)
        {
            Console.WriteLine(logEvent.Text);
        }

        public static void LogToFile(LogEvent logEvent)
        {
            File.AppendAllText("log.txt", logEvent.Text + "\n");
        }
    }
}