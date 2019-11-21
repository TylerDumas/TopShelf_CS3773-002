using System;
using System.Windows.Input;
using System.Diagnostics;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using Xamarin.Forms;
using System.ComponentModel;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// NotificationsViewModel:
    ///
    /// Allows the Notifications Settings View to communicate with the model classes.
    /// Also allows binding between XAML properties and code.
    /// </summary>
    public class NotificationsViewModel : BaseViewModel {

        #region Properties

        public User CurrentUser { get; set; }           //The currently logged in User

        private string userName;        //The user's "username"
        public string UserName {
            get {
                return userName;
            }
            set {
                userName = value;
                OnPropertyChanged( "UserName" );
            }
        }

        private string userRealName;            //String to define the User's real name. (Bound to Text fields)
        public string UserRealName {
            get {
                return userRealName;
            }
            set {
                userRealName = value;
                OnPropertyChanged( "UserRealName" );
            }
        }

        private string userEmail;       //The User's "Email address"
        public string UserEmail {
            get {
                return userEmail;
            }
            set {
                userEmail = value;
                OnPropertyChanged( "UserEmail" );
            }
        }

        private string phoneNumber;       //The User's Phone Number
        public string PhoneNumber {
            get {
                return phoneNumber;
            }
            set {
                phoneNumber = value;
                OnPropertyChanged( "PhoneNumber" );
            }
        }

        /* Commands */
        public ICommand OpenSettingsViewCommand { get; set; }

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public NotificationsViewModel() {
            Title = "Notifications View";

            User temp = new User {
                Name = "Jackson Dumas",
                Username = "tylerdumas3",
                Email = "tylerdumas3@hotmail.com",
                PhoneNumber = "210-699-6969"
            };
            UserRealName = temp.Name;
            UserName = temp.Username;
            UserEmail = temp.Email;
            PhoneNumber = temp.PhoneNumber;

            /* Command Initialization */
            OpenSettingsViewCommand = new Command( () => Application.Current.MainPage = new SettingsPage() );
        }

        #endregion
    }
}
