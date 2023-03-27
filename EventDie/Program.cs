
using System;

namespace EventDie
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Player player1 = new Player("Bob",100);
            player1.Health = -2;
            Console.WriteLine($"You have died {player1.PlayerAchievements.Deaths} Times \nYou Have {player1.Health} Health");
        }
    }
}