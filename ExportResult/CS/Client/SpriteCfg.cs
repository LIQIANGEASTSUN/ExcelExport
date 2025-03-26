using BettaSDK;

public class SpriteCfg : IJsonConfigBase {

    /// <summary>
    /// SpriteCfg
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// 精灵类型
    /// 1 生物
    /// 2 道具
    /// </summary>
    public int SpriteType
    {
        get;
        private set;
    }

}

