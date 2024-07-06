using System.Text;
using NahkLogic.Common;
using NahkLogic.Data;

namespace NahkLogic.Business;
public class ProfileValidation
{
    private static readonly List<string> errors = new();
    private static readonly string colorPattern = @"^0x([A-F]|\d){6}$";

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

    public static List<string> GetProfileNames() => ProfileRepository.GetProfileNames();

    public static int SaveProfile(Profile profile) => Validate(profile) ? ProfileRepository.SaveProfile(profile) : -1;

    public static Profile? LoadProfile(string name)
    {
        errors.Clear();
        Profile? profile = null;

        try
        {
            profile = ProfileRepository.LoadProfile(name);
        }
        catch (Exception e)
        {
            errors.Add(e.Message);
        }

        return profile;
    }

    public static void DeleteProfile(Profile profile)
    {
        errors.Clear();

        try
        {
            ProfileRepository.DeleteProfile(profile);
        }
        catch (Exception e)
        {
            errors.Add(e.Message);
        }
    }
    
    public static bool ValidateProfileName(string name)
    {
        var isValid = true;
        errors.Clear();
        var profileNames = ProfileRepository.GetProfileNames(true);

        if (profileNames.Contains(name.ToLower() + Config.FileExtension))
        {
            errors.Add("Profile name already exists.");
            isValid = false;
        }

        return isValid;
    }

    public static bool ValidatePauseName(Profile profile, string pauseName, bool isEditMode)
    {
        var isValid = true;
        errors.Clear();

        if (string.IsNullOrEmpty(pauseName))
        {
            errors.Add("Name cannot be empty.");
            isValid = false;
        }

        if (profile.PauseList.NameExists(pauseName) && !isEditMode)
        {
            errors.Add("A pause condition with this name already exists.");
            isValid = false;
        }

        return isValid;
    }

    public static bool ValidateSkillName(Profile profile, string skillName, bool isEditMode)
    {
        var isValid = true;
        errors.Clear();

        if (string.IsNullOrEmpty(skillName))
        {
            errors.Add("Name cannot be empty.");
            isValid = false;
        }

        if (profile.SkillList.NameExists(skillName) && !isEditMode)
        {
            errors.Add("A skill with this name already exists.");
            isValid = false;
        }

        return isValid;
    }

    public static bool ValidatePause(Profile profile, Pause pause, bool isEditMode)
    {
        errors.Clear();
        var isValid = ValidatePauseName(profile, pause.Name, isEditMode);

        pause.PixelChecks.ForEach(p =>  isValid = ValidatePixelCheck(p, isValid));

        return isValid;
    }

    public static bool ValidateSkill(Profile profile, Skill skill, bool isEditMode)
    {
        errors.Clear();
        var isValid = ValidateSkillName(profile, skill.Name, isEditMode);
        if (!skill.Timed)
        {
            skill.PixelChecks.ForEach(p => isValid = ValidatePixelCheck(p, isValid));
        }
        
        isValid = ValidateSkillKey(profile, skill.Key, isValid);

        if (skill.CoolDownMs is < Config.MinCoolDownMs or > Config.MaxCoolDownMs)
        {
            errors.Add($"Delay should be a number between {Config.MinCoolDownMs}ms and {Config.MaxCoolDownMs}ms");
            isValid = false;
        }

        if (skill.MinPreDelay is < Config.MinPreDelayAllowed or > Config.MaxPreDelayAllowed || 
            skill.MaxPreDelay is < Config.MinPreDelayAllowed or > Config.MaxPreDelayAllowed)
        {
            errors.Add($"Min and Max Pre-Delay values must be between {Config.MinPreDelayAllowed}ms and {Config.MaxPreDelayAllowed}ms");
            isValid = false;
        }

        if (skill.MinPreDelay > skill.MaxPreDelay)
        {
            errors.Add("Min Pre-Delay must be less than Max Pre-Delay");
            isValid = false;
        }

        return isValid;
    }

    public static bool ValidateKeyEvent(Profile profile, KeyEvent keyEvent, bool isEditMode)
    {
        errors.Clear();
        var isValid = ValidateKeyEventKey(profile, keyEvent.Key, true);
        
        return isValid;
    }
    
    private static bool ValidatePixelCheck(PixelCheck pixel, bool isValid)
    {
        if (pixel.X < 0 || pixel.Y < 0)
        {
            errors.Add("X and Y values must be positive numbers.");
            isValid = false;
        }

        if (pixel is { AreaSearch: true, AreaSearchDistance: < Config.MinAreaSearchDistance or > Config.MaxAreaSearchDistance })
        {
            errors.Add($"{pixel.Name} Area Search Distance must be a number between {Config.MinAreaSearchDistance} and {Config.MaxAreaSearchDistance}");
            isValid = false;
        }

        //if (pixel.Color != string.Empty && !Regex.IsMatch(pixel.Color, colorPattern))
        //{
        //    errors.Add("Color must be in the format of 0x00FF00.");
        //    isValid = false;
        //}

        //if (pixel is { AtMouse: true, Color: "" })
        //{
        //    errors.Add("Color must be provided when using At Mouse setting.");
        //    isValid = false;
        //}

        return isValid;
    }

    private static bool ValidateSkillKey(Profile profile, Key key, bool isValid)
    {
        if (string.IsNullOrWhiteSpace(key.KeyCode) || key.KeyCode == "None")
        {
            isValid = false;
            errors.Add("Invalid Key.");
        }

        if (profile.KeyEventList.HasKey(key))
        {
            isValid = false;
            errors.Add($"Invalid Key. The KeyEvent {profile.KeyEventList.GetKeyEvent(key).Name} is already assigned to this key combo.");
        }

        return isValid;
    }

    private static bool ValidateKeyEventKey(Profile profile, Key key, bool isValid)
    {
        if (string.IsNullOrWhiteSpace(key.KeyCode) || key.KeyCode == "None")
        {
            isValid = false;
            errors.Add("Invalid Key.");
        }

        if (profile.SkillList.HasKey(key))
        {
            isValid = false;
            errors.Add($"Invalid Key. The Skill {profile.SkillList.GetKeyEvent(key).Name} is already assigned to this key combo.");
        }
        return isValid;
    }

    private static bool Validate(Profile profile)
    {
        errors.Clear();
        return true;
    }
}
