using System;
using System.Threading;

namespace GameOfLife
{
    public class Renderer
    {   
        public static void Render()
        {
            Console.Clear();
            // FIXME: This list seems to be empty during testing. Why?
            foreach (bool[] line in Board.MainBoardList)
            {
                foreach (bool living in line)
                {
                    if (living)
                    {
                        Console.Write(" X");
                    }
                    else
                    {
                        Console.Write(" .");
                    }
                }
                Console.WriteLine();
            }
            //Thread.Sleep(1000);
        }
    }
}