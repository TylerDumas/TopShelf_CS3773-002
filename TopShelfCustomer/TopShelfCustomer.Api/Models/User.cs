using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopShelfCustomer.Api.Models {

    /// <summary>
    /// User:
    /// 
    /// API Model for a user entry in the database.
    /// All API requests to the /api/User endpoint 
    /// will return this as a JSON string object.
    /// </summary>
    public class User {

        public int Id { get; set; } = 0;

        public string FullName { get; set; } = "";

        public string EmailAddress { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string StreetAddress { get; set; } = "";

        public string StoreName { get; set; } = "";

    }
}