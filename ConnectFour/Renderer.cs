using System;

namespace ConnectFour
{
    public class Renderer
    {
        public static void Render()
        {
            Console.Clear();
            for (int colIndex = 0; colIndex != Board.BoardLists.GetLength(0) ; colIndex++)
            {
                Console.WriteLine();
                for (int rowIndex = 0 ; rowIndex != Board.BoardLists.GetLength(1); rowIndex++)
                {
                    string write = Board.BoardLists[colIndex, rowIndex].ToString();
                    if (write == "I")
                    {
                        write = ".";
                    }
                    if (write == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (write == "X")
                    {
                        write = "O";
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write($" {write}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("\n -------------");
            Console.WriteLine(" 1 2 3 4 5 6 7");
        }

        //private static string RenderPieces(Board.Pieces)
       // {
            
       // } 
    }
}
