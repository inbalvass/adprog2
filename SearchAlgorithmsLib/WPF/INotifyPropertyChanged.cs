using System.ComponentModel;

namespace WPF
{
    interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(string propName);
    }
}