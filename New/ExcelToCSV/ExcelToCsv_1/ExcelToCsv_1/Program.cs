using System;

using ReadExcel;

namespace ExcelToCsv_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始导出 CSV");

            string path = "G:\\Project\\Git\\ExcelToCSV\\New\\ExcelToCSV\\Table\\Builds222.xlsx";

            ReadExcelClass readExcelClass = new ReadExcelClass();
            readExcelClass.Read(path);

            Console.ReadLine();
        }
    }
}
