using System.Collections.Generic;
using System.Text;
using System;

namespace ExcelExport
{
    /// <summary>
    /// 导出给客户端使用的 csv
    /// </summary>
    public class WriteCsv
    {
        private FileWriteWithLine _fileWriteWithLine;
        private StringBuilder _sb = new StringBuilder();

        public WriteCsv(ReadExcel readExcel, CSType csType)
        {
            if (!readExcel.IsValid)
            {
                return;
            }
            string savePath = GetSavePath(readExcel, csType);
            
            _fileWriteWithLine = new FileWriteWithLine(savePath);
            Console.WriteLine("savePath:" + savePath);

            WriteRow(readExcel, csType, readExcel.PropertyNameList);
            foreach (List<object> list in readExcel.RowList)
            {
                WriteRow(readExcel, csType, list);
            }

            _fileWriteWithLine.Close();
        }

        private string GetSavePath(ReadExcel readExcel, CSType csType)
        {
            if (csType == CSType.C)
            {
                return FileHandle.GetClientPath(readExcel.ExcelPath, FileType.CSV);
            }
            return FileHandle.GetServerPath(readExcel.ExcelPath, FileType.CSV);
        }

        private HashSet<int> ClientExportColHash(ReadExcel readExcel, CSType csType)
        {
            if (csType == CSType.C)
            {
                return readExcel.ClientExportColHash;
            }
            return readExcel.ServerExportColHash;
        }

        private void WriteRow(ReadExcel readExcel, CSType csType, List<object> list)
        {
            _sb.Clear();
            HashSet<int> exportColHash = ClientExportColHash(readExcel, csType);
            for (int i = 0; i < list.Count; i++)
            {
                if (!exportColHash.Contains(i))
                {
                    continue;
                }

                if (i < list.Count - 1)
                {
                    _sb.Append(string.Format("{0}{1}", list[i].ToString(), ","));
                }
                else
                {
                    _sb.Append(string.Format("{0}", list[i].ToString()));
                }
            }

            _fileWriteWithLine.AppendLine(_sb.ToString());
        }
    }
}
