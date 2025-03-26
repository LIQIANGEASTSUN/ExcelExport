using BettaSDK;

public class level : IJsonConfigBase {

    /// <summary>
    /// ID
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// 关卡类型
    /// </summary>
    public int LevelType
    {
        get;
        private set;
    }

    /// <summary>
    /// 地图配置表
    /// </summary>
    public string MapConfig
    {
        get;
        private set;
    }

    /// <summary>
    /// 地图预设
    /// </summary>
    public string TileMapPrefab
    {
        get;
        private set;
    }

    /// <summary>
    /// 地图类型
    /// 1矩形，2菱形
    /// </summary>
    public int MapType
    {
        get;
        private set;
    }

}

