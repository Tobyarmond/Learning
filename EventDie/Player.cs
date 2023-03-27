using System;

namespace EventDie
{
    public class Player
    {
        // Here is an event (which is actually a type of delegate) you need to create an instance of this delegate
        // Because the type of delegate used is Action (prefab delegate that does not return a value, the other is Func)
        // we do not have to define another one. However action could be a delegate style of our choosing.
        public event Action PlayerDied;
        
        // this should in theory contain a reference to the Achievements that "this" Player owns
        public Achievements PlayerAchievements;

        private string _name;
        private int _health;
       
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    Die();
                }
                if (_health > 100)
                {
                    _health = 100;
                }
            }
        }

        public string Name => _name;

        public Player(string name, int health)
        {
            
            _health = health;
            _name = name;
            // 
            PlayerAchievements = new Achievements(this);
        }
        
        // dying calls the Onplayerdeath method which should activate the event
        public void Die()
        {
            // make event for dying
            OnPlayerDied();
        }
        
        // Calls the die delegate must be raised from within the class that has the event and it's very important to
        // check that the delegate is not null before starting it otherwise you get a NullReferenceException.
        public void OnPlayerDied()
        {
            if (PlayerDied != null)
            {
                PlayerDied();
            }
        }
    }
}