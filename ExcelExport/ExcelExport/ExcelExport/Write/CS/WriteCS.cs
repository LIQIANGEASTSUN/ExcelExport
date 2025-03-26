using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

namespace ExcelExport
{
    /// <summary>
    /// 导出给客户端使用的 csv
    /// </summary>
    public class WriteCS
    {
        private FileWriteWithLine _fileWriteWithLine;
        private Dictionary<string, Dictionary<string, object>> _dic = new Dictionary<string, Dictionary<string, object>>();
        private StringBuilder sb = new StringBuilder();

        public WriteCS(ReadExcel readExcel, CSType csType)
        {
            if (!readExcel.IsValid)
            {
                return;
            }
            string savePath = WriteTools.GetSavePath(readExcel, csType, FileType.CS);
            Console.WriteLine("savePath:" + savePath);
            _fileWriteWithLine = new FileWriteWithLine(savePath);

            WriteRow(readExcel, csType);

            _fileWriteWithLine.AppendLine(sb.ToString());
            _fileWriteWithLine.Close();
        }

        private const string lb = "{";
        private const string rb = "}";

        private void WriteRow(ReadExcel readExcel, CSType csType)
        {
            HashSet<int> exportColHash = WriteTools.ClientExportColHash(readExcel, csType);

            string fileName = Path.GetFileNameWithoutExtension(readExcel.ExcelPath);
            WriteJsonCsAnalysis.Add($"{fileName}.json", fileName);

            sb.Clear();
            sb.AppendLine("using BettaSDK;");
            sb.AppendLine();
            sb.AppendLine($"public class {fileName} : IJsonConfigBase {lb}");
            sb.AppendLine();
            for (int i = 0; i < readExcel.PropertyTypeList.Count; ++i)
            {
                if (!exportColHash.Contains(i))
                {
                    continue;
                }

                string note = readExcel.NoteList[i].ToString();
                string type = readExcel.PropertyTypeList[i].ToString();
                string propertyName = readExcel.PropertyNameList[i].ToString();

                sb.AppendLine($"    /// <summary>");
                // 按行拆分并处理每一行
                var lines = note.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    sb.AppendLine($"    /// {line.Trim()}");
                }
                sb.AppendLine($"    /// </summary>");
                sb.AppendLine($"    public {type} {propertyName}");
                sb.AppendLine($"    {lb}");
                sb.AppendLine($"        get;");
                sb.AppendLine($"        private set;");
                sb.AppendLine($"    {rb}");
                sb.AppendLine();
            }
            sb.AppendLine($"{rb}");
        }


    }
}
