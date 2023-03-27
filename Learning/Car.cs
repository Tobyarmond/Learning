/*
 * Class Example 
 */

using System;

namespace Learning
{
    public class Car
    {
        // Apparently it's good form to place a _ before private variables.
        private string _colour;

        public Car()
        {
            Console.WriteLine("Constructor with no parameters called!");
        }

        public Car(string colour) : this()
        {
            this._colour = colour;
            Console.WriteLine("Constructor with Colour parameter called");
        }

        public string Describe()
        {
            return "This car is " + _colour;
        }
        
        public string Colour // This is known as a property and sets the variables that can be extracted/manipulated by the outside
     
        {
            get => _colour.ToUpper();
            set
            {
                if (value == "RED")
                    
                {
                    _colour = value;
                }

                else
                {
                    // This will not be reached if you instantiate an object with a colour
                    // It will be ran if you edit the new object like eg. CarObjectName.colour = magenta
                    Console.WriteLine("You must choose Red");
                }
            }
       }
        // This is a destructor that is used to clean away the resources used by instances of this class.
        ~Car()
        {
            Console.WriteLine(this + " Cleaned up");
        } 
    }
}