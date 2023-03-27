﻿using System;
 using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GameOfLife.Properties;


namespace GameOfLife
{
    public class Game
    {   
        private static Location[] FindLife() // Will find all living pieces 
        {
            int col = 0;
            int row = 0;
            List<Location> locations = new List<Location>();
            foreach (bool[] line in Board.MainBoardList)
            {
                col = 0;
                foreach (bool state in line)
                {
                    if (state)
                    {
                        locations.Add(new Location(col,row));
                    }
                    col++;
                }
                row++;
            }
            return locations.ToArray();
        }
        
        internal static void Generation()
        {
            // FIXME: after first or second generation the list is empty or something and causes a crash 
            
            // copy the old array completely (so that as we change the old one we do not lose the information
            CopyBoard(Board.MainBoardList,Board.NextMainBoardList);
            //clear the life from the new array
            Clear(Board.NextMainBoardList);
            //analyse the old array and populate the next array with the next living tiles.
            Location[] Living = FindLife();
            
            IEnumerable<Location> NextLiving = from location in Living
                where location.IsAlive()
                select location;
            
            foreach (Location loc in NextLiving)
            {
                Board.NextMainBoardList[loc.Col][loc.Row] = true; //check col row oritentation
            }
            IEnumerable<Location> PossibleLife = Location.PossibleNewLife(Living);

            IEnumerable<Location> possibleLife = PossibleLife.ToList();
            IEnumerable<IGrouping<int, Location>> dupLocations =
                from Location location1 in possibleLife
                from Location location2 in possibleLife
                where  location1.SameLoc(location2) //location operator overloaded.
                group location1 by location1.Col;
            foreach (IGrouping<int,Location> SameCol in dupLocations)
            {
                IEnumerable<IGrouping<int,Location>> SameDuplicate =
                    from Location1 in SameCol
                    from Location2 in SameCol
                    where Location1.Row == Location2.Row
                    group Location1 by Location1.Row;
                foreach (IGrouping<int,Location> ColRowGroup in SameDuplicate)
                {
                    if (ColRowGroup.Count() == 3)
                    {
                        foreach (Location loc in ColRowGroup)
                        {
                            if (!Board.NextMainBoardList[loc.Col][loc.Row])
                            {
                                Board.NextMainBoardList[loc.Col][loc.Row] = true;
                            }
                        }
                    }
                }
            }
            Board.MainBoardList = Board.NextMainBoardList;
            Clear(Board.NextMainBoardList);
        }
        
        private static void Clear(List<bool[]> toClear) // Be careful not to call the built in method Clear() this empties the list
        {
            for (int i = 0; i < toClear.Count; i++)
            {
                bool[] currentLine = toClear[i];
                for (int j = 0; j < currentLine.Length; j++)
                {
                    currentLine[j] = false;
                }
            }
        }
        
        //FIXME: Somewhere in this CopyBoard method there is a bug which causes an undhandled excepion error.
        // A collection was modified enumeration opreration may not execute.

        // This is going to be a brute force solution, it shows that I still have a lot to learn when it comes to dealing with
        // generic types like List<T> and with reference and value semantics.
        private static void CopyBoard(List<bool[]> copyFrom, List<bool[]> copyTo) 
        {
            int counter = 0;
            foreach (bool[] bArray in copyFrom)
            {
                copyTo.Add(new bool[bArray.Length]);
                int count = 0;
                foreach (bool b in bArray)
                {
                    copyTo[counter][count] = b;
                    count++;
                }
                counter++;
            }
        }
    }
}