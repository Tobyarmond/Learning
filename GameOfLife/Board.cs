using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UserInput;

using System.Runtime.CompilerServices;

namespace GameOfLife
{
    // Will be like  ReadBoard(FindGofs())   
    public class Board
    {
        #region Properties
        public static List<bool[]> MainBoardList = new List<bool[]>(); // Remember to initiate static objects.
        public static List<bool[]> NextMainBoardList = new List<bool[]>(); // Remember to initiate static objects.
        internal static string path = "..\\..\\gofs\\"; // The ..\\ sections go up directories
        private static DirectoryInfo _directory = new DirectoryInfo(path);
        #endregion

        #region Methods
        public static string FindGofs()
        {
            Dictionary<int, string> options = new Dictionary<int, string>();
            Console.WriteLine("Finding .gof files...");
            int count = 1;
            foreach (FileInfo fi in _directory.GetFiles())
            {
                if (fi.Extension == ".gof")
                {
                    options.Add(count,fi.Name);
                    count++;
                }
            }
            return options[Input.ConsoleRadio(options)];   
        }
        
        public static void ReadBoard(string filePath)
        {
            ArrayList splitLine = new ArrayList();
            string line;
            // This method should read the values stored within the external files.
            Console.WriteLine("Reading File...");
            try // can't remember why I put this in a try block. Theres a chance of somekind of NullReferenceException maybe?
            {
                System.IO.StreamReader file = new StreamReader(@filePath);
                while ((line = file.ReadLine()) != null)
                {
                    string[] lineSplit  = line.Split(',');
                    splitLine.Add(lineSplit);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Console.WriteLine("File Read \nConverting .gof file...");
            foreach (string[] toConvert in splitLine)
            {
                MainBoardList.Add(ConvertGofLine(toConvert));
            }
            Console.WriteLine($"{filePath} Board data loaded!");
        }

        // TODO Add some safety to the convert and read section to avoid unwanted exceptions.
        private static bool[] ConvertGofLine(string[] line)
        {
            bool[] bools = new bool[line.Length];
            int count = 0;
            foreach (string state in line)
            {
                if (state == "0")
                {
                    bools[count] = false;
                    count++;
                }
                if (state == "1")
                {
                    bools[count] = true;
                    count++;
                }
            }
            return bools;
        }
        #endregion
    }
}