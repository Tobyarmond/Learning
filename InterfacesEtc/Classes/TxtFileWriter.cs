using System.Linq.Expressions;

namespace InterfacesEtc.Classes
{
    // Interface is declared outside of class
    // Interfaces as far as I can tell are used for making blueprints for how you want a group of methods to work.
    // i forsee that when working with others providing interfaces is helpful
    

    // Class inherits interface

    // Unlike classes you are not limited to inheritng from only one interface, futhermore you can inherit from multiple interfaces
    // and from a (single) base class 
    public class TxtFileWriter : IFileWriter
    {
        public string Extension => ".txt";

        public void Write(string filename)
        {
            // do some file writing
        }


        /* This doesn't work for some reason
         
         But what it is supposed to show is that you can make a list with all things that conform to the Interface.
         You can put these all in the same list and then loop through them or something.
         
        // Interfaces can in many ways also be used like base classes.
        // For example here we can make a list of FileWriters 
        public IFileWriter[] FileWriters = new IFileWriter[3];
        FileWriters[0] = newTxtFileWriter();
        */
        
        // Using a params tells the compiler thst any number of items passed to a function is allowed. Behind the scenes
        // this is turned into an array of the arguments.
        
        // You can alos pass an array to the method instead without it being senselesssly put into another array.
    }
}