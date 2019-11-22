using System.Windows.Input;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// CreateOrderViewModel
    ///
    /// ViewModel for the CreateOrder View.
    /// Allows the settings to communicate with the model classes.
    /// </summary>
    public class CreateOrderViewModel : BaseViewModel {

        #region Properties

        public ICommand NavigateBackCommand { get; }        //Command to open home page (back button)

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateOrderViewModel() {
            Title = "Create New Order";

            NavigateBackCommand = new Command( () => App.SetCurrentPage<HomePage>() );
        }

        #endregion
    }
}
