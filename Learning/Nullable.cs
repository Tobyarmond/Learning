using System;
using System.Security.Cryptography;

namespace Learning
{
    public class Nullable
    {
        // You can make types nullable which normally will not allow for a null value, null values are usually only
        // available to reference types.
        
        // This is useful for giving bools three values so that we know if a condition is true, false or unset/unknown

        private Nullable<bool> nullablebool = true; // A true or false value can be set.
        private static Nullable<bool> nullablebooln = null; // but could also be null
        
        // C# has an even better way of doing this.
        private bool? nullableboolt = null;
        
        // to get the value from a nullable type you can use the .HasValue property to figure out if the variable has a
        // value. You can then use the .Value property to access the actual value

        private static bool? CheckNull(bool? Nbool)
        {
            if (Nbool.HasValue)
            {
                return Nbool.Value;
            }
            Console.WriteLine("Bool was Null");
            return null;
        } 
        
        // You can also use the null-coalescing operator (??) to assign a default value for a nullable type

        private static bool hasdefault = nullablebooln ?? false;
        // now if nullablebooln will be false if it is set to null.
        
        // making value types nullable does not actually change the way the value type works, all it does is add a
        // bool to the variable that if false the variable is considered null, if true the value is assumed to be the
        // normal value associated with that Type. Properties implementing the Nullable<T> if false (null) will throw
        // exceptions if used. Instead like proper null types you should check (!null) before using these variables.
        
        /*
         * Simple Null Checking 
         */
        
        // If we had a bunch of arrays and object references that all required checking it could get a bit extereme, and
        // any that we forget would throw a null reference exception which is a bit of a headache to deal with.
        // instead we can use a (conditional member access operator) ?. to be the equivalent of if (!null){} and we can
        // use the conditonal indexer access operator (?[]) 
        
        
        
        
    }
}