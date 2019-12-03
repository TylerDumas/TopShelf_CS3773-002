using System;
using TopShelfCustomer.Models;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// UserContainer:
    ///
    /// Contains the global User.
    /// Allows access to and modification of the currently logged-in
    /// User.
    /// </summary>
    public static class UserContainer {

        public static User CurrentUser { get; set; }        //Global User property

    }
}
