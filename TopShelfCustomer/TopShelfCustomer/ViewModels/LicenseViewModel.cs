using System;
using System.Windows.Input;
using System.Diagnostics;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using Xamarin.Forms;
using System.ComponentModel;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// LicenseViewModel:
    ///
    /// ViewModel for the License View.
    /// Allows the license to communicate with the model classes.
    /// Also allows binding between XAML properties and code.
    /// </summary>
    public class LicenseViewModel {

        #region Properties

        /* Commands */
        public ICommand IconLinkCommand { get; set; }       //Command for opening link to Icons8.com
        public ICommand OpenSettingsViewCommand { get; set; }           //Command for going back to settings view (back button)

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public LicenseViewModel() {

            /* Initialize Commands */
            IconLinkCommand = new Command( () => Device.OpenUri( new Uri( "https://www.icons8.com" ) ) );
            OpenSettingsViewCommand = new Command( () => Application.Current.MainPage = new SettingsPage() );
        }
    }
}
