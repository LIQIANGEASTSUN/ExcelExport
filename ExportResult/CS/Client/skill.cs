using BettaSDK;

public class skill : IJsonConfigBase {

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
    /// 目标
    /// -1 不需要
    /// 1 自己
    /// 2 己方
    /// 4 敌方
    /// </summary>
    public int Target
    {
        get;
        private set;
    }

    /// <summary>
    /// 冷却时间
    /// </summary>
    public float CD
    {
        get;
        private set;
    }

    /// <summary>
    /// 伤害
    /// </summary>
    public float Damage
    {
        get;
        private set;
    }

    /// <summary>
    /// BuffId
    /// </summary>
    public int BuffId
    {
        get;
        private set;
    }

}

