using System;
using System.Threading;

namespace PigDice
{
    public class Dice
    {
        public string Name;
        public int Roll => _roll;
        private int _roll;
        private static Random rnd = new Random();

        public Dice(string name)
        {
            Name = name;
            
        }
        
        public int RollDice()
        {
            //Thread.Sleep(100); // This is to ensure that the two dice have different numbers
            rnd.Next();
            _roll = rnd.Next(6) + 1;
            return Roll;
        }
    }
}