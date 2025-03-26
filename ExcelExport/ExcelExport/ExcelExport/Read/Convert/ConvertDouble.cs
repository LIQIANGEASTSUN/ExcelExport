
namespace ExcelExport
{
    public class ConvertDouble : IConvert
    {
        public object Convert(object cellObject)
        {
            return System.Convert.ToDouble(cellObject);
        }
    }
}
