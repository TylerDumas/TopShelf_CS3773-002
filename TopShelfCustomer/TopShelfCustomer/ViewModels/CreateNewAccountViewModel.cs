using System;
using System.Windows.Input;
using System.Diagnostics;
using TopShelfCustomer.Views;
using TopShelfCustomer.Models;
using Xamarin.Forms;
using System.ComponentModel;
using TopShelfCustomer.Services;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// CreateNewAccountViewModel:
    ///
    /// ViewModel for the Create New Account page
    /// Allows the user interface to connect to the model classes directly
    /// </summary>
    public class CreateNewAccountViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        IFirebaseAuthenticator auth;        //Firebase Authenticator to be resolved for each platform

        public string UsernameInput { get; set; }       //Entry Text Properties
        public string EmailInput { get; set; }
        public string PasswordInput { get; set; }

        private bool isErrorOnCreation = false;       //Bool to trigger "invalid input" error message
        public bool IsErrorOnCreation {
            get {
                return isErrorOnCreation;
            }
            set {
                isErrorOnCreation = value;
                OnPropertyChanged( "IsErrorOnCreation" );
            }
        }

        public ICommand OpenLoginCommand { get; set; }       //Command to go back to the Log in screen
        public ICommand ConfirmNewAccountCommand { get; set; }      //Command to confirm new account

        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateNewAccountViewModel() {

            auth = DependencyService.Resolve<IFirebaseAuthenticator>();     //Fetch platform-specific Firebase Authentication implementation

            OpenLoginCommand = new Command( () => App.SetCurrentPage<LoginPage>() );
            ConfirmNewAccountCommand = new Command( ConfirmNewAccount );
        }

        /// <summary>
        /// ConfirmNewAccount:
        ///
        /// Uses platform-specific implementation of Firebase to create/register a new account
        /// </summary>
        void ConfirmNewAccount() {
            if( EmailInput != "" && PasswordInput != "" ) {     //Check if Email and Password are valid
                bool success = auth.RegisterWithEmailPassword( EmailInput, PasswordInput );
                App.SetCurrentPage<HomePage>();
                //FIXME: Add Registration Verification/Exception handling
            } else {
                Debug.WriteLine( "Failed to register account" );
                IsErrorOnCreation = true;
            }
            
        }

        #endregion
    }
}
