namespace NahkLogic.Common;
[Serializable]
public class UserSettings
{
    public int ScreenGrabTimerMs { get; set; } = Config.DefaultScreenGrabWaitMs;
    public int ContinuousLoopTimerMs { get; set; } = Config.DefaultContinuousLoopWaitMs;
    public int KeyEventTimerMs { get; set; } = Config.DefaultKeyEventLoopWaitMs;
    public bool AutoLoadLastProfile { get; set; }
    public bool UseMinimizeOverlay { get; set; } = true;
    public string LastProfileName { get; set; } = string.Empty;
    public bool MainWindowAlwaysOnTop { get; set; }

}
