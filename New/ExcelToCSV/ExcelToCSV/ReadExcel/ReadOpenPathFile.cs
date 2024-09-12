using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadExcel
{
    class ReadOpenPathFile
    {
        public List<string> Read(string path)
        {
            List<string> pathList = new List<string>();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                pathList.Add(line.ToString());
            }
            sr.Close();
            return pathList;
        }

        public void Delete(string path)
        {
            if ( File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void Write(string path, List<string> pathList)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            for (int i = 0; i < pathList.Count; ++i)
            {
                sw.WriteLine(pathList[i]);
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
