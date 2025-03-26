using System;
using ExcelExport;

namespace ExcelExport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = new string[]
            {
                "H:/PhantomFish/ExcelExport/Table",
                "H:/PhantomFish/ExcelExport/ExportResult"
            };
            StartExport startExport = new StartExport();
            startExport.Start(args);
            Console.ReadLine();
        }
    }
}
