using System;
using UserInput;

namespace PigDice
{
    public class Player
    {
        #region Properties
        
        public string Name;
        public int Score;
        public static Player[] Players = new Player[2]; 
        public Dice[] PlayerDice = new Dice[2];
        private static int _noOfPlayers;
        
        #endregion

        #region Constructors
        // This constructor with no parameters asks for a name.
        internal Player()
        {
            while (true)
            {
                string name = Input.ConsoleString($"Player{_noOfPlayers} Please enter your name: ");
                Name = name + " :" + _noOfPlayers;
                Score = 0;
                Players[_noOfPlayers] = this;
                _noOfPlayers += 1;
                PlayerDice[0] = new Dice(Name+"1");
                PlayerDice[1] = new Dice(Name+"2");
                return;
            } 
        }
        
        private Player(string name)
        {
            Name = name;
        }
        #endregion

        #region Methods
        
        internal static void Game()
        {
            bool finished = false;
            while (finished != true)
            {
                foreach (Player p in Players)
                {
                    if (!p.Turn())
                    {
                        foreach (Player pl in Players)
                        {
                            if (p.Score > 100)
                            {
                                Console.WriteLine($"{pl.Name} You have won!");
                                finished = true;
                                
                            }
                            break;
                        }
                        
                    }
                }    
            }
            
        }
        /// <summary>
        /// Rolls both dice for the calling player ending if the Player rolls a 1 on either dice or when they fold.
        /// </summary>
        /// <returns>Bool Game is still running?</returns>
        internal bool Turn()
        {
            int turnScore = 0; // Total score accumulated for this turn
            while (true) // TODO change this condition.
            {
                int roll1 = PlayerDice[0].RollDice();
                int roll2 = PlayerDice[1].RollDice();
                Console.WriteLine($"{Name}: Your first Roll is: {roll1} Your second roll is: {roll2}");
                if (roll1 == 1 || roll2 == 1)
                {
                    Console.WriteLine("One of the rolls was 1, your turn is over \n");
                    return true;
                }
                turnScore += roll1 + roll2;
                if (Score + turnScore >= 100)
                {
                    Score += turnScore;
                    return false; // this would end the game.. might need to rework
                }

                if (!Input.ConsoleBool($"Your current score is {Score} and you have accumulated {turnScore} this turn. Would you like to roll again?"))
                {
                    Score += turnScore;
                    Console.WriteLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("Starting new roll \n");
                }
            }
        }
        
        /// <summary>
        /// Creates two players using the Player() constructor
        /// </summary>
        internal static void CreatePlayers()
        {
            while (_noOfPlayers != 2)
            {
                try
                {
                    new Player();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Index is out of bounds of the array");
                    Console.WriteLine("Index was at: " + _noOfPlayers);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        #endregion
    }
}