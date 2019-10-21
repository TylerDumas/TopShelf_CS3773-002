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

        public string UserName { get; private set; }

        public ICommand OpenAboutView { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public HomeViewModel() {
            Title = "Home";

            /* Temporary User to test name display */
            User temp = new User();
            temp.Name = "Dirk Diggler";
            UserName = temp.Name;

            OpenAboutView = new Command( LaunchAboutPage );
        }

        /// <summary>
        /// LaunchAboutPage:
        ///
        /// Launches the AboutPage view
        /// </summary>
        void LaunchAboutPage() {
            Application.Current.MainPage = new AboutPage();
        }
    }
}
