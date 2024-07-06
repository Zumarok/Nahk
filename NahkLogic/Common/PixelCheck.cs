using System.Drawing;
using System.Xml.Serialization;

namespace NahkLogic.Common;

[Serializable]
public class PixelCheck
{
    public string Name { get; set; } = Config.DefaultPixelCheckName;
    public int X { get; set; }
    public int Y { get; set; }
    public bool AtMouse { get; set; }
    public bool OnFound { get; set; } = true;
    public bool AreaSearch { get; set; }
    public int AreaSearchDistance { get; set; } = Config.DefaultAreaSearchDistance;

    [XmlIgnore]
    public Color Color { get; set; }

    [XmlElement("Color")]
    public int ColorAsArgb
    {
        get => Color.ToArgb();
        set => Color = Color.FromArgb(value);
    }

}
