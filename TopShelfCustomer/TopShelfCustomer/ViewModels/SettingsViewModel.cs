using System;
using System.Windows.Input;
using System.Diagnostics;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using Xamarin.Forms;
using System.ComponentModel;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// SettingsViewModel
    ///
    /// ViewModel for the Settings View.
    /// Allows the settings to communicate with the model classes.
    /// </summary>
    public class SettingsViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        public User CurrentUser { get; set; }           //The currently logged in User

        private string userRealName;            //String to define the User's name. (Bound to Text fields)
        public string UserRealName {
            get {
                return userRealName;
            }
            set {
                userRealName = value;
                OnPropertyChanged( "UserRealName" );
            }
        }

        private bool isLinkSwitchToggled = true;       //Bool to define whether the "external links" setting is toggled
        public bool IsLinkSwitchToggled {
            get {
                return isLinkSwitchToggled;
            }
            set {
                isLinkSwitchToggled = value;
                ToggleExternalLinkSetting( isLinkSwitchToggled );
                OnPropertyChanged( "IsLinkSwitchToggled" );
            }
        }

        /* Commands */
        public ICommand OpenHomePageCommand { get; }        //Command to open home page (back button)
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
            CurrentUser = new User {
                Name = "Jackson Dumas"
            };
            Title = "Settings";
            UserRealName = CurrentUser.Name;

            OpenHomePageCommand = new Command( () => Application.Current.MainPage = new HomePage() );
            OpenProfileViewCommand = new Command( () => Application.Current.MainPage = new ProfileSettingsPage() );
            OpenNotificationsViewCommand = new Command( () => Application.Current.MainPage = new NotificationsSettingsPage() );
            OpenAboutViewCommand = new Command( () => Application.Current.MainPage = new AboutPage() ) ;
            OpenSupportViewCommand = new Command( () => Device.OpenUri( new Uri( "https://www.youtube.com/watch?v=dQw4w9WgXcQ" ) ) );       //FIXME: Get rid of the Astley
            OpenLicenseViewCommand = new Command( () => Application.Current.MainPage = new LicenseView() );
            LogoutUserCommand = new Command( LogoutUser );
        }

        /// <summary>
        /// LogoutUser:
        ///
        /// Logs out the current User
        /// </summary>
        void LogoutUser() {
            CurrentUser = null;
            Application.Current.MainPage = new LoginPage();
        }

        /// <summary>
        /// ToggleExternalLinkSetting:
        ///
        /// Handles the Toggling of the "External Link" setting in the root settings menu
        /// </summary>
        /// <param name="isToggled"> if the toggle was activated or deactivated </param>
        void ToggleExternalLinkSetting( bool isToggled ) {
            //TODO: Implement Settings to User Profile
            Debug.WriteLine( $"Toggled the External Link Setting to {isToggled}" );
        }

        #endregion
    }
}