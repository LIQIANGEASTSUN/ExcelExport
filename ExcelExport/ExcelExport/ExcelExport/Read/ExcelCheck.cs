using System.Collections.Generic;
using System.Data;
using System.Text;
using System;

namespace ExcelExport
{
    internal class ExcelCheck
    {
        /// 配置表检测：重复的 key、重复的属性名
        private StringBuilder sbCheck = new StringBuilder();

        public ExcelCheck()
        {

        }

        public bool CheckTable(string filePath, DataTable dataTable)
        {
            bool result1 = CheckPropertyType(dataTable, sbCheck);
            bool result2 = CheckRepeatKey(dataTable, sbCheck);

            if (!result1 || !result2)
            {
                Debug(sbCheck.ToString());
                StartExport.Instance.AddErrorFileInfo(filePath);
            }

            return result1 && result2;
        }

        /// <summary>
        /// 检查有无重复的属性名
        /// 检查属性类型有没有错误的
        /// </summary>
        /// <returns></returns>
        private bool CheckPropertyType(DataTable dataTable, StringBuilder sb)
        {
            DataRow propertyNameRow = dataTable.Rows[ExcelConfig.PropertyNameRow];
            DataRow propertyTypeRow = dataTable.Rows[ExcelConfig.PropertyTypeRow];
            int totalCol = dataTable.Columns.Count;

            // 属性名 hash
            HashSet<string> propertyNameHash = new HashSet<string>();

            bool result = true;
            for (int col = 0; col < totalCol; col++)
            {
                string propertyName = propertyNameRow[col].ToString();
                if (string.IsNullOrEmpty(propertyName))
                {
                    continue;
                }
                if (propertyNameHash.Contains(propertyName))
                {
                    result = false;
                    string msg = string.Format("属性名重复_{0}", propertyName);
                    sb.AppendLine(msg);
                }
                else
                {
                    propertyNameHash.Add(propertyName);
                }

                string type = propertyTypeRow[col].ToString();
                if (!ExcelConfig.propertyTypeHash.Contains(type))
                {
                    result = false;
                    string msg = string.Format("属性类型错误_{0}:{1}", propertyNameRow[col].ToString(), type);
                    sb.AppendLine(msg);
                }
            }

            return result;
        }

        /// <summary>
        /// 检查重复的主键
        /// </summary>
        /// <returns></returns>
        private bool CheckRepeatKey(DataTable dataTable, StringBuilder sb)
        {
            bool result = true;
            HashSet<string> keyHash = new HashSet<string>();

            int totalRow = dataTable.Rows.Count;
            for (int row = ExcelConfig.RowMin; row < totalRow; row++)
            {
                DataRow dataRow = dataTable.Rows[row];
                string key = dataRow[0].ToString();
                if (string.IsNullOrEmpty(key))
                {
                    continue;
                }
                if (keyHash.Contains(key))
                {
                    result = false;
                    string msg = string.Format("主键重复:{0}", key);
                    sb.AppendLine(msg);
                }
                else
                {
                    keyHash.Add(key);
                }
            }

            return result;
        }

        private void Debug(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
