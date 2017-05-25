namespace WPF
{
    /// <summary>
    /// interface for the settings model
    /// </summary>
    interface ISettingsModel
    {
        /// <summary>
        /// get and set ip for binding
        /// </summary>
        string IP { get; set; }
        /// <summary>
        /// get and set port for binding
        /// </summary>
        int Port { get; set; }
        /// <summary>
        /// get and set rows for binding
        /// </summary>
        int DefRows { get; set; }
        /// <summary>
        /// get and set cols for binding
        /// </summary>
        int DefCols { get; set; }
        /// <summary>
        /// get and set the algorithm for binding
        /// </summary>
        int DefAlgo { get; set; }
        /// <summary>
        /// Save Settings
        /// </summary>
        void SaveSettings();
    }
}