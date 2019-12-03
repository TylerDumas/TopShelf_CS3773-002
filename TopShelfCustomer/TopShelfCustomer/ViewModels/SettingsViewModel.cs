using System;
using System.Windows.Input;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// SettingsViewModel
    ///
    /// ViewModel for the Settings View.
    /// Allows the settings to communicate with the model classes.
    /// </summary>
    public class SettingsViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        JObject jsonObject = new JObject();     //Re-usable JSON object

        private string userRealName;            //String to define the User's name. (Bound to Text fields)
        public string UserRealName {
            get => userRealName;
            set {
                userRealName = value;
                OnPropertyChanged( "UserRealName" );
            }
        }

        private bool isReceiptSwitchToggled;     //Bool to define whether the "save receipts" setting is toggled
        public bool IsReceiptSwitchToggled {
            get => isReceiptSwitchToggled;
            set {
                isReceiptSwitchToggled = value;
                ToggleSwitchSetting( UserSettings.SettingTypes.SaveReceiptsSetting.ToString(), isReceiptSwitchToggled );
                OnPropertyChanged( "IsReceiptSwitchToggled" );
            }
        }

        private bool isLinkSwitchToggled;       //Bool to define whether the "external links" setting is toggled
        public bool IsLinkSwitchToggled {
            get => isLinkSwitchToggled;
            set {
                isLinkSwitchToggled = value;
                ToggleSwitchSetting( UserSettings.SettingTypes.AllowExternalLinks.ToString(), isLinkSwitchToggled );
                OnPropertyChanged( "IsLinkSwitchToggled" );
            }
        }

        /* Commands */
        public ICommand NavigateBackCommand { get; }        //Command for the back button
        public ICommand OpenProfileViewCommand { get; }         //Command to open Profile settings
        public ICommand OpenNotificationsViewCommand { get; }       //Command to open the Notification settings
        public ICommand OpenAboutViewCommand { get; }     //Command to open the About page
        public ICommand OpenSupportViewCommand { get; }        //Command to open the Support page
        public ICommand OpenLicenseViewCommand { get; }       //Command to open the End-User agreement
        public ICommand LogoutUserCommand { get; }      //Command to log out the current User

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsViewModel() {
            Title = "Settings";         //Set the View title
            userRealName = UserContainer.CurrentUser.FullName;     //FIXME: implement a global user class
            InitializeBindableProperties();       //Initialize the properties seen on the UI

            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );
            OpenProfileViewCommand = new Command( () => App.SetCurrentPage<ProfileSettingsPage>() );
            OpenNotificationsViewCommand = new Command( () => App.SetCurrentPage<NotificationsSettingsPage>() );
            OpenAboutViewCommand = new Command( () => App.SetCurrentPage<AboutPage>() ) ;
            OpenSupportViewCommand = new Command( () => Launcher.OpenAsync( new Uri( "https://www.youtube.com/watch?v=dQw4w9WgXcQ" ) ) );       //FIXME: Get rid of the Astley
            OpenLicenseViewCommand = new Command( () => App.SetCurrentPage<LicenseView>() );
            LogoutUserCommand = new Command( () => App.ClearAppData() );
        }

        /// <summary>
        /// ToggleSwitchSetting:
        ///
        /// Takes the name of a UserSettings property and a value,
        /// then finds that property by name and sets it to value.
        /// Then writes the modified userSettings object to user settings file as JSON.
        /// </summary>
        /// <param name="settingProperty"> The name of the property to set on userSettings </param>
        /// <param name="value"> The bool value to assign the property </param>
        void ToggleSwitchSetting( string settingProperty, bool value ) {
            Type objectType = SettingsContainer.CurrentUserSettings.GetType();      //Get the Type of both userSettings
            PropertyInfo objectPropertyInfo = objectType.GetProperty( settingProperty );        //Get the property to set from UserSettings

            if ( objectPropertyInfo != null && objectPropertyInfo.CanWrite ) {
                objectPropertyInfo.SetValue( SettingsContainer.CurrentUserSettings, value, null );      //Set the value of userSettings
            }
            string userSettingsPath = SettingsContainer.SettingsFilePath + UserContainer.CurrentUser.Id;        //Modify path to set this User's settings
            jsonObject = JObject.FromObject( SettingsContainer.CurrentUserSettings );        //Create JSON object from userSettings
            SerializationHelper.JsonWrite( userSettingsPath, jsonObject.ToString() );       //Write the JSON object to the settings file
        }

        /// <summary>
        /// InitializeBindableProperties:
        ///
        /// This method is called when this view is initialized.
        /// It is used to set the values of the bindable properties
        /// used in the view.
        /// </summary>
        void InitializeBindableProperties() {
            isReceiptSwitchToggled = SettingsContainer.CurrentUserSettings.SaveReceiptsSetting;
            isLinkSwitchToggled = SettingsContainer.CurrentUserSettings.AllowExternalLinks;
        }

        #endregion
    }
}