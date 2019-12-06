using System.Collections.Generic;
using TopShelfCustomer.Api.Models;

namespace TopShelfCustomer.Api.Services {

    /// <summary>
    /// OrderData:
    ///
    /// Utilizes the SqlDataAccess class to fetch
    /// Orders from the TopShelf database.
    /// </summary>
    public sealed class OrderData {

        /// <summary>
        /// GetOrdersByEmail:
        ///
        /// Wrapper method to allow database access.
        /// Fetches all Orders associated with the passed
        /// email address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns> A list of orders from the email address argument </returns>
        public List<Order> GetOrdersByEmail ( string email ) {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Email = email };
            var output = sql.LoadData<Order, dynamic>( "dbo.spGetOrdersByEmail", p, "TopShelfDbConnection" );
            return output;
        }
    }
}