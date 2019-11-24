﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// SettingsViewModel
    ///
    /// ViewModel for the Settings View.
    /// Allows the settings to communicate with the model classes.
    /// </summary>
    public class SettingsViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        readonly IFirebaseAuthenticator auth;        //Firebase Authenticator to be resolved for each platform

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

        private bool isReceiptSwitchToggled;     //Bool to define whether the "save receipts" setting is toggled
        public bool IsReceiptSwitchToggled {
            get {
                return isReceiptSwitchToggled;
            }
            private set {
                isReceiptSwitchToggled = value;
                ToggleReceiptSerializationSetting( isReceiptSwitchToggled );
                OnPropertyChanged( "IsReceiptSwitchToggled" );
            }
        }

        private bool isLinkSwitchToggled;       //Bool to define whether the "external links" setting is toggled
        public bool IsLinkSwitchToggled {
            get {
                return isLinkSwitchToggled;
            }
            private set {
                isLinkSwitchToggled = value;
                ToggleExternalLinkSetting( isLinkSwitchToggled );
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
            Title = "Settings";
            CurrentUser = new User {
                Name = "Jackson Dumas"
            };
            UserRealName = CurrentUser.Name;

            auth = DependencyService.Resolve<IFirebaseAuthenticator>();     //Fetch platform-specific Firebase Authentication implementation

            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );
            OpenProfileViewCommand = new Command( () => App.SetCurrentPage<ProfileSettingsPage>() );
            OpenNotificationsViewCommand = new Command( () => App.SetCurrentPage<NotificationsSettingsPage>() );
            OpenAboutViewCommand = new Command( () => App.SetCurrentPage<AboutPage>() ) ;
            OpenSupportViewCommand = new Command( () => Launcher.OpenAsync( new Uri( "https://www.youtube.com/watch?v=dQw4w9WgXcQ" ) ) );       //FIXME: Get rid of the Astley
            OpenLicenseViewCommand = new Command( () => App.SetCurrentPage<LicenseView>() );
            LogoutUserCommand = new Command( LogoutUser );
        }

        /// <summary>
        /// LogoutUser:
        ///
        /// Logs out the current User
        /// </summary>
        void LogoutUser() {
            CurrentUser = null;
            auth.LogoutCurrentUser();
            App.ClearPages();
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

        /// <summary>
        /// ToggleReceiptSerializationSetting:
        ///
        /// Handles the Toggling of the "Save Receipts" setting in the root settings menu
        /// </summary>
        /// <param name="isToggled"> if the toggle was activated or deactivated </param>
        void ToggleReceiptSerializationSetting( bool isToggled ) {
            //TODO: Implement Settings to User Profile
            Debug.WriteLine( $"Toggled the External Link Setting to {isToggled}" );
        }

        #endregion
    }
}