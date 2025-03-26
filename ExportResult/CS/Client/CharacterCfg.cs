using BettaSDK;

public class CharacterCfg : IJsonConfigBase {

    /// <summary>
    /// CharacterCfg
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
    /// 速度
    /// </summary>
    public float Speed
    {
        get;
        private set;
    }

}

