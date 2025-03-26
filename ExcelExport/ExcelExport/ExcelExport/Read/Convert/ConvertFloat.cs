
namespace ExcelExport
{
    public class ConvertFloat : IConvert
    {
        public object Convert(object cellObject)
        {
            return System.Convert.ToSingle(cellObject);
        }
    }
}
