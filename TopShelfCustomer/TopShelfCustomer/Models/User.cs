namespace TopShelfCustomer.Models {

    /// <summary>
    /// User:
    ///
    /// Model class to represent a User profile.
    /// Used to populate menus with specific user data
    /// </summary>
    public class User {
        /// <summary>
        /// Id: The unique id number for the User.
        /// </summary>
        public int Id { get; set; } = 0;
        /// <summary>
        /// FullName: The first and last name of the User.
        /// </summary>
        public string FullName { get; set; } = "";
        /// <summary>
        /// EmailAddress: The email address string for the User.
        /// </summary>
        public string EmailAddress { get; set; } = "";
        /// <summary>
        /// PhoneNumber: The string representation of the User's phone number.
        /// </summary>
        public string PhoneNumber { get; set; } = "";
        /// <summary>
        /// StreetAddress: The physical address of the User.
        /// </summary>
        public string StreetAddress { get; set; } = "";
        /// <summary>
        /// StoreName: The shortened name of the User's home store.
        /// </summary>
        public string StoreName { get; set; } = "";
    }
}
