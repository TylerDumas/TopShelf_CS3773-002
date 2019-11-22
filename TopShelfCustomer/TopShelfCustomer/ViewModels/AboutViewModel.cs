using System;
using System.Windows.Input;
using TopShelfCustomer.Views;
using Xamarin.Essentials;
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

        /* Commands */
        public ICommand OpenXamarinCommand { get; }     //Command to open Xamarin framework website
        public ICommand NavigateBackCommand { get; }        //Command to navigate back to last page

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public AboutViewModel() {
            Title = "About";

            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );
            OpenXamarinCommand = new Command( () => Launcher.OpenAsync( new Uri( "https://xamarin.com/platform" ) ) );
        }

        #endregion
    }
}