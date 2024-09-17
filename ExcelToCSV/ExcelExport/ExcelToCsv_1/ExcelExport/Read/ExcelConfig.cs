using System.Collections.Generic;

namespace ExcelExport
{
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
            "int", "long", "float", "double", "string"
        };
    }
}
