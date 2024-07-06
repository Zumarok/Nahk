using NahkLogic.Common;
using NahkLogic.Data;
using System.Text;

namespace NahkLogic.Business;
public class SettingsValidation
{
    private static readonly List<string> errors = new();

    public static string ErrorMessage
    {
        get
        {
            StringBuilder sb = new();

            foreach (var error in errors)
            {
                sb.AppendLine(error);
            }

            return sb.ToString();
        }
    }

    public static int SaveSettings(UserSettings userSettings) => Validate(userSettings) ? SettingsRepository.SaveSettings(userSettings) : -1;

    public static UserSettings LoadSettings()
    {
        errors.Clear();
        var userSettings = new UserSettings();

        try
        {
            userSettings = SettingsRepository.LoadSettings();
        }
        catch (Exception e)
        {
            errors.Add(e.Message);
        }

        return userSettings;
    }
    
    public static bool Validate(UserSettings userSettings)
    {
        errors.Clear();
        var isValid = true;

        if (userSettings.ScreenGrabTimerMs < Config.MinScreenGrabWaitMs)
        {
            errors.Add($"Screen Grab Timer must be a number greater than {Config.MinScreenGrabWaitMs}");
            isValid = false;
        }

        if (userSettings.ContinuousLoopTimerMs < Config.MinContinuousLoopWaitMs)
        {
            errors.Add($"Continuous Loop Timer must be a number greater than {Config.MinContinuousLoopWaitMs}");
            isValid = false;
        }

        if (userSettings.KeyEventTimerMs < Config.MinKeyEventLoopWaitMs)
        {
            errors.Add($"Key Event Timer must be a number greater than {Config.MinKeyEventLoopWaitMs}");
            isValid = false;
        }
        
        if (!string.IsNullOrEmpty(userSettings.LastProfileName) &&
            !userSettings.LastProfileName.EndsWith(Config.FileExtension))
        {
            userSettings.LastProfileName += Config.FileExtension;
        }

        return isValid;
    }
}
