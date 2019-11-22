using System;
using System.Windows.Input;
using TopShelfCustomer.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// LicenseViewModel:
    ///
    /// ViewModel for the License View.
    /// Allows the license view to communicate with the model classes.
    /// Also allows binding between XAML properties and code.
    /// </summary>
    public class LicenseViewModel : BaseViewModel{

        #region Properties

        /* Commands */
        public ICommand OpenSettingsViewCommand { get; set; }           //Command for going back to settings view (back button)

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LicenseViewModel() {
            Title = "Licenses";

            /* Initialize Commands */
            OpenSettingsViewCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );
        }

        #endregion
    }
}
