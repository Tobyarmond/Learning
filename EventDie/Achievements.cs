using System;

namespace EventDie
{
    public class Achievements
    {
        // This Player might not really be needed from the Achievements side.
        // A better plan might be to 
        public Player Player;
        public int Deaths;
        
        public Achievements(Player player)
        {
            Player = player;
            // when the achievement is instantiated it is automatically subscribed to the 
            Player.PlayerDied += OnPlayerDied;
        }

        void OnPlayerDied()
        {
             Deaths += 1;
             Console.WriteLine(Deaths);
        }
    }
}