using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GameOfLife.Properties
{
    public class Location 
    {
        #region Properties
        internal int Col;
        internal int Row;
        #endregion

        #region Constructors
        public Location(int col, int row)
        {
            Col = col;
            Row = row;
        }
        #endregion
        
/*
        public static bool operator ==(Location l1, Location l2)
        {
            return l2 != null && (l1 != null && (l1.Col == l2.Col && l1.Row == l2.Row));
        }
        
        public static bool operator !=(Location l1, Location l2)
        {
            return l2 != null && (l1 != null && !(l1.Col == l2.Col && l1.Row == l2.Row));
        }

        // I assume that I need to fix this to get the rest to work
        // Style guide says that this should have roughly the same capabilities as 
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Location)obj);
        }
*/
        // Overloading the equality operator is a lot harder than I thought it would be.
        
        // instead we can simply have a method that compares locations
        // WORKS
        
        #region Methods
        public bool SameLoc(Location loc)
        {
            if (Col == loc.Col && Row == loc.Row)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        // TODO: YOU WERE HERE - YOU NEED TO MAKE A SYSTEM TO ADD ALL NEIGHBOURS OF LIFE WHICH ARE NOT ALIVE TO A LIST THEN IF THERE ARE 3 THEN MAKE IT ALIVE NEXT GENERATION
        public static IEnumerable<Location> PossibleNewLife(Location[] CurrentlyAlive)
        {
            List<Location> potentialLife = new List<Location>();
            foreach (Location alive in CurrentlyAlive)
            {
                if (alive.Col != 0) // not full left
                {
                    if (Board.MainBoardList[alive.Row][alive.Col - 1] == false) //check left
                    {
                        potentialLife.Add(new Location(alive.Col - 1,alive.Row));
                    }
                    if (alive.Row != 0) // not full top
                    {
                        if (Board.MainBoardList[alive.Row - 1][alive.Col - 1] == false) //check topleft
                        {
                            potentialLife.Add(new Location(alive.Col - 1,alive.Row - 1));
                        }
                    }
                    if (alive.Row != Board.MainBoardList.Count - 1) // not full bottom
                    {
                        if (Board.MainBoardList[alive.Row + 1][alive.Col - 1] == false) //check bottomleft
                        {
                            potentialLife.Add(new Location(alive.Col - 1,alive.Row + 1));
                        }
                    }
                }
                if (alive.Col != Board.MainBoardList[alive.Row].Length - 1) //not full right
                {
                    if (Board.MainBoardList[alive.Row][alive.Col + 1] == false) //check right
                    {
                        potentialLife.Add(new Location(alive.Col+1,alive.Row));
                    }
                    if (alive.Row != 0) // not full top
                    {
                        if (Board.MainBoardList[alive.Row - 1][alive.Col + 1] == false) //check topright
                        {
                            potentialLife.Add(new Location(alive.Col + 1,alive.Row - 1));
                        }
                    }
                    if (alive.Row != Board.MainBoardList.Count - 1) // not full bottom
                    {
                        if (Board.MainBoardList[alive.Row + 1][alive.Col + 1] == false) //check bottomright
                        {
                            potentialLife.Add(new Location(alive.Col+1,alive.Row+1));
                        }
                    }
                }
                if (alive.Row != 0) //not full top
                {
                    if (Board.MainBoardList[alive.Row - 1][alive.Col] == false) //check top
                    {
                        potentialLife.Add(new Location(alive.Col,alive.Row-1));
                    }   
                }
                if (alive.Row != Board.MainBoardList.Count -1) //not full bottom
                {
                    if (Board.MainBoardList[alive.Row + 1][alive.Col] == false) //check bottom
                    {
                        potentialLife.Add(new Location(alive.Col,alive.Row+1));
                    }
                }
            }
            return potentialLife;
        }
        
        public bool IsAlive() //be careful to use the correct row/column I think it should be [row] [col] but findlife must be changed to suit
        {
            int neighbours = 0;
            if (Col != 0) // not full left
            {
                if (Board.MainBoardList[Row][Col - 1]) //Left
                {
                    neighbours += 1;
                }
                if (Row != 0) //not full up
                {
                    if (Board.MainBoardList[Row - 1][Col - 1]) //Top Left
                    {
                        neighbours += 1;
                    }
                }
                if (Row != Board.MainBoardList.Count - 1) //not full down
                {
                    if (Board.MainBoardList[Row + 1][Col - 1]) //Bottom Left 
                    {
                        neighbours += 1;
                    }
                }
            }
            
            if (Col != Board.MainBoardList[Row].Length - 1) // not full right
            {
                if (Board.MainBoardList[Row][Col + 1]) //Right
                {
                    neighbours += 1;
                }
                if (Row != 0) //not full up
                {
                    if (Board.MainBoardList[Row - 1][Col + 1]) //Top Right
                    {
                        neighbours += 1;
                    }
                }
                if (Row != Board.MainBoardList.Count) //not full down
                {
                    if (Board.MainBoardList[Row + 1][Col + 1]) //Bottom Right
                    {
                        neighbours += 1;
                    }
                }
            }
            
            if (Row != 0) //not full up
            {
                if (Board.MainBoardList[Row - 1][Col])//Top
                {
                    neighbours += 1;
                }
            }
            if (Row != Board.MainBoardList.Count - 1) //not full down
            {
                if (Board.MainBoardList[Row + 1][Col]) //Bottom
                {
                    neighbours += 1;
                }
            }          
            if (neighbours == 2)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}