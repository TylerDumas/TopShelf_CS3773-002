using System;
using System.Windows.Input;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// AboutViewModel:
    ///
    /// ViewModel for the About view.
    /// Allows the About view to communicate with the Model classes
    /// </summary>
    public class AboutViewModel : BaseViewModel {

        #region Properties

            public ICommand OpenWebCommand { get; }
            public ICommand OpenHomePage { get; }

        #endregion

        #region Class Methods

            /// <summary>
            /// Constructor
            /// </summary>
            public AboutViewModel() {
                Title = "About";

                OpenHomePage = new Command( LaunchHomePage );
                OpenWebCommand = new Command( () => Device.OpenUri( new Uri( "https://xamarin.com/platform" ) ) );
            }

            /// <summary>
            /// LaunchHomePage:
            ///
            /// Changes the Applications current page to the Home page
            /// </summary>
            void LaunchHomePage() {
                Application.Current.MainPage = new HomePage();
            }

        #endregion
    }
}