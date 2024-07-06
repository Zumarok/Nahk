using System.Xml.Serialization;
using Microsoft.VisualBasic.FileIO;
using NahkLogic.Common;

namespace NahkLogic.Data;

/// <summary>
/// ProfileRepository
/// Provides a singular point for all verification of profile data.
/// </summary>
internal class ProfileRepository
{
    public static List<string> GetProfileNames(bool lower = false)
    {
        if (!Directory.Exists(Config.SavedProfileDirectory))
        {
            Directory.CreateDirectory(Config.SavedProfileDirectory);
        }

        List<string> files;
        if (lower)
        {
            files = Directory.GetFiles(Config.SavedProfileDirectory, "*" + Config.FileExtension).Select(f => f.Split('\\').Last().ToLower()).ToList();
        }

        files = Directory.GetFiles(Config.SavedProfileDirectory, "*" + Config.FileExtension).Select(f => f.Split('\\').Last()).ToList();
        files.Remove(Config.SettingsFileName + Config.FileExtension);
        return files;
    }

    public static int SaveProfile(Profile profile)
    {
        try
        {
            if (!Directory.Exists(Config.SavedProfileDirectory))
            {
                Directory.CreateDirectory(Config.SavedProfileDirectory);
            }
            var serializer = new XmlSerializer(typeof(Profile));
            using StreamWriter writer = new(Config.SavedProfileDirectory + profile.ProfileName + Config.FileExtension);
            serializer.Serialize(writer, profile);
        }
        catch (Exception e)
        {
            return -1;
        }

        return 0;
    }

    public static Profile? LoadProfile(string name)
    {
        var serializer = new XmlSerializer(typeof(Profile));
        using StreamReader reader = new(Config.SavedProfileDirectory + name);
        return serializer.Deserialize(reader) as Profile ?? new Profile();
    }

    public static void DeleteProfile(Profile profile)
    {
        FileSystem.DeleteFile(Config.SavedProfileDirectory + profile.ProfileName + Config.FileExtension, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
    }
}
