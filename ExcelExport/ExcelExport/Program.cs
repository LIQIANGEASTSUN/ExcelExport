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
                "G:/Git/ExcelExport/Table",
                "G:/Git/ExcelExport/ExportResult"
            };
            StartExport startExport = new StartExport();
            startExport.Start(args);
            Console.ReadLine();
        }
    }
}
