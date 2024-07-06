namespace NahkLogic.Common;

[Serializable]
public class KeyEvent
{
    public string Name { get; set; } = Config.DefaultKeyEventName;
    public Key Key { get; set; } = new();
    public List<string> SkillNames { get; set; } = new();
    public bool Enabled { get; set; } = true;
    public bool? Pauseable { get; set; } = null;
    public bool IgnoreModifiers { get; set; }
    public bool BlockEventKey { get; set; }
    public bool FirstFound { get; set; }
    public int DelayMs { get; set; } = Config.DefaultMinSendDelay;
    public bool Alt { get; set; }
    public bool Ctrl { get; set; }
    public bool Shift { get; set; }

    [NonSerialized] private CancellationTokenSource? cancelToken;
    [NonSerialized] private List<string> ignoreKeys = new();
    [NonSerialized] private List<string> startCommands = new();
    [NonSerialized] private List<string> stopCommands = new();

    public void OnRun(SkillList skillList)
    {
        ignoreKeys.Clear();
        startCommands.Clear();
        stopCommands.Clear();

        if (Alt)
        {
            ignoreKeys.Add("LMenu");
            startCommands.Add("Send {LAlt down}");
            stopCommands.Add("Send {LAlt up}");
        }

        if (Ctrl)
        {
            ignoreKeys.Add("LControlKey");
            startCommands.Add("Send {LCtrl down}");
            stopCommands.Add("Send {LCtrl up}");
        }

        if (Shift)
        {
            ignoreKeys.Add("LShiftKey");
            startCommands.Add("Send {LShift down}");
            stopCommands.Add("Send {LShift up}");
        }
    }

    public (List<string> commands, List<string> ignoreKeys) Start(CancellationTokenSource token)
    {
        cancelToken = token;
        return (startCommands, ignoreKeys);
    }

    public (List<string> commands, List<string> ignoreKeys) Stop()
    {
        cancelToken = null;
        return (stopCommands, ignoreKeys);
    }

    public CancellationTokenSource? GetCancelToken()
    {
        return cancelToken;
    }

    public bool IsRunning()
    {
        return cancelToken != null; 
    }

    public override string ToString()
    {
        return $"{Key} - {Name}";
    }
}
