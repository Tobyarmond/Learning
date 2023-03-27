using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace UserInput
{
    // Conatins methods related to the gathering of data from the user via Console
    public static class Input
    {
        // NOTE: No console input methods clear the console.
        
        /// <summary>
        /// Returns a string from user input via Console
        /// </summary>
        /// <param name="message">Small message no need for Y/N e.g."Please enter your name: </param>
        /// <returns></returns>
        public static string ConsoleString(string message) //message is like "Player 1 enter name: "
        {
            string response = "";
            string yn = "";
            while (yn != "Y")
            {
                Console.WriteLine(message);
                response = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine($"You have entered {response} Is this correct? Y/N");
                    yn = Console.ReadLine()?.ToUpper();
                    if (yn == "N" || yn == "Y")
                    {
                        break;   
                    }                    
                    else
                    {
                        Console.WriteLine("Please enter either 'Y' or 'N'");
                    }
                }
            }
            return response;
        }
        
        public static string ConsoleString(string message, string[] possibleAnswers) //TODO This needs making properly. Array not implemented
        {
            string response = "";
            string yn = "";
            while (yn != "Y")
            {
                Console.WriteLine(message);
                response = Convert.ToString(Console.Read());
                Console.WriteLine($"You have entered {response} \n Is this correct? Y/N");
                yn = Convert.ToString(Console.Read()).ToUpper();
                if (yn != "N" || yn != "Y")
                {
                    Console.WriteLine("Please enter either 'Y' or 'N'");
                }
            }
            return response;
        }
        
        /// <summary>
        /// Returns an int from user input via Console
        /// </summary>
        /// <param name="message">Small message no need for Y/N e.g."Please Enter a Number </param>
        /// <param name="max">Max int value</param>
        /// <param name="min">Min int value</param>
        /// <returns>Int32</returns>
        public static int ConsoleInt(string message, int max, int min)
        {
            {
                string yn = "";
                int? answer = null;
                while (yn != "Y")
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine(message);
                            answer = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a number");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine(
                                $"Please enter a number smaller than {int.MaxValue} and larger than {int.MinValue}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                        if (answer != null)
                        {
                            if (answer < max && answer > min)
                            {
                                break;
                            }
                            Console.WriteLine($"Please enter a number smaller than {max} and larger than {min}");
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine($"You entered:{answer} is this correct? Y/N");
                        yn = Console.ReadLine();
                        yn = yn?.ToUpper();
                        if (yn == "Y" || yn == "N")
                        {
                            break;
                        }
                        Console.WriteLine("Please enter Y or N");                                      
                    }                                       
                }                                           
                return (int)answer; // This warning in my opinion is not a problem, but we'll see
            }
        }
        
        /// <summary>
        /// Returns an int from user input via Console
        /// </summary>
        /// <param name="message">Small message no need for Y/N e.g."Please Enter a Number "</param>
        /// <returns>Int32</returns>
        public static int ConsoleInt(string message)
        {
            {
                string yn = "";
                int? answer = null;
                while (yn != "Y")
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine(message);
                            answer = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a number");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine(
                                $"Please enter a number smaller than {int.MaxValue} and larger than {int.MinValue}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                        if (answer != null)
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine($"You entered:{answer} is this correct? Y/N");
                        yn = Console.ReadLine();
                        yn = yn?.ToUpper();
                        if (yn == "Y" || yn == "N")
                        {
                            break;
                        }
                        Console.WriteLine("Please enter Y or N");                                      
                    }                                       
                }                                           
                return (int)answer; // This warning in my opinion is not a problem, but we'll see
            }
        }
        
        /// <summary>
        /// Returns a bool from user input via console.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Bool</returns>
        public static bool ConsoleBool(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                Console.Write(" Y/N?");
                string answer = Console.ReadLine()?.ToUpper();
                if (answer == "Y")
                {
                    return true;
                }
                if (answer == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter either Y or N");
                }
            }
        }

        /// <summary>
        /// Returns the corresponding int (key) associated with the chosen string within the dictionary. Allows for a
        /// limited number of options to be provided and selected
        /// </summary>
        /// <param name="options">A Dictionary of options. The Key(int) will be used next to the Value (string)</param>
        /// <returns>Key(int) of selected Value</returns>
        public static int ConsoleRadio(Dictionary<int,string> options)
        {
            while (true)
            {
                int max = 0;
                int min = 0;
                Console.WriteLine("Please choose from one of the following options by number.");
                foreach (KeyValuePair<int,string> line in options)
                {
                    Console.WriteLine($"{line.Key}: {line.Value}");
                    // Consider replacing this with LINQ
                    if (line.Key > max)
                    {
                        max = line.Key;
                    }
                    if (line.Key < min)
                    {
                        min = line.Key;
                    }
                }
                int choice = ConsoleInt("",max + 1,min); 
                return choice;
            }
        }
    }
}