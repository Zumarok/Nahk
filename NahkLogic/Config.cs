namespace NahkLogic;
public class Config
{
    public const string SavedProfileDirectory = @"profiles\";
    public const string FileExtension = ".xml";
    public const string SettingsFileName = "Settings";
    public const string DefaultProfileName = "New Profile";
    public const string DefaultPauseName = "New Pause Condition";
    public const string DefaultSkillName = "New Skill Check";
    public const string DefaultKeyEventName = "New Key Event";
    public const string DefaultPixelCheckName = "Pixel Check";

    public const int LogCharacterLimit = 50;
    public const int MaxLogEntries = 250;

    public const int DefaultCoolDownMs = 200;
    public const int MinCoolDownMs = 50;
    public const int MaxCoolDownMs = 60000;

    /// <summary>
    /// Changes how often the screen is captured.  
    /// Will increase responsiveness at the cost of significant CPU usage.
    /// Expensive operation.
    /// </summary>
    public const int DefaultScreenGrabWaitMs = 100;
    public const int MinScreenGrabWaitMs = 10;

    /// <summary>
    /// Changes how often pause checks and any continuous skills are checked.
    /// Minimal cpu cost to increase, note only the responsiveness of non-pixel check skills will improve
    /// when faster than ScreenGrabWaitMs.
    /// </summary>
    public const int DefaultContinuousLoopWaitMs = 100;
    public const int MinContinuousLoopWaitMs = 10;

    /// <summary>
    /// Changes how often Key Events are checked.
    /// Minimal cpu cost to increase, note only the responsiveness of non-pixel check skills will improve
    /// when faster than ScreenGrabWaitMs.
    /// </summary>
    public const int DefaultKeyEventLoopWaitMs = 50;
    public const int MinKeyEventLoopWaitMs = 10;

    //public const int DefaultKeyPressDuration = 30;

    /// <summary>
    /// Wait applied between each attempted key send on events that trigger multiple key sends.
    /// This can be set quite low as each skill cooldown is still checked.
    /// </summary>
    public const int DefaultMinSendDelay = 50;

    public const int CheckForWindowExistenceDelay = 2500;

    public const int DefaultAreaSearchDistance = 25;
    public const int MinAreaSearchDistance = 1;
    public const int MaxAreaSearchDistance = 500;

    public const int MinPreDelayAllowed = 0;
    public const int MaxPreDelayAllowed = 1000;

}
