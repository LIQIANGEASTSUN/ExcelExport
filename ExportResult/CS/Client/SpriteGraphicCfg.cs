using BettaSDK;

public class SpriteGraphicCfg : IJsonConfigBase {

    /// <summary>
    /// SpriteGraphicCfg
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// 资源类型
    /// 1 GameObject
    /// 2 Spine
    /// 3 Image
    /// </summary>
    public int ResType
    {
        get;
        private set;
    }

    /// <summary>
    /// 方向类型
    /// 1：一个方向
    /// N:Spine多个方向
    /// </summary>
    public int Direction
    {
        get;
        private set;
    }

    /// <summary>
    /// 资源路径
    /// </summary>
    public string ResPath
    {
        get;
        private set;
    }

}

