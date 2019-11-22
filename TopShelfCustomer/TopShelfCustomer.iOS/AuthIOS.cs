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

        public async Task<string> LoginWithEmailPassword( string email, string password ) {
            try {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync( email, password );
                return await user.User.GetIdTokenAsync();
            } catch ( Exception e ) {
                Debug.WriteLine( e.StackTrace );
                return "";
            }

        }
    }
}
