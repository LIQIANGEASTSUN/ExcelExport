using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Text;

namespace ExcelExport
{
    public class WriteJsonSuperCS
    {
        public const string JsonSupreName = "IJsonConfigBase";

        private FileWriteWithLine _fileWriteWithLine;
        private const string lb = "{";
        private const string rb = "}";

        public WriteJsonSuperCS()
        {
            string filePath = $"{JsonSupreName}.json";
            string savePath = FileHandle.GetClientPath(filePath, FileType.CS);
            Console.WriteLine("WriteJsonSuper savePath:" + savePath);

            _fileWriteWithLine = new FileWriteWithLine(savePath);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public interface {JsonSupreName}");
            sb.AppendLine($"{lb}");
            sb.AppendLine($"{rb}");

            _fileWriteWithLine.AppendLine(sb.ToString());
            _fileWriteWithLine.Close();
        }
    }

}
