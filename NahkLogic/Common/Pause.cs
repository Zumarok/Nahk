namespace NahkLogic.Common;

[Serializable]
public class Pause
{
    public string Name { get; set; } = Config.DefaultPauseName;
    public List<PixelCheck> PixelChecks { get; set; } = new();
    public bool Enabled { get; set; } = true;

    public override string ToString()
    {
        return Name;
    }
}
