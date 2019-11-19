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
        public ICommand OpenSettingsCommand { get; }

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public AboutViewModel() {
            Title = "About";

            OpenSettingsCommand = new Command( LaunchSettingsPage );
            OpenWebCommand = new Command( () => Device.OpenUri( new Uri( "https://xamarin.com/platform" ) ) );
        }

        /// <summary>
        /// LaunchSettingsPage:
        ///
        /// Changes the Applications current page to the Settings page
        /// </summary>
        void LaunchSettingsPage() {
            Application.Current.MainPage = new SettingsPage();
        }

        #endregion
    }
}