using System.Collections.Generic;

namespace ExcelExport
{
    /// <summary>
    /// 导出为 客户端、服务器类型
    /// C 导出客户端
    /// S 导出服务器
    /// </summary>
    public enum CSType
    { 
        C = 1,
        S = 2,
    }

    /// <summary>
    /// 导出文件类型
    /// </summary>
    public enum FileType
    {
        CSV,
        Json,
    }

    internal class ExcelConfig
    {
        /// <summary>
        /// 配置表最少需要四行
        /// </summary>
        public const int RowMin = 4;

        /// <summary>
        /// 属性名行
        /// </summary>
        public const int PropertyNameRow = 1;

        /// <summary>
        /// 属性类型行
        /// </summary>
        public const int PropertyTypeRow = 2;

        /// <summary>
        /// 标记 C/S 行
        /// </summary>
        public const int CSRow = 3;

        /// <summary>
        /// 数据开始的行
        /// </summary>
        public const int DataStartRow = 4;

        /// <summary>
        /// 支持的参数类型：int、long、float、double、string
        /// </summary>
        /// <param name="paramType"></param>
        /// <returns></returns>
        public static HashSet<string> propertyTypeHash = new HashSet<string>()
        {
            "int", 
            "int[]",
            "int[][]",
            "long",
            "long[]",
            "long[][]",
            "float",
            "float[]",
            "float[][]",
            "double",
            "double[]",
            "double[][]",
            "string",
            "string[]",
            "string[][]",
            "Json",
        };

    }
}
