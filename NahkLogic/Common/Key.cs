namespace NahkLogic.Common;

[Serializable]
public class Key
{
    private string keyCode = "None";
    public string AhkKey { get; set; } = "";
    public bool Alt { get; set; }
    public bool Shift { get; set; }
    public bool Ctrl { get; set; }

    public string KeyCode
    {
        get => keyCode;
        set
        {
            keyCode = value;
            AhkKey = value switch
            {
                "Back" => "Backspace",
                "Return" => "Enter",
                "ShiftKey" => "Shift",
                "ControlKey" => "Control",
                "Menu" => "Alt",
                "Capital" => "CapsLock",
                "Prior" => "PgUp",
                "PageUp" => "PgUp",
                "Next" => "PgDn",
                "PageDown" => "PgDn",
                "D0" => "0",
                "D1" => "1",
                "D2" => "2",
                "D3" => "3",
                "D4" => "4",
                "D5" => "5",
                "D6" => "6",
                "D7" => "7",
                "D8" => "8",
                "D9" => "9",
                "NumPad0" => "Numpad0",
                "NumPad1" => "Numpad1",
                "NumPad2" => "Numpad2",
                "NumPad3" => "Numpad3",
                "NumPad4" => "Numpad4",
                "NumPad5" => "Numpad5",
                "NumPad6" => "Numpad6",
                "NumPad7" => "Numpad7",
                "NumPad8" => "Numpad8",
                "NumPad9" => "Numpad9",
                "Multiply" => "NumpadMult",
                "Add" => "NumpadAdd",
                "Subtract" => "NumpadSub",
                "Decimal" => "NumpadDot",
                "Divide" => "NumpadDiv",
                "LShiftKey" => "LShift",
                "RShiftKey" => "RShift",
                "LControlKey" => "LCtrl",
                "RControlKey" => "RCtrl",
                "LMenu" => "LAlt",
                "RMenu" => "RAlt",
                "Left" => "LButton",
                "Right" => "RButton",
                "Middle" => "MButton",
                "Oemtilde" => "`",
                "Oem1" => ";",
                "OemQuestion" => "/",
                "OemOpenBrackets" => "[",
                "Oem5" => "\\",
                "Oem6" => "]",
                "Oem7" => "\'",
                "Oemplus" => "=",
                "Oemcomma" => ",",
                "OemMinus" => "-",
                "OemPeriod" => ".",
                _ => value
            };
        }
    }

    public bool IsMouse => AhkKey.Contains("Button");
    
    public override string ToString()
    {
        return $"{(Alt ? "Alt+" : "")}{(Ctrl ? "Ctrl+" : "")}{(Shift ? "Shift+" : "")}{AhkKey}";
    }
}
