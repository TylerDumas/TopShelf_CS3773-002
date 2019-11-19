using System;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// User:
    ///
    /// Model class to represent a User profile.
    /// Used to populate menus with specific user data
    /// </summary>
    public class User {

        public string Username { get; set; }        //The User's Username
        public string Name { get; set; }
        public string Email { get; set; }
        public Store UserStore { get; set; }
        public string PhoneNumber { get; set; }
    }
}
