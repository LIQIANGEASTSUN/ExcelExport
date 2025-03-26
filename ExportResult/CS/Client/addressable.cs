using BettaSDK;

public class addressable : IJsonConfigBase {

    /// <summary>
    /// ID
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// 目录
    /// </summary>
    public string Directory
    {
        get;
        private set;
    }

    /// <summary>
    /// 目录打包类型
    /// 1：目录创建Gorup
    /// 2：目录下每一个文件夹创建一个Group
    /// </summary>
    public int Type
    {
        get;
        private set;
    }

    /// <summary>
    /// 忽略
    /// 1:忽略的不创建Group
    /// </summary>
    public int Ignore
    {
        get;
        private set;
    }

    /// <summary>
    /// int数组
    /// </summary>
    public int[] intArr
    {
        get;
        private set;
    }

    /// <summary>
    /// int二维数组
    /// </summary>
    public int[][] towArr
    {
        get;
        private set;
    }

}

