using System.Windows.Input;
using Xamarin.Forms;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using TopShelfCustomer.Services;
using System.ComponentModel;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// LoginViewModel:
    ///
    /// ViewModel for the Login page
    /// Allows the interface to connect to the model classes directly
    /// </summary>
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        IFirebaseAuthenticator auth;
        public string EmailInput { get; set; }
        public string PasswordInput { get; set; }
        private bool isErrorVisible = false;
        public bool IsErrorVisible {
            get {
                return isErrorVisible;
            }
            set {
                isErrorVisible = value;
                OnPropertyChanged( "IsErrorVisible" );
            }
        }
        public ICommand LoginCommand { get; }

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginViewModel() {
            Title = "Welcome to TopShelf";

            //FIXME:

            auth = DependencyService.Resolve<IFirebaseAuthenticator>();
            LoginCommand = new Command( LoginClicked );
        }

        async void LoginClicked() {
            string token = await auth.LoginWithEmailPassword( EmailInput, PasswordInput );
            if( token != "" ) {
                App.SetCurrentPage<HomePage>();
            } else {
                Debug.WriteLine( $"token: {token}" );
                ShowError();
            }
            Debug.WriteLine( $"Email: {EmailInput}" );
            Debug.WriteLine( $"Password: {PasswordInput}" );
        }

        void ShowError() {
            isErrorVisible = true;
        }

        #endregion
    }
}
