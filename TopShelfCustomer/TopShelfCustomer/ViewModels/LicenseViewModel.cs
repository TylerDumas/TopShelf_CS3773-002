using System.Windows.Input;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// LicenseViewModel:
    ///
    /// ViewModel for the License View.
    /// Allows the license view to communicate with the model classes.
    /// Also allows binding between XAML properties and code.
    /// </summary>
    public class LicenseViewModel : BaseViewModel {

        #region Properties

        /* Commands */
        public ICommand NavigateBackCommand { get; set; }           //Command for going back to settings view (back button)

        #endregion Properties

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LicenseViewModel () {
            Title = "Licenses";

            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetCurrentPage<SettingsPage>() );
        }

        #endregion Class Methods
    }
}