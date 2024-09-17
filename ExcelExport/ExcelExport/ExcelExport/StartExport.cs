using System;
using System.Collections.Generic;
using System.IO;

namespace ExcelExport
{
    internal class StartExport
    {
        public static StartExport Instance;

        /// <summary>
        /// 有错误的配置表
        /// </summary>
        private List<string> errorFileList = new List<string>();
        public StartExport()
        {
            Instance = this;
        }

        public void Start(string[] args)
        {
            Console.WriteLine("测试");

            args = new string[] {
                "G:\\Git\\ExcelExport\\Table",
                "G:\\Git\\ExcelExport\\ExportResult"
            };

            if (null == args || args.Length == 0)
            {
                return;
            }

            string filePath = args[0];
            string savePath = args[1];
            FileHandle.SetSavePath(savePath);

            FileAttributes fileAttributes = File.GetAttributes(filePath);

            // 文件夹
            if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                ExportDirectory(filePath);
            }
            else // Excel 文件
            {
                ExportFile(filePath);
            }

            Console.WriteLine("导表结束");

            OutPutErrorFile();
        }
        
        private void ExportDirectory(string directory)
        {
            DirectoryInfo dInfo = new DirectoryInfo(directory);

            List<FileInfo> fileInfoList = new List<FileInfo>();

            FileInfo[] infos = dInfo.GetFiles("*.xlsx", SearchOption.AllDirectories);
            fileInfoList.AddRange(infos);

            FileInfo[] infos2 = dInfo.GetFiles("*.xls", SearchOption.AllDirectories);
            fileInfoList.AddRange(infos2);

            foreach (FileInfo info in fileInfoList)
            {
                string fullPath = info.FullName;
                ExportFile(fullPath);
            }
        }

        private void ExportFile(string filePath)
        {
            string ex = Path.GetExtension(filePath);
            if (!FileHandle.validExtensionHash.Contains(ex))
            {
                Console.WriteLine("文件扩展名错误");
                return;
            }

            Console.WriteLine("开始导出:" + filePath);
            ReadExcel readExcel = new ReadExcel(filePath);
            new WriteCsvClient(readExcel);
            new WriteCsvServer(readExcel);
            Console.WriteLine("导出完成:" + filePath);
            Console.WriteLine("");
        }

        private void OutPutErrorFile()
        {
            if (errorFileList.Count <= 0)
            {
                return;
            }
            Console.WriteLine("有错误的配置表");
            foreach(var filePath in errorFileList)
            {
                Console.WriteLine(filePath);
                Console.WriteLine("");
            }
        }

        public void AddErrorFileInfo(string filePath)
        {
            errorFileList.Add(filePath);
        }

    }
}
