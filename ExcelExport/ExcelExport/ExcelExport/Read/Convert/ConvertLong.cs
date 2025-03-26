
namespace ExcelExport
{
    public class ConvertLong : IConvert
    {
        public object Convert(object cellObject)
        {
            return System.Convert.ToInt64(cellObject);
        }
    }
}
