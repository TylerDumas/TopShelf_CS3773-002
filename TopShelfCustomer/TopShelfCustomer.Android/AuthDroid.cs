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
    }
}
