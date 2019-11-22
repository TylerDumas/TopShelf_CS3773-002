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
        public bool RegisterWithEmailPassword( string email, string password ) {
            try {
                var signUpTask = Auth.DefaultInstance.CreateUserAsync( email, password );
                return signUpTask.Result != null;
            } catch ( Exception e ) {
                return false;
            }
        }
    }
}
