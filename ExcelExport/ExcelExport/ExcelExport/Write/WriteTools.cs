using System.Collections.Generic;

namespace ExcelExport
{
    public class WriteTools
    {
        public static string GetSavePath(ReadExcel readExcel, CSType csType, FileType fileType)
        {
            if (csType == CSType.C)
            {
                return FileHandle.GetClientPath(readExcel.ExcelPath, fileType);
            }
            return FileHandle.GetServerPath(readExcel.ExcelPath, fileType);
        }

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
