using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Services;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    public class ProfileSettingsViewModel : BaseViewModel {

        #region Properties

        public User CurrentUser { get; set; }           //The currently logged in User

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

        private string userAddress;       //The User's "Street address"

        public string UserAddress {
            get {
                return userAddress;
            }
            set {
                userAddress = value;
                OnPropertyChanged( "UserAddress" );
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

        private int userZipCode;       //The User's Zip Code

        public int UserZipCode {
            get {
                return userZipCode;
            }
            set {
                userZipCode = value;
                OnPropertyChanged( "UserZipCode" );
            }
        }

        /* Commands */
        public ICommand NavigateBackCommand { get; set; }

        #endregion Properties

        /// <summary>
        /// Constructor
        /// </summary>
        public ProfileSettingsViewModel () {
            Title = "Profile Settings";

            /* Initialize Bindable Properties from the global User */
            UserRealName = UserContainer.CurrentUser.FullName;
            UserEmail = UserContainer.CurrentUser.EmailAddress;
            PhoneNumber = UserContainer.CurrentUser.PhoneNumber;
            UserAddress = UserContainer.CurrentUser.StreetAddress;
            UserZipCode = UserContainer.CurrentUser.ZipCode;

            /* Intialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );
        }
    }
}