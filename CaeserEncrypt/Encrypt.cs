using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CaeserEncrypt
{
    public static class Encrypt
    {
        public static string OriginalInput;
        public static ArrayList OriginalChars = new ArrayList();
        internal static ArrayList CharValues = new ArrayList();
        internal static ArrayList ModifiedCharValues = new ArrayList();
        internal static int Modifier;
        
        public static void Convert(ArrayList list)
        {
            foreach (char c in list)
            {
                if (c < 'A' || c > 'Z')
                {
                    CharValues?.Add(c);
                }
                else
                {
                    try
                    {
                        CharValues?.Add((int)c);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        break;
                    }
                }
            }
        }

        public static void GetInput()
        {
            Console.WriteLine("Please enter the phrase to encrypt: ");
            OriginalInput = Console.ReadLine();
            OriginalInput = OriginalInput?.ToUpper();
            while (Modifier <= 0 || Modifier == 26) 
            {
                try
                {
                    Console.WriteLine("Please enter the encryption number");
                    Modifier = System.Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Please enter a smaller number");
                }
                catch (Exception e) // Catch all
                {
                    Console.WriteLine(e);
                    throw;
                }
                if (Modifier <= 0)
                {
                    Console.WriteLine("Please enter a number above 0");
                }
                if (Modifier == 26)
                {
                     Console.WriteLine("Entering 26 will have the same effect as 0, Please choose another number");   
                }
            }
            Split();
            Convert(OriginalChars);
            ShiftChars(Modifier);
        }
        
        private static void Split()
        {
            foreach (char c in OriginalInput)
            {
                OriginalChars?.Add(c);
            }
        }

        private static void ShiftChars(int modifier)
        {
            foreach (var v in CharValues)
            {
                if (v is int)
                {
                    ModifiedCharValues.Add(NewChar((int) v, modifier));
                }
                else
                {
                    ModifiedCharValues.Add(v);
                }
            }
        }

        // Takes char int value and adds the modifier to it rolling around for characters above Z
        private static char NewChar(int i, int mod)
        {
            if (i + mod > 90)
            {
                return System.Convert.ToChar(i + mod - 26);   
            }
            if (i < 65)
            {
                return System.Convert.ToChar(65);
            }
            return System.Convert.ToChar(i + mod);
        }
    }
}