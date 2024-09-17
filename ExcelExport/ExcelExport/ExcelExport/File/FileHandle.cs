using System.IO;
using System.Collections.Generic;

namespace ExcelExport
{
    internal class FileHandle
    {
        private static object locker = new object();

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

        public static string GetCsvSaveDirectory()
        {
            lock (locker)
            {
                return Path.Combine(savePath, "CSV");
            }
        }

        /// <summary>
        /// 获取 CSV 保存路径
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <returns></returns>
        public static string GetCsvClientPath(string excelFilePath)
        {
            lock (locker)
            {
                string csvDirectory = GetCsvSaveDirectory();
                string fileName = Path.GetFileNameWithoutExtension(excelFilePath);
                return Path.Combine(csvDirectory, "Client", fileName + ".txt");
            }
        }

        public static string GetCsvServerPath(string excelFilePath)
        {
            lock (locker)
            {
                string csvDirectory = GetCsvSaveDirectory();
                string fileName = Path.GetFileNameWithoutExtension(excelFilePath);
                return Path.Combine(csvDirectory, "Server", fileName + ".txt");
            }
        }

        public static string CheckCsvClientFile(string excelFilePath)
        {
            lock(locker)
            {
                string csv_c_path = GetCsvClientPath(excelFilePath);
                CheckFile(csv_c_path);
                return csv_c_path;
            }
        }

        public static string CheckCsvServerFile(string excelFilePath)
        {
            lock (locker)
            {
                string csv_s_path = GetCsvServerPath(excelFilePath);
                CheckFile(csv_s_path);
                return csv_s_path;
            }
        }

        private static void CheckFile(string filePath)
        {
            lock (locker)
            {
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}
