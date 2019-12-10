using System.Collections.Generic;
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
        public static Cart UserCart { get; set; } = new Cart();     //The User's current cart
        public static List<OrderReceipt> Orders { get; set; } = new List<OrderReceipt>();       //The User's Order receipts
    }
}