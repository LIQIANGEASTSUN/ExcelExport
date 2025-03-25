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
        public static string GetClientPath(string excelFilePath, FileType fileType)
        {
            string fileName = Path.GetFileNameWithoutExtension(excelFilePath);
            string extension = GetExtension(fileType);
            return Path.Combine(savePath, fileType.ToString(), "Client", fileName + extension);
        }

        public static string GetServerPath(string excelFilePath, FileType fileType)
        {
            string fileName = Path.GetFileNameWithoutExtension(excelFilePath);
            string extension = GetExtension(fileType);
            return Path.Combine(savePath, fileType.ToString(), "Server", fileName + extension);
        }

        private static string GetExtension(FileType fileType)
        {
            if (fileType == FileType.CSV)
            {
                return ".csv";
            }
            else if (fileType == FileType.Json)
            {
                return ".json";
            }
            return ".txt";
        }

    }
}
