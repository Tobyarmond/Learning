using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Grid
{
    public class Grid
    {
        public IEnumerable<Type> Main;
        public IEnumerable<Type> Secondary;
        // Make a way of adding grids
        // Make it generic type capable
        // It needs to be able to make an array of undetermined size with undertermined type
        public Grid(int width, int height, object T) // 
        {
            // need to make a 2x2 array
            // How do we deal with name? return
            Type type = T.GetType();
            Main = new IEnumerable<type>(width,height); // Why can't I do this?
        }

        public object GetTile(int col, int row)
        {
            IEnumerable<this.GetType()> second = Main.ElementAt(col);
            return second.ElementAt(row);
        }
        
        
    }
}