using System.ComponentModel;
using System.Windows.Input;
using TopShelfCustomer.Views;
using TopShelfCustomer.Services;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// LoginViewModel:
    ///
    /// ViewModel for the Login page
    /// Allows the user interface to connect to the model classes directly
    /// </summary>
    public sealed class LoginViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        readonly IFirebaseAuthenticator auth;        //Firebase Authenticator to be resolved for each platform

        public string EmailInput { get; set; }      //E-mail and Password String values
        public string PasswordInput { get; set; }

        private bool isIncorrectInfo;        //Bool to define whether the "incorrect username" message should be shown
        public bool IsIncorrectInfo {
            get {
                return isIncorrectInfo;
            }
            set {
                isIncorrectInfo = value;
                OnPropertyChanged( "IsIncorrectInfo" );
            }
        }
        private bool isErrorVisible;        //Bool to define whether the "incorrect username" message should be shown
        public bool IsErrorVisible {
            get {
                return isErrorVisible;
            }
            set {
                isErrorVisible = value;
                OnPropertyChanged( "IsErrorVisible" );
            }
        }
        public ICommand LoginCommand { get; }       //The Command bound to the Login button
        public ICommand CreateNewAccountCommand { get; }        //Command for create new account link
        public ICommand ForgotPasswordCommand { get; }      //Command for the "forgot password" link
                
        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginViewModel() {
            Title = "Welcome to TopShelf";

            auth = DependencyService.Resolve<IFirebaseAuthenticator>();     //Fetch platform-specific Firebase Authentication implementation
            LoginCommand = new Command( LoginClicked );     //Bind Command to Login Function
            CreateNewAccountCommand = new Command( () => App.SetNewPage<CreateNewAccountView>() ) ;
            ForgotPasswordCommand = new Command( () => App.SetNewPage<PasswordRetrievalView>() );
        }

        /// <summary>
        /// LoginClicked:
        ///
        /// Asynchronous function to handle the Log In button's
        /// click event. Calls on Firebase Authentication
        /// to Authenticate the User and log into the Application
        /// </summary>
        async void LoginClicked() {
            string token = await auth.LoginWithEmailPassword( EmailInput, PasswordInput );
            if( token != "" ) {
                App.SetCurrentPage<HomePage>();
            } else {
                IsErrorVisible = true;
            }
        }

        #endregion
    }
}
