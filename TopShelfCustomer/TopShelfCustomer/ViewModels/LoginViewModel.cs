using System.Windows.Input;
using Xamarin.Forms;
using TopShelfCustomer.Views;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// LoginViewModel:
    ///
    /// ViewModel for the Login page
    /// Allows the interface to connect to the model classes directly
    /// </summary>
    public class LoginViewModel : BaseViewModel {

        public ICommand LoginCommand { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginViewModel() {
            Title = "Welcome to TopShelf";

            LoginCommand = new Command( GoToMainMenu );
        }

        /// <summary>
        /// GoToMainMenu:
        ///
        /// Calls on the Application static class to change views to the Main Application page
        /// </summary>
        void GoToMainMenu() {
            Application.Current.MainPage = new MainPage();
        }
    }
}
