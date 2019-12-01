using System;

namespace TopShelfCustomer.Models {

    /// <summary>
    /// User:
    ///
    /// Model class to represent a User profile.
    /// Used to populate menus with specific user data
    /// </summary>
    public class User {

        public string Id { get; set; }
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string StoreName { get; set; }
        public string PhoneNumber { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
    }
}
