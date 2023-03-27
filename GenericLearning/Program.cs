using System;
using System.Net.Sockets;

namespace GenericLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
    }

    // The <T> after the class name indicates that this class will (or can) use generic types.
    // What this means in practice is that you can make a class that doesn't know or care what the object type is.
    
    public class GenericTests<T>
    {
        private T[] items;

        public GenericTests()
        {
            items = new T[0];
        }

        public T GetItem(int index)
        {
            return items[index];
        }

        public void AddItems(T item)
        {
            // make a new array 1 larger than the original
            T[] newItems = new T[items.Length+1];
            // Copy all of the old items from the old list
            for (int index = 0; index < items.Length; index++)
            {
                newItems[index] = items[index];
            }
            // Add the new item to the end of the old list
            newItems[newItems.Length - 1] = item;
            // replace the original list with the new one.
            items = newItems;
        }
    }

    // You can be more restrictive of which types are allowed to be used within the generic class.
    // here the class is limited to types which conform to the Icomparable interface. This means that only objects that
    // confrom to this interface will be able to be used with this class.
    
    class NotSoGenericTest<T> where T : IComparable
    {
        // Add some I comparable compatible code within here. 
    }
    
    /*
    // You can also have multiple generic tyes within one definition like so
    class DictionaryGeneric<K, V> 
        where K : SomeBaseClass
        where V : SomeOtherInterface
    {
        // add stuff here which uses the K and V generics
    }
    */
    /*
    class NeedConstructor<T> where T : new()
    {
        // in this example the generic T would need to have a blank constructor i.e one that does not accept parameters.
    }
    */
    // You can also specify that the type is either reference or value
    
    /*
    class ValueGeneric<T> where T : struct
    {
        // This would only allow value types (i.e structs)
    }
    */

    /*
    class ReferenceGeneric<T> where T : class
    {
        // This would only allow reference types (i.e Classes)
    }
    */

    /*
    class MustBeDerivedFrom<T> where T : SomeBaseClass
    {
        // This would only allow types which are derived from the specified Base Class.
    }
    */
    
    //
    // We Can also make Generic methods too.
    //
    
    /*
    public T LoadObject<T>(string filename)
    {
        // Do Stuff
    }
    */
     
    /*
     // Which can also restrict the types that it can work with as shown earlier
     public T convert<T,V>(T item) where T:class
    {
        // Do stuff
    }
    */
    
    // It is important with these generic types to be able to return the default value of an item when you do not know 
    // what type it might be. For example if you set an int to intexample = null;
    // You cant set a value type to null so as a consequence it will throw an exception which could crash the whole thing
    
    // Returning the default value of any type.
    // for a type which is known setting default can be done like:
    // 
    // public int intTest = default(int);
    
    // Doing this for generic types looks like this
    
    // T answer = default(T);
    
    // However this is not as useful as it sounds as there is no way of changing these default values and if you didn't
    // know enough about the type to set the default yourself, you don't know what the default value is now that is set.
    // A much better way of working is to be discriminatory enough with which types you allow the generic to handle that
    // this uncertainty is not a problem.
    
    
}