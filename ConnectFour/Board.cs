namespace ConnectFour
{
    public class Board
    {
        public static Pieces[,] BoardLists =
            // Empty 7x7 piece array
        {{0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0}};   
        public enum Pieces
        {
            I = 0, 
            X = 1,
            O = 2
        }
        
        public static bool CanPlay(int col)
        {
            if (BoardLists[0, col] == Pieces.I)
            {
                return true;
            }
            return false;
        }
        
        
    }
}