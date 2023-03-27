using System;
using System.Runtime.InteropServices.ComTypes;

namespace Learning
{
    public class Automobile
    {
        // Setup the variables you want to use
        private string _colour; 
        private double _height;
        
        // Basic constructor to create the object no matter what
        public Automobile()
        {}
        
        // Doubling up like this is fine
        // Constructor for one parameter
        public Automobile(string colour)
        {
            _colour = colour;
        }

        public string Colour
        {
            get => _colour;
            set => _colour = value;
        }

        public double Height
        {
            get => _height;
            set => _height = value;
        }
    }
    // The : means that Bus inherits from Automobile which means that it automatically has the same properties as Automobile
    // It doesn't have the 
    public class Bus : Automobile
    {
             
    }
}

