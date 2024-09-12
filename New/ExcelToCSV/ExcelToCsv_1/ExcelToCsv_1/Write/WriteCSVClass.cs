using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ReadExcel
{
    class WriteCSVClass
    {
        public void CreateCSV(Dictionary<int, List<List<string>>> dataDic, string savePath)
        {

            foreach (KeyValuePair<int, List<List<string>>> kv in dataDic)
            {
                CreateTableDataCSV(kv.Value, savePath);
            }
        }

        private void CreateTableDataCSV(List<List<string>> dataList, string savePath)
        {
            if (dataList == null || dataList.Count <= 2)
            {
                return;
            }

            List<string> fileNameList = dataList[0];
            // 根据类型获取 CSV 名
            string csvName = fileNameList[0];

            string path = string.Empty;
            string endsWith = string.Empty;
            string extension = string.Empty;  // 扩展名

            extension = "txt";

            if (!savePath.EndsWith(endsWith))
            {
                savePath = string.Format("{0}\\{1}", savePath, endsWith);
            }
            path = string.Format("{0}\\{1}.{2}", savePath, csvName, extension);

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            // 已经存在该文件则删除
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path))
            {
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

                try
                {
                    for (int i = 1; i < dataList.Count; ++i)
                    {
                        if (i == 5)
                        {
                            continue;
                        }
                        List<string> rowList = dataList[i];

                        StringBuilder stringBuilder = new StringBuilder();
                        for (int j = 0; j < rowList.Count; ++j)
                        {
                            stringBuilder.Append(rowList[j]);
                            if (j < rowList.Count - 1)
                            {
                                stringBuilder.Append("`");
                            }
                        }

                        if (!string.IsNullOrEmpty(stringBuilder.ToString()))
                        {
                            sw.WriteLine(stringBuilder.ToString());
                        }
                    }

                    sw.Close();
                    fs.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
