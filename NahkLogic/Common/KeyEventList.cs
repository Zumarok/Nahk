using System.ComponentModel;

namespace NahkLogic.Common;

[Serializable]
public class KeyEventList : BindingList<KeyEvent>
{
    public List<string> GetAllKeyStrings() => Items.Select(k => k.Key.ToString()).ToList();
    public bool HasKey(Key key) => GetAllKeyStrings().Contains(key.ToString());
    public List<KeyEvent> GetKeyEventsByKeyValue(string keyCode) => Items.Where(i => i.Key.KeyCode == keyCode).ToList();

    /// <summary>
    /// Returns the first key event with a matching keycode and modifer key states.
    /// Returns null if no match.
    /// </summary>
    public KeyEvent? GetKeyEventWithMatchingModifierKeys(string keyCode, bool alt, bool ctrl, bool shift) =>
        GetKeyEventsByKeyValue(keyCode).FirstOrDefault(i => i.Key.Alt == alt && i.Key.Ctrl == ctrl && i.Key.Shift == shift);

    public IEnumerable<KeyEvent> GetKeyEventsWithMatchingModifierKeys(string keyCode, bool alt, bool ctrl, bool shift) =>
        GetKeyEventsByKeyValue(keyCode).Where(i => i.Key.Alt == alt && i.Key.Ctrl == ctrl && i.Key.Shift == shift);
    //public KeyEvent? GetKeyEventByKeyValue(string keyCode, bool alt, bool ctrl, bool shift) =>
    //    GetKeyEventsByKeyValue(keyCode).FirstOrDefault(i => i.Key.Alt == alt || i.Alt == alt
    //        && i.Key.Ctrl == ctrl || i.Ctrl == ctrl && i.Key.Shift == shift || i.Shift == shift);
    public Dictionary<string, KeyEvent> GetKeyEventDictionary => Items.ToDictionary(i => i.Key.KeyCode);

    public KeyEvent GetKeyEvent(Key key) => Items.First(ev => ev.Key.ToString() == key.ToString());
}
