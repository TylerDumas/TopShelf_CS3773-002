using Newtonsoft.Json.Linq;
using TopShelfCustomer.Models;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// SettingsContainer:
    ///
    /// Static Settings manager. Holds a global UserSettings instance
    /// to allow for all views to access the user settings.
    /// </summary>
    public static class SettingsContainer {
        public static string SettingsFilePath { get => "UserSetting"; }     //The filename of the settings file (with no extension)
        public static UserSettings CurrentUserSettings { get; set; }       //global settings instance

        /// <summary>
        /// Constructor
        /// </summary>
        static SettingsContainer () {
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
        private static void InitializeUserSettings () {
            string currentUserSettingsPath = SettingsFilePath + UserContainer.CurrentUser.Id;       //Modify path to use current User's settings
            if ( SerializationHelper.JsonFileExists( currentUserSettingsPath ) ) {      //Check if JSON file exists
                CurrentUserSettings = (UserSettings)SerializationHelper.JsonRead<UserSettings>( currentUserSettingsPath );      //Read JsonFile and populate UserSettings object
            } else {
                JObject jsonObject = JObject.FromObject( CurrentUserSettings );     //Add blank UserSetting object to jsonObject
                SerializationHelper.JsonWrite( currentUserSettingsPath, jsonObject.ToString() );       //Write the blank UserSettings to the Settings file
            }
        }

        /// <summary>
        /// ClearSettings:
        ///
        /// Clears the global UserSettings object.
        /// Functions as a helper method for the "log out"
        /// functionality.
        /// </summary>
        public static void ClearSettings () {
            CurrentUserSettings = new UserSettings();
        }
    }
}