using Newtonsoft.Json.Linq;
using TopShelfCustomer.Models;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// SettingsContainer:
    ///
    /// Singleton Settings manager. Holds a global UserSettings instance
    /// to allow for all views to access the user settings.
    /// </summary>
    public class SettingsContainer {

        public static string SettingsFilePath { get => "UserSetting"; }     //The filename of the settings file (with no extension)
        public UserSettings CurrentUserSettings { get; set; }       //global settings instance
        public static SettingsContainer Instance { get; } = new SettingsContainer();        //The singleton instance of this class

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsContainer() {
            CurrentUserSettings = new UserSettings();       //Initialize CurrentUserSettings
            InitializeUserSettings();       //Initialize the global user settings object
        }

        /// <summary>
        /// InitializeUserSettings:
        ///
        /// Utilizes the SerializationHelper static methods to
        /// either populate the User settings from the settings JSON
        /// file or create a new settings file and write the default values to it.
        /// </summary>
        void InitializeUserSettings() {
            if ( SerializationHelper.JsonFileExists( SettingsFilePath ) ) {      //Check if JSON file exists
                CurrentUserSettings = ( UserSettings )SerializationHelper.JsonRead<UserSettings>( SettingsFilePath );      //Read JsonFile and populate UserSettings object
            } else {
                JObject jsonObject = JObject.FromObject( CurrentUserSettings );     //Add blank UserSetting object to jsonObject
                SerializationHelper.JsonWrite( SettingsFilePath, jsonObject.ToString() );       //Write the blank UserSettings to the Settings file
            }
        }
    }
}
