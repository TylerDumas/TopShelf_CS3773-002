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
    public class HomeViewModel : BaseViewModel {

        #region Properties

        public string UserName { get; private set; }
        public string UserStore { get; set; }

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
            temp.UserStoreName = "HEB DeZavala Road, San Antonio, TX, 78249";
            UserName = temp.Name;
            UserStore = temp.UserStoreName;

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
