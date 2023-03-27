namespace Lambdas
{
    public class Player
    {
        public enum Colours
        {
            Red,
            Blue,
            Green,
            Yellow
        }
        
        public int PlayerID {get; set; }
        public string Username { get; set; }
        public Colours TeamColour { get; set; }
    }

    
    
}