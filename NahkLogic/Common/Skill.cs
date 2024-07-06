using System.Drawing;

namespace NahkLogic.Common;

[Serializable]
public class Skill
{
    public string Name { get; set; } = Config.DefaultSkillName;
    public List<PixelCheck> PixelChecks { get; set; } = new();
    public int CoolDownMs { get; set; } = Config.DefaultCoolDownMs;
    public Key Key { get; set; } = new Key();
    public bool Continuous { get; set; }
    public bool Timed { get; set; }
    public bool Enabled { get; set; } = true;
    public bool Pauseable { get; set; } = true;
    public bool Precise { get; set; }
    public int MinPreDelay { get; set; } = 0;
    public int MaxPreDelay { get; set; } = 0;

    [NonSerialized] private long lastCastTime;
    [NonSerialized] private int maxAreaSearchDist;
    [NonSerialized] private PixelCheck[] atMouseChecks = Array.Empty<PixelCheck>();
    [NonSerialized] private PixelCheck[] nonMouseChecks = Array.Empty<PixelCheck>();
    [NonSerialized] private PixelCheck[] areaChecks = Array.Empty<PixelCheck>();

    public bool IsCoolDownReady()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastCastTime > CoolDownMs;
    }

    public void OnCast()
    {
        lastCastTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }

    public void OnRun()
    {
        atMouseChecks = PixelChecks.Where(p => p.AtMouse && !p.AreaSearch).ToArray();
        nonMouseChecks = PixelChecks.Where(p => !p.AtMouse).ToArray();
        areaChecks = PixelChecks.Where(p => p.AtMouse && p.AreaSearch).ToArray();
        maxAreaSearchDist = areaChecks.Length > 0 ? areaChecks.Max(p => p.AreaSearchDistance) : 0;
    }

    public PixelCheck[] GetAllAtMouseChecks()
    {
        return atMouseChecks;
    }

    public PixelCheck[] GetAllNonMouseChecks()
    {
        return nonMouseChecks;
    }

    public PixelCheck[] GetAllAreaSearches()
    {
        return areaChecks;
    }

    public int GetMaxAreaSearchDistance()
    {
        return maxAreaSearchDist;
    }
    

    public override string ToString()
    {
        return Name;
    }
}
