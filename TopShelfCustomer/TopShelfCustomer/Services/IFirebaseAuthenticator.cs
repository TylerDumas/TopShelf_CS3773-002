using System.Threading.Tasks;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// IFirebaseAuthenticator:
    ///
    /// Firebase Authentication abstraction to allow separate, platform-dependent implementations.
    /// </summary>
    public interface IFirebaseAuthenticator {

        Task<string> LoginWithEmailPassword ( string email, string password );

        Task<string> RegisterWithEmailPassword ( string email, string password );

        Task<string> RequestPasswordReset ( string email );

        string LogoutCurrentUser ();
    }
}