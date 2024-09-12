using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Excel;
using System.Data.Odbc;

namespace ReadExcel
{
    /// <summary>
    /// 解析 Excel 
    /// 第一行 字段文字描述
    /// 第二行 字段英文名
    /// 第三行 字段类型("int", "long", "float", "double", "string")
    /// 第四行 CS (包含C表示导出到客户端、包含S表示导出到服务器)
    /// </summary>
    class ReadExcelClass
    {
        /// <summary>
        /// 支持的参数类型：int、long、float、double、string
        /// </summary>
        /// <param name="paramType"></param>
        /// <returns></returns>
        private readonly HashSet<string> hash = new HashSet<string>()
        {
            "int", "long", "float", "double", "string"
        };

        /// <summary>
        /// 第一行、第三行不导出
        /// </summary>
        private readonly HashSet<int> excludedRowHash = new HashSet<int>() { 1, 3, 4};

        public void Read(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("导表失败:" + path);
                return;
            }

            DataTable dataTable = GetDataTable(path);
            AnalysisDataTable(dataTable);
        }

        private DataTable GetDataTable(string path)
        {
            string text = string.Empty;
            if (Path.GetExtension(path).CompareTo(".xlsx") == 0)
            {
                return ReadXlsx(path);
            }
            else
            {
                return ReadExcelXLS(path);
            }
        }

        private DataTable ReadXlsx(string path)
        {
            DataTable dataTable = null;
            try
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet result = excelReader.AsDataSet();
                if (result.Tables.Count > 0)
                {
                    dataTable = result.Tables[0];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return dataTable;
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

        private void AnalysisDataTable(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            int row = 0;
            // 遍历前三行
            // 第一行 属性说明
            // 第二行 属性名
            // 第三行 类型声明(int, string、、)
            foreach(DataRow dataRow in dataTable.Rows)
            {
                if (excludedRowHash.Contains(row++))
                {
                    continue;
                }
                foreach(DataColumn dataColumn in dataTable.Columns)
                {
                    string columnName = dataColumn.ColumnName;
                    string value = dataRow[columnName].ToString();
                }
            }
        }
    }
}
