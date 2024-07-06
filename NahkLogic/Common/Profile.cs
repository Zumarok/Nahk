namespace NahkLogic.Common;

[Serializable]
public class Profile
{
    public string ProfileName { get; set; } = Config.DefaultProfileName;
    public string WindowTitle { get; set; } = "";

    public PauseList PauseList { get; set; } = new();

    public SkillList SkillList { get; set; } = new();

    public KeyEventList KeyEventList { get; set; } = new();
}
