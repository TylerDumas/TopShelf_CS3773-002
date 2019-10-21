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

            public ICommand OpenAboutView { get; private set; }

        #endregion

        #region Class Methods

            /// <summary>
            /// Constructor
            /// </summary>
            public HomeViewModel() {
                Title = "Home";

                /* Temporary User to test name display */
                User temp = new User();
                temp.Name = "Dirk Diggler";
                temp.UserStoreName = "HEB DeZavala Road, San Antonio, TX, 78249";
                UserName = temp.Name;
                UserStore = temp.UserStoreName;

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

        #endregion
    }
}
