using System;
using ExcelExport;

namespace ExcelToCsv_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("args:" + i + "    " + args[i]);
            }

            Console.WriteLine("开始导出 CSV");

            //string path = "G:\\Project\\Git\\ExcelToCSV\\New\\ExcelToCSV\\Table\\Builds222.xlsx";
            string path = "G:\\Git\\ExcelExport\\Table\\Builds222.xlsx";

            ReadExcel readExcel = new ReadExcel(path);
            new WriteCsvClient(readExcel);
            new WriteCsvServer(readExcel);

            Console.WriteLine("导表结束");

            Console.ReadLine();
        }
    }
}
