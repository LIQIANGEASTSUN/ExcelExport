using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;

namespace ExcelExport
{
    /// <summary>
    /// 导出给客户端使用的 csv
    /// </summary>
    public class WriteJson
    {
        private FileWriteWithLine _fileWriteWithLine;
        private Dictionary<string, Dictionary<string, object>> _dic = new Dictionary<string, Dictionary<string, object>>();
        private List<string> _propertyList = new List<string>();

        public WriteJson(ReadExcel readExcel, CSType csType)
        {
            if (!readExcel.IsValid)
            {
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(readExcel.ExcelPath);
            string savePath = FileHandle.GetSavePath(fileName, csType, FileType.Json);
            Console.WriteLine("savePath:" + savePath);
            _fileWriteWithLine = new FileWriteWithLine(savePath);
            foreach(var property in readExcel.PropertyNameList)
            {
                _propertyList.Add(property.ToString());
            }

            foreach (List<object> list in readExcel.RowList)
            {
                WriteRow(readExcel, csType, list);
            }

            string json = JsonConvert.SerializeObject(_dic, Formatting.Indented);
            json = json.Replace("\"[", "[");
            json = json.Replace("]\"", "]");
            _fileWriteWithLine.AppendLine(json);
            _fileWriteWithLine.Close();
        }

        private void WriteRow(ReadExcel readExcel, CSType csType, List<object> list)
        {
            HashSet<int> exportColHash = WriteTools.ClientExportColHash(readExcel, csType);

            Dictionary<string, object> rowDic = new Dictionary<string, object>();
            string id = list[0].ToString();
            for (int i = 0; i < list.Count; i++)
            {
                if (!exportColHash.Contains(i))
                {
                    continue;
                }

                string property = _propertyList[i];
                rowDic[property] = list[i];
            }
            _dic[id] = rowDic;
        }

    }
}
