namespace Lambdas
{
    public class GameObject
    {
        // Queries are declaritive programming where you tell the computer what you want not how to get it.
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
        public int PlayerID { get; set; }
   
    }
    public class Ship : GameObject
    {
        
    }
}