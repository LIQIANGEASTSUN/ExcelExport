using System;
using ExcelExport;

namespace ExcelExport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartExport startExport = new StartExport();
            startExport.Start(args);
            Console.ReadLine();
        }
    }
}
