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
        private string userName;
        public string UserName {
            get {
                return this.userName;
            }
            set {
                userName = value;
                OnPropertyChanged( "UserName" );
            }
        }
        public ICommand OpenHomePageCommand { get; }        //Command to open home page (back button)
        public ICommand OpenStorageCommand { get; }     //Command to open the Storage settings
        public ICommand OpenNotificationsCommand { get; }       //Command to open the Notification settings
        public ICommand OpenAboutView { get; }     //Command to open the About page
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
            UserName = CurrentUser.Name;

            OpenHomePageCommand = new Command( LaunchHomePage );
            OpenStorageCommand = new Command( OpenStorageSettings );
            OpenAboutView = new Command( LaunchAboutPage );
            OpenNotificationsCommand = new Command( OpenNotificationsSettings );
            LogoutUserCommand = new Command( LogoutUser );
        }

        /// <summary>
        /// LaunchHomePage:
        ///
        /// Changes the Applications current page to the Home page
        /// </summary>
        void LaunchHomePage() {
            Application.Current.MainPage = new HomePage();
        }

        /// <summary>
        /// OpenStorageSettings:
        ///
        /// Opens the Storage Settings within the Settings View
        /// </summary>
        void OpenStorageSettings() {
            Debug.WriteLine( "Opening the Storage Settings!" );
            //TODO: Implement Storage Settings
        }

        /// <summary>
        /// OpenNotificationsSettings:
        ///
        /// Opens the Storage Settings within the Settings View
        /// </summary>
        void OpenNotificationsSettings() {
            Debug.WriteLine( "Opening the Notifications settings!" );
            //TODO: Implement Notifications Settings
        }

        /// <summary>
        /// LaunchAboutPage:
        ///
        /// Launches the AboutPage view
        /// </summary>
        void LaunchAboutPage() {
            Application.Current.MainPage = new AboutPage();
        }

        /// <summary>
        /// LogoutUser:
        ///
        /// Logs out the current User
        /// </summary>
        void LogoutUser() {
            UserName = "None";
            Debug.WriteLine( "Logging Out!" );
            //TODO: Implement Logging out
        }

        #endregion
    }
}
