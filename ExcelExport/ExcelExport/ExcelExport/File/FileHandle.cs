using System.IO;
using System.Collections.Generic;

namespace ExcelExport
{
    internal class FileHandle
    {
        public static HashSet<string> validExtensionHash = new HashSet<string>
        {
            ".xlsx",
            ".xls",
        };

        private static string savePath = string.Empty;
        public static void SetSavePath(string path)
        {
            savePath = path;
        }

        /// <summary>
        /// 获取 CSV 保存路径
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <returns></returns>
        public static string GetCsvClientPath(string excelFilePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(excelFilePath);
            return Path.Combine(savePath, "CSV", "Client", fileName + ".csv");
        }

        public static string GetCsvServerPath(string excelFilePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(excelFilePath);
            return Path.Combine(savePath, "CSV", "Server", fileName + ".csv");
        }

    }
}
