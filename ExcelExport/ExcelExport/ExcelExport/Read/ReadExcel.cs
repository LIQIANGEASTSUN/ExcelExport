using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Excel;
using System.Data.Odbc;

namespace ExcelExport
{
    /// <summary>
    /// 解析 Excel 
    /// 第一行 字段文字描述
    /// 第二行 字段英文名
    /// 第三行 字段类型("int", "long", "float", "double", "string")
    /// 第四行 CS (包含C表示导出到客户端、包含S表示导出到服务器)
    /// </summary>
    public class ReadExcel
    {
        private string excelPath = string.Empty;
        public string ExcelPath
        {
            get { return excelPath; }
            private set { excelPath = value; }
        }

        private bool isValid = false;
        public bool IsValid
        {
            get { return isValid; }
            private set { isValid = value; }
        }

        /// 客户端需要导出的列
        private HashSet<int> clientExportColHash = new HashSet<int>();
        public HashSet<int> ClientExportColHash
        {
            get { return clientExportColHash; }
        }

        /// 服务器需要导出的列
        private HashSet<int> serverExportColHash = new HashSet<int>();
        public HashSet<int> ServerExportColHash
        {
            get { return serverExportColHash; }
        }

        // 注释
        private List<object> noteList = new List<object>();
        public List<object> NoteList
        {
            get { return noteList; }
            private set { noteList = value; }
        }

        // 属性名
        private List<object> propertyNameList = new List<object>();
        public List<object> PropertyNameList
        {
            get { return propertyNameList; }
            private set { propertyNameList = value; }
        }

        // 属性类型
        private List<object> propertyTypeList = new List<object>();
        public List<object> PropertyTypeList
        {
            get { return propertyTypeList; }
            private set { propertyTypeList = value; }
        }

        /// 配置表数据
        private List<List<object>> rowList = new List<List<object>>();
        public List<List<object>> RowList
        {
            get { return rowList; }
        }

        public ReadExcel(string path)
        {
            if (!File.Exists(path))
            {
                Debug("导表路径不存在:" + path);
                return;
            }

            ExcelPath = path;

            DataTable dataTable = GetDataTable(path);
            if (null == dataTable || dataTable.Rows.Count < ExcelConfig.RowMin || dataTable.Columns.Count <= 0)
            {
                Debug("数据表格式不对:" + path);
                return;
            }

            ExcelCheck excelCheck = new ExcelCheck();
            if (!excelCheck.CheckTable(path, dataTable))
            {
                return;
            }
       
            CSHash(dataTable);
            AnalysisDataTable(dataTable);
            IsValid = true;
        }

        private DataTable GetDataTable(string path)
        {
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
            DataTable dtYourData = null;
            try
            {
                dtYourData = new DataTable("YourData");
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return dtYourData;
        }

        /// <summary>
        /// 客户端、服务器分别需要导出的列
        /// </summary>
        /// <param name="dataTable"></param>
        private void CSHash(DataTable dataTable)
        {
            DataRow csRow = dataTable.Rows[ExcelConfig.CSRow];
            int totalCol = dataTable.Columns.Count;
            for (int col = 0; col < totalCol; col++)
            {
                string cellValue = csRow[col].ToString();
                if (cellValue.Contains("C"))
                {
                    ClientExportColHash.Add(col);
                }
                if (cellValue.Contains("S"))
                {
                    ServerExportColHash.Add(col);
                }
            }
        }

        private void AnalysisDataTable(DataTable dataTable)
        {
            int totalRow = dataTable.Rows.Count;
            int totalCol = dataTable.Columns.Count;

            DataRow noteRow = dataTable.Rows[ExcelConfig.NoteRow];
            NoteList = CollectRow(noteRow, totalCol);

            DataRow propertyNameRow = dataTable.Rows[ExcelConfig.PropertyNameRow];
            PropertyNameList = CollectRow(propertyNameRow, totalCol);

            DataRow propertyTypeRow = dataTable.Rows[ExcelConfig.PropertyTypeRow];
            PropertyTypeList = CollectRow(propertyTypeRow, totalCol);

            for (int row = ExcelConfig.DataStartRow; row < totalRow; ++row)
            {
                DataRow dataRow = dataTable.Rows[row];
                List<object> list = CollectRow(dataRow, totalCol);
                if (null != list)
                {
                    RowList.Add(list);
                }
            }
        }

        private List<object> CollectRow(DataRow dataRow, int totalCol)
        {
            List<object> list = new List<object>();

            string key = dataRow[0].ToString();
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            for (int col = 0; col < totalCol; col++)
            {
                object cellObject = dataRow[col];
                cellObject = ProcessCellValue(col, cellObject);
                list.Add(cellObject);
            }
            return list;
        }

        private object ProcessCellValue(int col, object cellObject)
        {
            if (PropertyTypeList.Count <= 0)
            {
                return cellObject;
            }
            string propertyType = PropertyTypeList[col].ToString();
            IConvert convert = ExcelConfig.CanConvert(propertyType);
            if (null == convert)
            {
                return cellObject;
            }
            return convert.Convert(cellObject);
        }

        private void Debug(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
