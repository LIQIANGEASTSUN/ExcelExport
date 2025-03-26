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

        public static string GetSavePath(string fileName, CSType csType, FileType fileType)
        {
            if (csType == CSType.C)
            {
                return GetClientPath(fileName, fileType);
            }
            return GetServerPath(fileName, fileType);
        }

        /// <summary>
        /// 获取 CSV 保存路径
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <returns></returns>
        public static string GetClientPath(string fileName, FileType fileType)
        {
            string extension = GetExtension(fileType);
            return Path.Combine(savePath, fileType.ToString(), "Client", fileName + extension);
        }

        public static string GetServerPath(string fileName, FileType fileType)
        {
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
            else if (fileType == FileType.CS)
            {
                return ".cs";
            }
            return ".txt";
        }

    }
}
