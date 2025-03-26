
namespace ExcelExport
{
    public class ConvertString : IConvert
    {

        public object Convert(object cellObject)
        {
            string cellValue = cellObject.ToString();
            // 处理包含逗号或双引号的字段
            if (cellValue.Contains(",") || cellValue.Contains("\""))
            {
                // 如果包含双引号，替换为两个双引号
                cellValue = cellValue.Replace("\"", "\"\"");

                // 用双引号包裹整个字段
                cellValue = $"\"{cellValue}\"";
            }

            if (cellValue.Contains("\n"))
            {
                cellValue = cellValue.Replace("\n", "\\n");
            }
            return cellValue;
        }

    }
}
