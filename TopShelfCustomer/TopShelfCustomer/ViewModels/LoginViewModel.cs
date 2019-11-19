using System.Windows.Input;
using Xamarin.Forms;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// LoginViewModel:
    ///
    /// ViewModel for the Login page
    /// Allows the interface to connect to the model classes directly
    /// </summary>
    public class LoginViewModel : BaseViewModel {

        #region Properties

            public ICommand LoginCommand { get; }

        #endregion

        #region Class Methods

            /// <summary>
            /// Constructor
            /// </summary>
            public LoginViewModel() {
                Title = "Welcome to TopShelf";

                LoginCommand = new Command( () => Application.Current.MainPage = new HomePage() );
            }

        #endregion
    }
}
