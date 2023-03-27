using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Learning
{   
    internal class Program
    {
        public static void
            Main(string[] args) // This line is the main entry point to the program and can only be in one file
        {
            Automobile train = new Automobile("Green");
            train.Height = 2.3;
            Bus doubledecker = new Bus();
            doubledecker.Colour = "Red";
            doubledecker.Height = 4.6;
            Tunnel baldock = new Tunnel();
            baldock.Height = 4.0;
            Console.WriteLine(Will1Fitin2(train.Height, baldock.Height));
            Bridge forth = new Bridge();
            forth.Height = 14.5;
            Console.ReadLine();
        }

        static bool Will1Fitin2(double automobile, double infrastructure)
        {
            if (automobile < infrastructure)
            {
                return true;
            }
            return false;
        }

        //private static bytestuff.ForumPrivelages _privelages = bytestuff.ForumPrivelages.BasicUser;
        //_privelages |= bytestuff.ForumPrivelages.Suspended;

       // private bool is_suspended =
           // (_privelages & bytestuff.ForumPrivelages.Suspended) == bytestuff.ForumPrivelages.Suspended;
        
        
    }
}