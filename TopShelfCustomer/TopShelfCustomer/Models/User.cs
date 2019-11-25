using System;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// User:
    ///
    /// Model class to represent a User profile.
    /// Used to populate menus with specific user data
    /// </summary>
    public class User {

        public string Name { get; set; }
        public string Email { get; set; }
        public Store UserStore { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public User() {

        }

        /// <summary>
        /// Constructor Overload
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="userStore"></param>
        /// <param name="phoneNumber"></param>
        public User( string fullName, string email, Store userStore, string phoneNumber ) {
            Name = fullName;
            Email = email;
            UserStore = userStore;
            PhoneNumber = phoneNumber;
        }
    }
}
