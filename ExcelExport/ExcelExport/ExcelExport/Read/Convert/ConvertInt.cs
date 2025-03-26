
namespace ExcelExport
{
    public class ConvertInt : IConvert
    {
        public object Convert(object cellObject)
        {
            return System.Convert.ToInt32(cellObject);
        }
    }
}
