using System;
using System.Threading.Tasks;
using TopShelfCustomer;
using TopShelfCustomer.iOS;
using TopShelfCustomer.Services;
using Xamarin.Forms;
using Firebase.Auth;
using System.Diagnostics;

[assembly: Dependency( typeof( AuthIOS ) )]
namespace TopShelfCustomer.iOS {

    public class AuthIOS : IFirebaseAuthenticator {

        /// <summary>
        /// LoginWithEmailPassword:
        ///
        /// Takes email and password strings and logs into Firebase with them.
        /// Returns UserID token on success, and empty string on failure
        /// </summary>
        /// <param name="email"> Email address </param>
        /// <param name="password"> Password </param>
        /// <returns> User ID token </returns>
        public async Task<string> LoginWithEmailPassword( string email, string password ) {
            try {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync( email, password );
                return await user.User.GetIdTokenAsync();
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
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
        public async Task<string> RegisterWithEmailPassword( string email, string password ) {
            try {
                var signUpTask = await Auth.DefaultInstance.CreateUserAsync( email, password );
                var result = await signUpTask.User.GetIdTokenResultAsync();
                if( result.Token != "" ) {
                    return result.Token;
                } else {
                    return "";
                }
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
        public async Task<string> RequestPasswordReset( string email ) {
            try {
                await Auth.DefaultInstance.SendPasswordResetAsync( email );
                return "Success";
            }catch( Exception e ) {
                Debug.WriteLine( e.Message );
                return "";
            }
        }
    }
}
