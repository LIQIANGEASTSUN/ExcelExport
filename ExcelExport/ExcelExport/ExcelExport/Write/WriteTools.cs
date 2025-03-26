using System.Collections.Generic;

namespace ExcelExport
{
    public class WriteTools
    {
        public static HashSet<int> ClientExportColHash(ReadExcel readExcel, CSType csType)
        {
            if (csType == CSType.C)
            {
                return readExcel.ClientExportColHash;
            }
            return readExcel.ServerExportColHash;
        }

    }
}
