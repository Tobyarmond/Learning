using System.Runtime.InteropServices;

namespace ConnectFour
{
    public class Coordinate
    {
        public int Col;
        public int Row;

        public Coordinate(int col, int row)
        {
            Col = col;
            Row = row;
        }
    }
}