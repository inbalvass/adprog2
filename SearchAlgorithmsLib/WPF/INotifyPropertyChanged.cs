using System.ComponentModel;

namespace WPF
{
    /// <summary>
    /// INotifyPropertyChanged interface- for create events
    /// </summary>
    interface INotifyPropertyChanged
    {
        /// <summary>
        /// create event handler
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// notify that someting changed
        /// </summary>
        /// <param name="propName">the name of the property that changed</param>
        void NotifyPropertyChanged(string propName);
    }
}