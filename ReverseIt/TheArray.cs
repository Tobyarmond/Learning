using System;

namespace ReverseIt
{
    public static class TheArray
    {
        // Have to create an array that will be filled with the numbers 1-9 in a random order, the player can reverse the
        // order of a certain number of elements from left to right. 

        public static int[] Theints = new int[9]{0,0,0,0,0,0,0,0,0};
        public static bool Finished;
        private static int[] OneToNine = {1,2,3,4,5,6,7,8,9};

        internal static void Play()
        {
            Reverse(AskAmount());
            Finished = CheckWin();
        }

        public static void FillList()
        {
            Random Rnd = new Random();
            int index;
            foreach (int number in OneToNine)
            {
                index = Rnd.Next(Theints.Length); 
                while (Theints[index] != 0) // not sure if this will work
                {
                    index = Rnd.Next(Theints.Length); // Keep generating new numbers until you come across a 0
                }
                Theints[index] = number;
            }    
        }

        public static void Reverse(int amount)
        {
            int[] NumsToReverse = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                NumsToReverse[i] = Theints[i];
            }
            Array.Reverse(NumsToReverse);
            for (int i = 0; i < amount; i++)
            {
                Theints[i] = NumsToReverse[i];
            }
        }

        public static int AskAmount()
        {
            int answer = 0;
            while (answer < 1 || answer > 9 )
            {
                try
                {
                    Console.WriteLine("The current order is:");
                    foreach (int i in Theints)
                    {
                        Console.Write(i+" ");
                    }
                    Console.WriteLine("Please enter a number between 1 and 9:");
                    answer = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Please enter a number lower than the maximum: " + Int32.MaxValue + "Or the minimum: " + Int32.MinValue );
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                if (answer > 9 || answer < 1)
                {
                     Console.WriteLine("Please enter a number between 1 and 9");   
                }
            }
            return answer;
        }
        
        public static bool CheckWin()
        {
            if (Theints[0] + Theints[8] == 10)
            {
                if (Theints[1] + Theints[7] == 10)
                {
                    if (Theints[2] + Theints[6] == 10)
                    {
                        if (Theints[3] + Theints[5] == 10)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        
    }
}