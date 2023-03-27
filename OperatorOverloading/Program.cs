using System;

namespace OperatorOverloading
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Vector V1 = new Vector(1,2);
            Vector V2 = new Vector(3,2);
            Vector V3 = V1 + V2;
            Console.WriteLine($"Vector 3 = {V3.X},{V3.Y}");
            V1.X = 3;
            if (V1 == V2)
            {
                Console.WriteLine("V1 and V2 are the same");
            }
            else
            {
                Console.WriteLine("V1 and V2 are different");
            }
            
            // Indexers

            V1[1] = 1;
            V2["y"] = 3;
        }
    }
}