﻿using System;
using System.IO;

namespace ExportExcel
{
    internal class FileHandle
    {
        private static object locker = new object();

        public static string GetCsvSaveDirectory(string excelFilePath)
        {
            lock (locker)
            {
                string directory = Path.GetDirectoryName(excelFilePath);
                string parentDirectory = Directory.GetParent(directory).FullName;
                return Path.Combine(parentDirectory, "Export", "CSV");
            }
        }

        /// <summary>
        /// 获取 CSV 保存路径
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <returns></returns>
        public static string GetCsv_C_Path(string excelFilePath)
        {
            lock (locker)
            {
                string csvDirectory = GetCsvSaveDirectory(excelFilePath);
                string fileName = Path.GetFileNameWithoutExtension(excelFilePath);
                return Path.Combine(csvDirectory, "Client", fileName + ".txt");
            }
        }

        public static string GetCsv_S_Path(string excelFilePath)
        {
            lock (locker)
            {
                string csvDirectory = GetCsvSaveDirectory(excelFilePath);
                string fileName = Path.GetFileNameWithoutExtension(excelFilePath);
                return Path.Combine(csvDirectory, "Server", fileName + ".txt");
            }
        }

        public static string CheckCsv_C_File(string excelFilePath)
        {
            lock(locker)
            {
                string csv_c_path = GetCsv_C_Path(excelFilePath);
                CheckFile(csv_c_path);
                return csv_c_path;
            }
        }

        public static string CheckCsv_S_File(string excelFilePath)
        {
            lock (locker)
            {
                string csv_s_path = GetCsv_S_Path(excelFilePath);
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
