using Firebase.Auth;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TopShelfCustomer.Droid;
using TopShelfCustomer.Services;
using Xamarin.Forms;

[assembly: Dependency( typeof( AuthDroid ) )]

namespace TopShelfCustomer.Droid {

    public class AuthDroid : IFirebaseAuthenticator {

        /// <summary>
        /// LoginWithEmailPassword:
        ///
        /// Takes email and password strings and logs into Firebase with them.
        /// Returns UserID token on success, and empty string on failure
        /// </summary>
        /// <param name="email"> Email address </param>
        /// <param name="password"> Password </param>
        /// <returns> User ID token </returns>
        public async Task<string> LoginWithEmailPassword ( string email, string password ) {
            try {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync( email, password );
                var token = await user.User.GetIdTokenAsync( false );
                if ( user == null || token == null ) {
                    Debug.WriteLine( "Failed to log in" );
                }
                return token.Token;
            } catch ( FirebaseAuthInvalidUserException e ) {
                Debug.WriteLine( e.Message );
                return "";
            } catch ( Exception ex ) {
                Debug.WriteLine( ex.Message );
                return "";
            }
        }

        /// <summary>
        /// RegisterWithEmailPassword"
        ///
        /// Takes email and password strings and registers a Firebase account with them.
        /// </summary>
        /// <param name="email"> Email Address </param>
        /// <param name="password"> Password </param>
        /// <returns> User ID token </returns>
        public async Task<string> RegisterWithEmailPassword ( string email, string password ) {
            try {
                var signUpTask = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync( email, password );
                if ( signUpTask != null ) {
                    return signUpTask.ToString();
                }
                return "";
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return "";
            }
        }

        /// <summary>
        /// RequestPasswordReset:
        ///
        /// Asynchronous method to send "Password Reset" email to the user.
        /// </summary>
        /// <param name="email"> The E-mail to send the request to </param>
        /// <returns> Task of type string, describing the exit status of the request </returns>
        public async Task<string> RequestPasswordReset ( string email ) {
            try {
                await FirebaseAuth.Instance.SendPasswordResetEmailAsync( email );
                return "success";
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return "";
            }
        }

        /// <summary>
        /// LogoutCurrentUser:
        ///
        /// Asynchronout method to Logout any current Users.
        /// </summary>
        /// <returns> Task object describing the success of the SignOut() call </returns>
        public string LogoutCurrentUser () {
            if ( FirebaseAuth.Instance.CurrentUser != null ) {
                try {
                    FirebaseAuth.Instance.SignOut();
                    return "Success";
                } catch ( Exception ex ) {
                    Debug.WriteLine( ex.Message );
                    return "";
                }
            }
            return "";
        }
    }
}