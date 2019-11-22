﻿using System.Windows.Input;
using Xamarin.Forms;
using TopShelfCustomer.Views;
using TopShelfCustomer.Services;
using System.ComponentModel;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// LoginViewModel:
    ///
    /// ViewModel for the Login page
    /// Allows the user interface to connect to the model classes directly
    /// </summary>
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

        IFirebaseAuthenticator auth;        //Firebase Authenticator to be resolved for each platform

        public string EmailInput { get; set; }      //E-mail and Password String values
        public string PasswordInput { get; set; }

        private bool isErrorVisible = false;        //Bool to define whether the "incorrect username" message should be shown
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
                
        #endregion

        #region Class Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginViewModel() {
            Title = "Welcome to TopShelf";

            auth = DependencyService.Resolve<IFirebaseAuthenticator>();     //Fetch platform-specific Firebase Authentication implementation
            LoginCommand = new Command( LoginClicked );     //Bind Command to Login Function
            CreateNewAccountCommand = new Command( () => App.SetCurrentPage<CreateNewAccountView>() );
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
