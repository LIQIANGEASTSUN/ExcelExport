using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelToCsv_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始导出 CSV");

            //string path = "G:\\Project\\Git\\ExcelToCSV\\New\\ExcelToCSV\\Table\\Builds222.xlsx";

            string path = "G:\\Git\\ExcelToCSV\\New\\ExcelToCSV\\Table\\Builds222.xlsx";

            ExportExcel.ReadExcel readExcelClass = new ExportExcel.ReadExcel();
            readExcelClass.Read(path);

            List<List<string>> rowList = readExcelClass.RowList;
            StringBuilder sb = new StringBuilder();
            foreach(var list in rowList)
            {
                sb.Clear();
                foreach(var value in list)
                {
                    sb.Append(value + ",");
                }
                Console.WriteLine(sb.ToString());
            }

            Console.ReadLine();
        }
    }
}
