using System.ComponentModel;
using System.Windows.Input;
using TopShelfCustomer.Models;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// HomeViewModel:
    ///
    /// ViewModel for the Home page
    /// Allows the interface to connect to the model classes directly
    /// </summary>
    public class HomeViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        public string UserRealName { get; private set; }        //The current User's real name
        private string userStoreName;       //String representation of this User's default Store
        public string UserStoreName {
            get {
                return userStoreName;
            }
            set {
                userStoreName = value;
                OnPropertyChanged( "UserStoreName" );
            }
        }
        public Store UserStore { get; set; }

        public ICommand OpenSettingsView { get; private set; }
        public ICommand OpenCreateOrderView { get; }

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeViewModel() {
            Title = "Home";

            /* Temporary User to test name display */
            User temp = new User();
            temp.Name = "Jackson Dumas";
            temp.UserStore = new Store( "HEB De-Zavala", "DeZavala Road, San Antonio, TX, 78249" );
            UserRealName = temp.Name;
            UserStore = temp.UserStore;
            UserStoreName = UserStore.StoreName;

            OpenSettingsView = new Command( LaunchSettingsPage );
            OpenCreateOrderView = new Command( LaunchCreateOrderPage );
        }

        void LaunchSettingsPage() {
            Application.Current.MainPage = new SettingsPage();
        }

        void LaunchCreateOrderPage() {
            Application.Current.MainPage = new CreateOrderPage();
        }

        #endregion
    }
}
