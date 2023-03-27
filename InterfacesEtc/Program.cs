﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks.Dataflow;
using InterfacesEtc.Classes;

namespace InterfacesEtc
{
    interface IFileWriter
    {
        
    }
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            IFileWriter[] ListFileWriters = new IFileWriter[3];
            TxtFileWriter WriteText = new TxtFileWriter();
            ListFileWriters[0] = new TxtFileWriter();
            ListFileWriters[1] = WriteText;
        }
    }
}


