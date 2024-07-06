using System.ComponentModel;

namespace NahkLogic.Common;

[Serializable]
public class PauseList : BindingList<Pause>
{
    public List<string> PauseNames => Items.Select(i => i.Name).ToList();
    public bool NameExists(string name) => PauseNames.Contains(name);
}
