using BettaSDK;

public class table_text_localization : IJsonConfigBase {

    /// <summary>
    /// ID
    /// </summary>
    public int ID
    {
        get;
        private set;
    }

    /// <summary>
    /// 文本key
    /// </summary>
    public string Key
    {
        get;
        private set;
    }

    /// <summary>
    /// Chinese
    /// </summary>
    public string CN
    {
        get;
        private set;
    }

    /// <summary>
    /// English
    /// </summary>
    public string EN
    {
        get;
        private set;
    }

}

