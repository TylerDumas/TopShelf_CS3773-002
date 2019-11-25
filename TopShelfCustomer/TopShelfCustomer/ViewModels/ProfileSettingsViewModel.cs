using System.Windows.Input;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
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
        public ICommand OpenSettingsPageCommand { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public ProfileSettingsViewModel() {
            Title = "Profile Settings";

            User temp = new User {
                Name = "Jackson Dumas",
                Email = "tylerdumas3@hotmail.com",
                PhoneNumber = "210-699-6969"
            };
            UserRealName = temp.Name;
            UserEmail = temp.Email;
            PhoneNumber = temp.PhoneNumber;

            OpenSettingsPageCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );

        }
    }
}
