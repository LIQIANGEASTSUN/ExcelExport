using BettaSDK;

public class XassetCfg : IJsonConfigBase {

    /// <summary>
    /// XassetCfg
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// BuildName
    /// </summary>
    public string BuildName
    {
        get;
        private set;
    }

    /// <summary>
    /// GroupId
    /// </summary>
    public int GroupId
    {
        get;
        private set;
    }

    /// <summary>
    /// 是否启用
    /// 不启用 = 0
    /// 启用 = 1
    /// </summary>
    public int Enable
    {
        get;
        private set;
    }

    /// <summary>
    /// 传输方式
    /// InstallTime = 0
    /// FastFollow = 1
    /// OnDemand = 2
    /// </summary>
    public int DeliveryMode
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
    /// 打包模式
    /// PackTogether = 0
    /// PackByFile = 1
    /// PackByFileWithoutExtension = 2
    /// PackByFolder =3
    /// PackByFolderTopOnly = 4
    /// PackByRaw = 5
    /// PackByCustom =6
    /// </summary>
    public int BundleMode
    {
        get;
        private set;
    }

    /// <summary>
    /// 寻址模式
    /// LoadByPath = 0
    /// LoadByName = 1
    /// LoadByNameWithoutExtension = 2
    /// LoadByDependencies = 3
    /// </summary>
    public int AddressMode
    {
        get;
        private set;
    }

}

