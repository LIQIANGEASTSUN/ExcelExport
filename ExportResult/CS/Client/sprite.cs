public class sprite : IJsonConfigBase {

    /// <summary>
    /// ID
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
    /// 1 GameObject
    /// 2 Image
    /// N Spine
    /// </summary>
    public int Direction
    {
        get;
        private set;
    }

}

