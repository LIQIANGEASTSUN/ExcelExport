public class character : IJsonConfigBase {

    /// <summary>
    /// ID
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// 名字
    /// </summary>
    public string Name
    {
        get;
        private set;
    }

    /// <summary>
    /// 资源名
    /// </summary>
    public string ResName
    {
        get;
        private set;
    }

    /// <summary>
    /// AI配置文件
    /// </summary>
    public string AI_Config
    {
        get;
        private set;
    }

    /// <summary>
    /// AI功能类型
    /// </summary>
    public string FunctionType
    {
        get;
        private set;
    }

    /// <summary>
    /// 速度
    /// </summary>
    public float Speed
    {
        get;
        private set;
    }

}

