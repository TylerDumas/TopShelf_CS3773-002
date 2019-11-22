using System;
using System.Threading.Tasks;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// FirebaseAuthenticator:
    ///
    /// FIXME: Implement Authentication class
    /// </summary>
    public class FirebaseAuthenticator {
        
    }

    /// <summary>
    /// IFirebaseAuthenticator:
    ///
    /// Firebase Authentication abstraction to allow separate, platform-dependent implementations.
    /// 
    /// </summary>
    public interface IFirebaseAuthenticator {
        Task<string> LoginWithEmailPassword( string email, string password );
        bool RegisterWithEmailPassword( string email, string password );
    }
}
