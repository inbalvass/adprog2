namespace WPF
{
    interface ISettingsModel
    {
        string IP { get; set; }
        int Port { get; set; }
        int DefRows { get; set; }
        int DefCols { get; set; }
        int DefAlgo { get; set; }
        void SaveSettings();
    }
}