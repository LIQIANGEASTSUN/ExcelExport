using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Excel;
using System.Data.Odbc;

namespace ReadExcel
{
    class ReadExcelClass
    {
        Dictionary<int, List<List<string>>> dataDic = new Dictionary<int, List<List<string>>>();
        private Dictionary<string,StringBuilder> _classCustom =new Dictionary<string, StringBuilder>();
        public Dictionary<int, List<List<string>>> Read(string path)
        {
            dataDic.Clear();
            _classCustom.Clear();

            string text = string.Empty;
            if (Path.GetExtension(path).CompareTo(".xlsx") == 0)
            {
                ReadExcel(path);
            }
            else
            {
                DataTable dataTable = ReadExcelXLS(path);
                text = GetExcelValue(dataTable);
            }

            return dataDic;
        }

        private Dictionary<int, List<List<string>>> ReadExcel(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            try
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                DataSet result = excelReader.AsDataSet();

                if (result.Tables.Count <= 0)
                {
                    return null;
                }

                for (int i = 0; i < result.Tables.Count; ++i)
                {
                    AnalysisExcel(result.Tables[i], i);
                }
            }
            catch (Exception e) { throw (e); }

            return dataDic;
        }

        private Dictionary<int, List<List<string>>> AnalysisExcel(DataTable dataTable, int index)
        {
            if (dataTable == null)
            {
                return null;
            }

            GetCSAttributeFile( dataTable, index);

            List<List<string>> dataList = new List<List<string>>();

            int columns = dataTable.Columns.Count;
            int rows = dataTable.Rows.Count;

            //解析需要保存的XML名(第一行第一列的值)
            //将文件名存入到第一个数据
            string _fileName = dataTable.Rows[0][0].ToString();

            List<string> fileNameList = new List<string>();
            fileNameList.Add(_fileName);
            dataList.Add(fileNameList);

            // 遍历前三行
            // 第一行 属性说明
            // 第二行 属性名
            // 第三行 类型声明(int, string、、)
            for (int i = 0; i < rows; ++i)
            {
                List<string> AttributeList = new List<string>();
                bool isAvalidRow = true;
                for (int j = 1; j < columns; ++j)
                {
                    string value = dataTable.Rows[i][j].ToString();

                    if (j == 1 && i >= 4 && string.IsNullOrEmpty(value))
                    {
                        isAvalidRow = false;
                        break;
                    }
                    AttributeList.Add(value);
                }
                if (isAvalidRow)
                {
                    dataList.Add(AttributeList);
                }
            }

            int key = index;
            dataDic[key] = dataList;

            return dataDic;
        }

        private DataTable ReadExcelXLS(string path)
        {
            DataTable dtYourData = new DataTable("YourData");

            // Must be saved as excel 2003 workbook, not 2007, mono issue really
            string con = "Driver={Microsoft Excel Driver (*.xls)}; DriverId=790; Dbq=" + path + ";";

            string yourQuery = "SELECT * FROM [Sheet1$]";
            // our odbc connector 
            OdbcConnection oCon = new OdbcConnection(con);
            // our command object 
            OdbcCommand oCmd = new OdbcCommand(yourQuery, oCon);
            // table to hold the data 	
            // open the connection 
            oCon.Open();
            // lets use a datareader to fill that table! 
            OdbcDataReader rData = oCmd.ExecuteReader();
            // now lets blast that into the table by sheer man power! 
            dtYourData.Load(rData);
            // close that reader! 
            rData.Close();
            // close your connection to the spreadsheet! 
            oCon.Close();

            return dtYourData;
        }

        private string GetExcelValue(DataTable dataTable)
        {
            string text = string.Empty;

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; ++j)
                    {
                        text += dataTable.Rows[i][dataTable.Columns[j].ColumnName].ToString();
                    }
                }
            }

            return text;
        }

        private void GetCSAttributeFile(DataTable dataTable, int index)
        {
            StringBuilder CSContentStr = new StringBuilder();
            List<List<string>> dataList = new List<List<string>>();

            int columns = dataTable.Columns.Count;
            int rows = dataTable.Rows.Count;

            string _fileName = dataTable.Rows[0][0].ToString();
            //将文件名存入到第一个数据
            List<string> fileNameList = new List<string>();
            fileNameList.Add(_fileName);
            dataList.Add(fileNameList);

            //第三行第三列存储的是数据类型
            CSContentStr.AppendLine("using System;");
            CSContentStr.AppendLine("using System.Collections.Generic;");
            CSContentStr.AppendLine("using System.Text;");
            string className = ProcessName(_fileName);
            CSContentStr.AppendLine("public class " + className + "{");

            //遍历所有属性名（第二行，第二列以后整行数据）
            List<string> AttributeList = new List<string>();
            for (int i = 1; i < columns; ++i)
            {
                string value = dataTable.Rows[2][i].ToString();

                AttributeList.Add(value);

                //第三行数据数据结构处理
                //解析前三行 生成表结构
                string paramDesc = dataTable.Rows[0][i].ToString();
                string paramType = dataTable.Rows[2][i].ToString();
                paramType = GetAvalidType(paramType);
                string paramName = dataTable.Rows[1][i].ToString();

                if (string.IsNullOrEmpty(paramName) || paramName.CompareTo("") == 0)
                {
                    continue;
                }

                CSContentStr.AppendLine("\t/// <summary>");
                CSContentStr.AppendLine("\t///" + paramDesc);
                CSContentStr.AppendLine("\t/// <summary>");
                //当前列的结构语句
                CSContentStr.AppendLine(string.Format("\tpublic {0} {1} ", paramType, paramName) + "{get;private set;}");
            }
            CSContentStr.AppendLine("}");
            // 第二个数据保存属性值
            dataList.Add(AttributeList);
            _classCustom.Add(className, CSContentStr);
        }

        public void SaveCsToFile(string outPath)
        {
            if (!outPath.EndsWith("Client\\CS"))
            {
                outPath = string.Format("{0}\\{1}", outPath, "Client\\CS");
            }
            SaveToFile(outPath, _classCustom, ".cs");
        }

        public void SaveToFile(string outPath, Dictionary<string, StringBuilder> fileStringBuilderDic, string extension)
        {
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }
            foreach (var classFile in fileStringBuilderDic)
            {
                string filePath = Path.Combine(outPath, classFile.Key + extension);
                using (FileStream fs = File.Create(filePath))
                {
                    try
                    {
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(classFile.Value.ToString());
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
           
        }

        private string ProcessName(string fileName)
        {
            string result = string.Empty;//定义一个空字符串
            if (fileName.Contains("_"))
            {
                string[] strArray = fileName.Split('_');

                foreach (string s in strArray)//循环处理数组里面每一个字符串
                {
                    result += System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s);
                }
            }
            else
            {
                result = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(fileName);
            }
            return result + "Data";
        }

        /// <summary>
        /// 获取有效参数类型：只支持 int、long、float、double、string
        /// </summary>
        /// <param name="paramType"></param>
        /// <returns></returns>
        private readonly Dictionary<string, bool> m_paramTypeDic = new Dictionary<string, bool>() {
            { "int", true},// 、、、long、string
            { "long", true},
            { "float", true},
            { "double", true},
            { "string", true }
        };
        private string GetAvalidType(string paramType)
        {
            if (m_paramTypeDic.ContainsKey(paramType))
            {
                return paramType;
            }

            return "string";
        }
    }
}
