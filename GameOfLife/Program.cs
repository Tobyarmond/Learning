using System;
using GameOfLife.Properties;

namespace GameOfLife
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Board.ReadBoard(Board.path + Board.FindGofs());
            while (true)
            {
                Renderer.Render();
                Game.Generation();
            }
        }
    }
}