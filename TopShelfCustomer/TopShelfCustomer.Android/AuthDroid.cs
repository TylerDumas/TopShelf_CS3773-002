using System;
using System.Threading.Tasks;
using TopShelfCustomer;
using TopShelfCustomer.Droid;
using Firebase.Auth;
using Xamarin.Forms;
using TopShelfCustomer.Services;

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
        public async Task<string> LoginWithEmailPassword( string email, string password ) {
            try {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync( email, password );
                var token = await user.User.GetIdTokenAsync( false );
                return token.Token;
            } catch ( FirebaseAuthInvalidUserException e ) {
                e.PrintStackTrace();
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
                var signUpTask = FirebaseAuth.Instance.CreateUserWithEmailAndPassword( email, password );
                return signUpTask.Result != null;
            } catch ( Exception e ) {
                return false;
            }
        }
    }
}
