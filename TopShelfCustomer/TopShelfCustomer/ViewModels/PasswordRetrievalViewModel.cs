using System.ComponentModel;
using System.Windows.Input;
using TopShelfCustomer.Services;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// PasswordRetrievalViewModel:
    ///
    /// ViewModel for the Password Retrieval page
    /// Allows the user interface to connect to the model classes directly
    /// </summary>
    public sealed class PasswordRetrievalViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        private readonly IFirebaseAuthenticator auth;        //Firebase Authenticator to be resolved for each platform

        public string EmailInput { get; set; }      //String value of Email field

        private bool isErrorVisible;       //Bool to trigger error message

        public bool IsErrorVisible {
            get {
                return isErrorVisible;
            }
            set {
                isErrorVisible = value;
                OnPropertyChanged( "IsErrorVisible" );
            }
        }

        public ICommand NavigateBackCommand { get; }        //Command for back button
        public ICommand RequestPasswordResetCommand { get; }        //Command for password request button

        #endregion Properties

        /// <summary>
        /// Constructor
        /// </summary>
        public PasswordRetrievalViewModel () {
            Title = "Reset Password";

            auth = DependencyService.Resolve<IFirebaseAuthenticator>();     //Fetch platform-specific Firebase Authentication implementation

            /* Initialize Commands */
            NavigateBackCommand = new Command( () => App.SetNewPage<LoginPage>() );
            RequestPasswordResetCommand = new Command( ForgotPasswordClicked );
        }

        /// <summary>
        /// ForgotPasswordClicked:
        ///
        /// Function to bind to Command delegate.
        /// Controls the "Request Email" button in the password retrieval view
        /// </summary>
        private async void ForgotPasswordClicked () {
            string complete = await auth.RequestPasswordReset( EmailInput );
            if ( complete != "" ) {
                App.SetNewPage<LoginPage>();
            } else {
                IsErrorVisible = true;
            }
        }
    }
}