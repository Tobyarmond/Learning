using System;

namespace ConnectFour
{
    internal class Program
    {
        
        // TODO: This game has no draw condition.
       
        public static void Main(string[] args)
        {
            Player.CreatePlayers();
            Renderer.Render();
            bool Continue = true;
            
            string message = "";
            while (Continue)
            {
                foreach (Player p in Player.Players)
                {
                    if (Continue == false)
                    {
                        break;
                    }
                    if (p.Turn() == false)
                    {
                        Continue = false;
                        message = $"{p.Name} You Have Won!";
                        break;
                    }
                    int count = 0;
                    for (int row = 0; row < Board.BoardLists.GetLength(1); row++)
                    {
                        if (Board.BoardLists[0, row] == Board.Pieces.I)
                        {
                            break;
                        }
                        count += 1;
                        if (count == 7)
                        {
                            message = "You have Drawn this game!";
                            Continue = false;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(message + "\n Press enter to leave game");
            Console.ReadLine();
        }
    }
}