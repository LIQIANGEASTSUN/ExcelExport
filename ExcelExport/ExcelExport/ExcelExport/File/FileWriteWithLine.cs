using System;
using System.Collections.Generic;
using System.IO;

namespace ExcelExport
{
    /// <summary>
    /// 文件按行写入
    /// </summary>
    public class FileWriteWithLine
    {
        private FileStream _fs;
        private StreamWriter _sw;

        public FileWriteWithLine(string path)
        {
            try
            {
                _fs = new FileStream(path, FileMode.Create);
                _sw = new StreamWriter(_fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool AppendLine(string line)
        {
            bool result = true;
            try
            {
                _sw.WriteLine(line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public void Close()
        {
            try
            {
                _sw.Flush();
                _sw.Close();
                _fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
