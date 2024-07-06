using System.ComponentModel;
using System.Runtime.CompilerServices;
using NahkLogic.Common;

namespace Nahk.ViewModels;

/// <summary>
/// Base class for all ViewModel classes
/// </summary>
public class ViewModelBase<T> : INotifyPropertyChanged where T : new()
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string xml = string.Empty;
    private T model = new();
    public T Model
    {
        get => model;
        set
        {
            if (value == null) return;

            xml = value.XmlSerializeToString();
            model = xml.XmlDeserializeFromString<T>() ?? new T();
            OnPropertyChanged();
        }
    }

    public void RefreshDisplay() => OnPropertyChanged(nameof(Model));

    public bool HasChangedSinceLoad() => model != null && model.XmlSerializeToString() != xml;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
