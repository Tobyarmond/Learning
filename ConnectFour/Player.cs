using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UserInput;

namespace ConnectFour
{
    public class Player
    {
        public string Name;
        public static Player[] Players = new Player[2]; // Could possibly create a read only value (const) to set this.
        public Board.Pieces PieceStyle;
        public ArrayList PieceCoords = new ArrayList(); // FIXME Get rid of this if it's not needed.
       
        [Flags]
        public enum Checks
        {
            CheckLeft = 1 << 0,
            CheckRight = 1 << 1,
            CheckUp = 1 << 2,
            CheckDown = 1 << 3,
            CheckDownLeft = 1 << 4,
            CheckDownRight = 1 << 5,
            CheckUpLeft = 1 << 6,
            CheckUpRight = 1 << 7,
                           
           None = 0
        }
        
        private Player(string name, int player)
        {
            Name = name;
            if (player == 1)
            {
                PieceStyle = Board.Pieces.O;
            }
            if (player == 2)
            {
                PieceStyle = Board.Pieces.X;
            }
        }

        public static void CreatePlayers()
        {
            for (int i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player(Input.ConsoleString($"Player {i + 1} what is your name?"), i + 1);
            }
        }

        public bool Turn() // returns true if game should still run
        {
            int response;
            while (true)
            {
                response = Input.ConsoleInt($"{Name} Which Column would you like to play?", 8, 0) - 1;
                if (Board.CanPlay(response))
                {
                    break;
                }
                Console.WriteLine("That column is full please choose another");
            }
            if (CheckWin(Play(response)))
            {
                return false;
            }
            return true;
        }

        public Coordinate Play(int col)
        {
            int Row = 0;
            int Col = 0;
            for (int row = 6; row > -1; row--)
            {
                if (Board.BoardLists[row, col] == Board.Pieces.I)
                {
                    Board.BoardLists[row, col] = PieceStyle;
                    Row = row;
                    Col = col;
                    Renderer.Render();
                    break;
                }
            }
            return new Coordinate(Col,Row);
        }

        public bool CheckWin(Coordinate coords)
        {
            Checks check = Checks.None ;
            if (CheckLeft(coords))
            {
                check |= Checks.CheckLeft;
            }
            if (CheckRight(coords))
            {
                check |= Checks.CheckRight;
            }
            if (CheckUp(coords))
            {
                check |= Checks.CheckUp;
            }
            if (CheckDown(coords))
            {
                check |= Checks.CheckDown;
            }
            if (CheckDownLeft(coords))
            {
                check |= Checks.CheckDownLeft;
            }
            if (CheckDownRight(coords))
            {
                check |= Checks.CheckDownRight;
            }
            if (CheckUpLeft(coords))
            {
                check |= Checks.CheckUpLeft;
            }
            if (CheckUpRight(coords))
            {
                check |= Checks.CheckUpRight;
            }
            if (check != Checks.None)
            {
                return true;
            }
            return false;
        }

        public bool CheckLeft(Coordinate coords) //delete row increment
        {
            try
            {
                if (Board.BoardLists[coords.Row, coords.Col] == PieceStyle)
                {
                    if (Board.BoardLists[coords.Row, coords.Col - 1] == PieceStyle)
                    {
                        if (Board.BoardLists[coords.Row, coords.Col - 2] == PieceStyle)
                        {
                            if (Board.BoardLists[coords.Row, coords.Col - 3] == PieceStyle)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }

        public bool CheckRight(Coordinate coords)
        {
            try
            {
                if (Board.BoardLists[coords.Row, coords.Col] == PieceStyle)
                {
                    if (Board.BoardLists[coords.Row, coords.Col + 1] == PieceStyle)
                    {
                        if (Board.BoardLists[coords.Row, coords.Col + 2] == PieceStyle)
                        {
                            if (Board.BoardLists[coords.Row, coords.Col + 3] == PieceStyle)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }

        public bool CheckDown(Coordinate coords)
        {
            try
            {
                if (Board.BoardLists[coords.Row, coords.Col] == PieceStyle)
                {
                    if (Board.BoardLists[coords.Row + 1, coords.Col] == PieceStyle)
                    {
                        if (Board.BoardLists[coords.Row + 2, coords.Col] == PieceStyle)
                        {
                            if (Board.BoardLists[coords.Row + 3, coords.Col] == PieceStyle)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }

        public bool CheckUp(Coordinate coords)
        {
            try
            {
                if (Board.BoardLists[coords.Row, coords.Col] == PieceStyle)
                {
                    if (Board.BoardLists[coords.Row - 1, coords.Col] == PieceStyle)
                    {
                        if (Board.BoardLists[coords.Row - 2, coords.Col] == PieceStyle)
                        {
                            if (Board.BoardLists[coords.Row - 3, coords.Col] == PieceStyle)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }

        public bool CheckDownLeft(Coordinate coords)
        {
            try
            {
                if (Board.BoardLists[coords.Row, coords.Col] == PieceStyle)
                {
                    if (Board.BoardLists[coords.Row + 1, coords.Col - 1] == PieceStyle)
                    {
                        if (Board.BoardLists[coords.Row + 2, coords.Col - 2] == PieceStyle)
                        {
                            if (Board.BoardLists[coords.Row + 3, coords.Col - 3] == PieceStyle)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }

        public bool CheckDownRight(Coordinate coords)
        {
            try
            {
                if (Board.BoardLists[coords.Row, coords.Col] == PieceStyle)
                {
                    if (Board.BoardLists[coords.Row + 1, coords.Col + 1] == PieceStyle)
                    {
                        if (Board.BoardLists[coords.Row + 2, coords.Col + 2] == PieceStyle)
                        {
                            if (Board.BoardLists[coords.Row + 3, coords.Col + 3] == PieceStyle)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }

        public bool CheckUpLeft(Coordinate coords)
        {
            try
            {
                if (Board.BoardLists[coords.Row, coords.Col] == PieceStyle)
                {
                    if (Board.BoardLists[coords.Row - 1, coords.Col - 1] == PieceStyle)
                    {
                        if (Board.BoardLists[coords.Row - 2, coords.Col - 2] == PieceStyle)
                        {
                            if (Board.BoardLists[coords.Row - 3, coords.Col - 3] == PieceStyle)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }

        public bool CheckUpRight(Coordinate coords)
        {
            try
            {
                if (Board.BoardLists[coords.Row, coords.Col] == PieceStyle)
                {
                    if (Board.BoardLists[coords.Row - 1, coords.Col + 1] == PieceStyle)
                    {
                        if (Board.BoardLists[coords.Row - 2, coords.Col + 2] == PieceStyle)
                        {
                            if (Board.BoardLists[coords.Row - 3, coords.Col + 3] == PieceStyle)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return false;
        }
    }
}