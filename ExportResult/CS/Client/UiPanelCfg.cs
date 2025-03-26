using BettaSDK;

public class UiPanelCfg : IJsonConfigBase {

    /// <summary>
    /// UiPanelCfg
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// 资源名
    /// </summary>
    public string Asset
    {
        get;
        private set;
    }

    /// <summary>
    /// 层级
    /// MainLayer
    /// </summary>
    public string Layer
    {
        get;
        private set;
    }

    /// <summary>
    /// 类名
    /// </summary>
    public string ClassName
    {
        get;
        private set;
    }

}

