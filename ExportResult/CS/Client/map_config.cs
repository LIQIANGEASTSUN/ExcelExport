public class map_config : IJsonConfigBase {

    /// <summary>
    /// ID
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// 地图类型
    /// </summary>
    public string Type
    {
        get;
        private set;
    }

    /// <summary>
    /// 摄像机X坐标
    /// </summary>
    public float CameraX
    {
        get;
        private set;
    }

    /// <summary>
    /// 摄像机Y坐标
    /// </summary>
    public float CameraY
    {
        get;
        private set;
    }

    /// <summary>
    /// 摄像机Z坐标
    /// </summary>
    public float CameraZ
    {
        get;
        private set;
    }

    /// <summary>
    /// 第0行0列X坐标
    /// </summary>
    public float PositionX
    {
        get;
        private set;
    }

    /// <summary>
    /// 第0行0列Y坐标
    /// </summary>
    public float PositionY
    {
        get;
        private set;
    }

    /// <summary>
    /// 第0行0列Z坐标
    /// </summary>
    public float PositionZ
    {
        get;
        private set;
    }

    /// <summary>
    /// 相邻行x轴偏移
    /// </summary>
    public float AxisRowX
    {
        get;
        private set;
    }

    /// <summary>
    /// 相邻行y轴偏移
    /// </summary>
    public float AxisRowY
    {
        get;
        private set;
    }

    /// <summary>
    /// 相邻行z轴偏移
    /// </summary>
    public float AxisRowZ
    {
        get;
        private set;
    }

    /// <summary>
    /// 相邻列x轴偏移
    /// </summary>
    public float AxisColX
    {
        get;
        private set;
    }

    /// <summary>
    /// 相邻列y轴偏移
    /// </summary>
    public float AxisColY
    {
        get;
        private set;
    }

    /// <summary>
    /// 相邻列z轴偏移
    /// </summary>
    public float AxisColZ
    {
        get;
        private set;
    }

}

