﻿using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using TopShelfCustomer.Services;
using TopShelfCustomer.Views;
using Xamarin.Forms;

namespace TopShelfCustomer.ViewModels {

    /// <summary>
    /// CreateNewAccountViewModel:
    ///
    /// ViewModel for the Create New Account page
    /// Allows the user interface to connect to the model classes directly
    /// </summary>
    public class CreateNewAccountViewModel : BaseViewModel, INotifyPropertyChanged {

        #region Properties

            private IFirebaseAuthenticator auth;        //Firebase Authenticator to be resolved for each platform

            public string UserRealNameInput { get; set; }       //Entry Text Properties
            public string EmailInput { get; set; }
            public string AddressInput { get; set; }
            public string PasswordInput { get; set; }

            private string creationErrorMessage = "Failed to Create Account";       //Dynamic Error message text

            public string CreationErrorMessage {
                get {
                    return creationErrorMessage;
                }
                set {
                    creationErrorMessage = value;
                    OnPropertyChanged( "CreationErrorMessage" );
                }
            }

            private bool isErrorOnCreation;       //Bool to trigger "invalid input" error message

            public bool IsErrorOnCreation {
                get {
                    return isErrorOnCreation;
                }
                set {
                    isErrorOnCreation = value;
                    OnPropertyChanged( "IsErrorOnCreation" );
                }
            }

            public ICommand NavigateBackCommand { get; }       //Command to go back to the Log in screen
            public ICommand ConfirmNewAccountCommand { get; }      //Command to confirm new account

        #endregion Properties

        #region Class Methods

            /// <summary>
            /// Constructor
            /// </summary>
            public CreateNewAccountViewModel () {
                Title = "Create New Account";

                auth = DependencyService.Resolve<IFirebaseAuthenticator>();     //Fetch platform-specific Firebase Authentication implementation

                NavigateBackCommand = new Command( () => App.SetNewPage<LoginPage>() );
                ConfirmNewAccountCommand = new Command( ConfirmNewAccount );
            }

            /// <summary>
            /// ConfirmNewAccount:
            ///
            /// Uses platform-specific implementation of Firebase to create/register a new account
            /// </summary>
            private async void ConfirmNewAccount () {
                if ( EmailInput != "" && PasswordInput != "" ) {     //Check if Email and Password are valid
                    var success = await auth.RegisterWithEmailPassword( EmailInput, PasswordInput );
                    if ( success != "" ) {
                        Debug.WriteLine( "Successfully created your account" );
                        App.SetNewPage<LoginPage>();
                    } else {
                        Debug.WriteLine( success );
                        CreationErrorMessage = "Failed to register account with firebase";
                        IsErrorOnCreation = true;
                    }
                } else {
                    CreationErrorMessage = "Invalid E-mail or Password";
                    IsErrorOnCreation = true;
                }
            }

        #endregion Class Methods
    }
}