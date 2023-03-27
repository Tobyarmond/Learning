using System;
using System.Collections.Specialized;
using System.Security;

namespace OperatorOverloading
{
    public class Vector
    {
        internal double X { get; set; }
        internal double Y { get; set; }

        internal Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        // This allows us to change the way that operators work with certain types. In this instance it is the + operator
        // All operator overloads require the overload to be both static and public. The two arguments provided represent
        // each side of the operator
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        // You can also overload the with more than one definition, as you can see here this tells what to do when one side
        // of the + operator is a vector and the other is a plain old double.
        public static Vector operator +(Vector v1, double scalar)
        {
            return new Vector(v1.X + scalar, v1.Y + scalar);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }
        
        // You can also overload relational operators too, but you must do so in pairs i.e if you define == you must also
        // define !=, they also must return a bool

        public static bool operator ==(Vector v1, Vector v2)
        {
            return (v1.X == v2.X) && (v1.Y == v2.Y);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2); // return the opposite of the == operator
        }
        
        // The types that are allowed
        // + - * / % ++ -- == != >= <= > <. The compund assignment operators += etc. can be overloaded if the + is done
        // for example
        
        // The logical operators like || cannot be overloaded.
        
        
        /*
         * Indexer changes
         */
        
        // here we allow vectors to be accessed using 1 and 0 as indexes with 0 returning x and 1 returning y

        public double this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return X;
                }
                if (index == 1)
                {
                    return Y;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index == 0)
                {
                    X = value;
                }

                if (index == 1)
                {
                    Y = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        // we can also use strings chars etc. for indexers instead
        public double this[string index]
        {
            get
            {
                if (index.ToUpper() == "X")
                {
                    return X;
                }
                if (index.ToUpper() == "Y")
                {
                    return Y;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index.ToUpper() == "X")
                {
                    X = value;
                }
                if (index.ToUpper() == "Y")
                {
                    Y = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
}