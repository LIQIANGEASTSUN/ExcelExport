using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Excel;
using System.Data.Odbc;

namespace ReadExcel
{
    class ReadExcelClass
    {
        public List<List<string>> Read(string path)
        {
            if (!File.Exists(path))
            {
                return new List<List<string>>();
            }

            string text = string.Empty;
            if (Path.GetExtension(path).CompareTo(".xlsx") == 0)
            {
                return ReadExcel(path);
            }
            else
            {
                DataTable dataTable = ReadExcelXLS(path);
                text = GetExcelValue(dataTable);
            }

            return null;
        }

        private List<List<string>> ReadExcel(string path)
        {
            try
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                DataSet result = excelReader.AsDataSet();

                if (result.Tables.Count <= 0)
                {
                    return null;
                }

                AnalysisExcel(result.Tables[0]);
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return list;
        }

        private List<List<string>> AnalysisExcel(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return null;
            }

            List<List<string>> dataList = new List<List<string>>();

            int columns = dataTable.Columns.Count;
            int rows = dataTable.Rows.Count;

            //解析需要保存的 csv 文件名(第一行第一列的值)
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

            return dataList;
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
        private readonly HashSet<string> hash = new HashSet<string>() 
        {
            "int", "long", "float", "double", "string"
        };
        private string GetAvalidType(string paramType)
        {
            if (hash.Contains(paramType))
            {
                return paramType;
            }

            return "string";
        }
    }
}
