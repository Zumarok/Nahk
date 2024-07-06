using System.ComponentModel;

namespace NahkLogic.Common;

[Serializable]
public class SkillList : BindingList<Skill>
{
    public List<string> SkillNames => Items.Select(i => i.Name).ToList();
    public List<string> ContinuousSkillNames => Items.Where(i => i.Continuous).Select(i => i.Name).ToList();

    public List<string> ContinuousSkillNamesWithExclusions(List<string> exclusions) =>
        Items.Where(i => i.Continuous && !exclusions.Contains(i.Name)).Select(i => i.Name).ToList();
    public List<string> NonContinuousSkillNames => Items.Where(i => !i.Continuous).Select(i => i.Name).ToList();
    public List<string> NonContinuousSkillNamesWithExclusions(List<string> exclusions) =>
        Items.Where(i => !i.Continuous && !exclusions.Contains(i.Name)).Select(i => i.Name).ToList();
    public bool NameExists(string name) => SkillNames.Contains(name);
    public Skill[] GetContinuousSkills => Items.Where(i => i.Continuous).ToArray();
    public Skill[] GetEnabledNonContinuousSkillsByName(List<string> names)
        => names.Select(n => Items.First(s => s.Name == n && s is { Enabled: true, Continuous: false })).ToArray();
    public List<string> GetAllKeyStrings() => Items.Select(s => s.Key.ToString()).ToList();
    public bool HasKey(Key key) => GetAllKeyStrings().Contains(key.ToString());
    public Skill GetKeyEvent(Key key) => Items.First(s => s.Key.ToString() == key.ToString());
}
