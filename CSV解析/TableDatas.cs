using System.Collections.Generic;

namespace BettaSDK
{

    /***
     * 表数据
     * 需要的功能类，需要自己持有相应数据
     * ***/
    public class TableDatas
    {
        #region Data

        /// <summary>
        /// key : 表数据名称
        /// TableData 
        /// </summary>
        private static Dictionary<string, TableData> _tableDic = new Dictionary<string, TableData>();

        #endregion

        public TableDatas()
        {
        }

        #region Control

        /// <summary>
        /// 加载 CSV
        /// </summary>
        /// <param name="tabName">csv 文件名</param>
        /// <param name="content">csv 文件内容</param>
        public static void LoadCsv(string tabName, string content)
        {
            TableData tableData = new TableData(tabName);
            tableData.SetData(content);
            _tableDic[tabName] = tableData;
        }

        /// <summary>
        /// 读取表数据
        /// </summary>
        /// <param name="tabName">表名</param>
        /// <param name="key">主键</param>
        /// <param name="field">列名</param>
        /// <returns></returns>
        public static string GetData(string tabName, string key, string field)
        {
            return GetData(tabName, int.Parse(key), field);
        }

        /// <summary>
        /// 读取表数据
        /// </summary>
        /// <param name="tabName">表名</param>
        /// <param name="key">主键</param>
        /// <param name="field">列名</param>
        /// <returns></returns>
        public static string GetData(string tabName, int key, string field)
        {
            if (!_tableDic.TryGetValue(tabName, out TableData tableData))
            {
                return string.Empty;
            }

            return tableData.GetData(key, field);
        }

        /// <summary>
        /// 获取表中所有的主键id
        /// </summary>
        /// <param name="tabName"></param>
        /// <returns></returns>
        public static List<int> GetIds(string tabName)
        {
            if (!_tableDic.TryGetValue(tabName, out TableData tableData))
            {
                UnityEngine.Debug.LogError("TableDatas GetIds is null:" + tabName);
                return new List<int>();
            }

            return tableData.GetKeyList();
        }

        /// <summary>
        /// 判断表中有无相应的主键行
        /// </summary>
        /// <param name="tabName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool HasId(string tabName, int id)
        {
            if (!_tableDic.TryGetValue(tabName, out TableData tableData))
            {
                return false;
            }
            return tableData.HasId(id);
        }

        /// <summary>
        /// 获取表所有的列名
        /// </summary>
        /// <param name="tabName">表名</param>
        /// <returns></returns>
        public static string[] GetFields(string tabName)
        {
            string[] fieldArr = new string[20];
            if (!_tableDic.TryGetValue(tabName, out TableData tableData))
            {
                return fieldArr;
            }
            return tableData.GetFields();
        }

        /// <summary>
        /// 判断表中有无相应的列名
        /// </summary>
        /// <param name="tabName">表名</param>
        /// <param name="field">列名</param>
        /// <returns></returns>
        public static bool HasField(string tabName, string field)
        {
            if (!_tableDic.TryGetValue(tabName, out TableData tableData))
            {
                return false;
            }
            return tableData.HasField(field);
        }
        #endregion
    }

    public class TableData
    {
        private string _fileName = string.Empty;
        private Dictionary<string, int> _colDic = new Dictionary<string, int>();
        private Dictionary<int, int> _rowDic = new Dictionary<int, int>();
        private List<List<string>> _contentList = new List<List<string>>();

        public TableData(string fileName)
        {
            _fileName = fileName;
        }

        public void SetData(string content)
        {
            _contentList.Clear();

            int offset = 0;
            int row = 0;
            bool hasKey = false;
            while (true)
            {
                List<string> lineList = GameAssist.readCsvLine(content, ref offset);
                if (lineList.Count <= 0)
                {
                    break;
                }

                if (!hasKey)
                {
                    hasKey = true;
                    for (int i = 0; i < lineList.Count; ++i)
                    {
                        _colDic[lineList[i]] = i;
                    }
                }

                string keyS = lineList[0];
                if (string.IsNullOrEmpty(keyS))
                {
                    continue;
                }

                if (!int.TryParse(keyS, out int key))
                {
                    continue;
                }

                _rowDic[key] = row;
                ++row;

                _contentList.Add(lineList);
            }
        }

        public string GetData(int key, string colName)
        {
            if (!_rowDic.TryGetValue(key, out int row))
            {
                return string.Empty;
            }

            if (!_colDic.TryGetValue(colName, out int col))
            {
                return string.Empty;
            }

            if (row >= _contentList.Count)
            {
                return string.Empty;
            }

            if (col >= _contentList[row].Count)
            {
                return string.Empty;
            }

            return _contentList[row][col];
        }

        public List<int> GetKeyList()
        {
            List<int> keyList = new List<int>();
            foreach (var kv in _rowDic)
            {
                keyList.Add(kv.Key);
            }
            return keyList;
        }

        public bool HasId(int key)
        {
            if (!_rowDic.TryGetValue(key, out int row))
            {
                return false;
            }
            return true;
        }

        public string[] GetFields()
        {
            return _contentList[0].ToArray();
        }

        public bool HasField(string field)
        {
            List<string> list = _contentList[0];
            int index = list.FindIndex((f) => { return f == field; });
            return 0 <= index && index < list.Count;
        }
    }
}
