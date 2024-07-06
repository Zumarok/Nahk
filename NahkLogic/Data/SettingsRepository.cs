using NahkLogic.Common;
using System.Xml.Serialization;

namespace NahkLogic.Data;
public class SettingsRepository
{
    public static UserSettings LoadSettings()
    {
        if (!Directory.Exists(Config.SavedProfileDirectory))
        {
            Directory.CreateDirectory(Config.SavedProfileDirectory);
        }

        var path = Config.SavedProfileDirectory + Config.SettingsFileName + Config.FileExtension;

        if (!File.Exists(path)) return new UserSettings();

        var serializer = new XmlSerializer(typeof(UserSettings));
        using StreamReader reader = new(path);
        return serializer.Deserialize(reader) as UserSettings ?? new UserSettings();

    }

    public static int SaveSettings(UserSettings userSettings)
    {
        try
        {
            if (!Directory.Exists(Config.SavedProfileDirectory))
            {
                Directory.CreateDirectory(Config.SavedProfileDirectory);
            }

            var serializer = new XmlSerializer(typeof(UserSettings));
            using StreamWriter writer = new(Config.SavedProfileDirectory + Config.SettingsFileName + Config.FileExtension);
            serializer.Serialize(writer, userSettings);
        }
        catch (Exception e)
        {
            return -1;
        }

        return 0;
    }
}
