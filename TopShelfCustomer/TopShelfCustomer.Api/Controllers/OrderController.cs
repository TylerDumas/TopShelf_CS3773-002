using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using TopShelfCustomer.Api.Models;
using TopShelfCustomer.Api.Services;

namespace TopShelfCustomer.Api.Controllers {

    /// <summary>
    /// OrderController:
    ///
    /// Controller for the Order API endpoint.
    /// Utilizes Service classes to return Orders to
    /// the Order API endpoint.
    /// </summary>
    public sealed class OrderController : ApiController {

        /// <summary>
        /// GetOrdersByEmail:
        ///
        /// Method responsible for the "GetOrdersByEmail"
        /// API endpoint. Uses helper classes to return the
        /// correct collection of Orders to the API caller.
        /// </summary>
        /// <param name="email"> The email to match </param>
        /// <returns> A list of orders for the account associated with "email" </returns>
        /// <remarks>
        /// Endpoints cannot handle the '.' operator. The caller must replace '.' with '-' before fetching
        /// User.
        /// </remarks>
        [Route( "api/Order/GetOrdersByEmail/{email}" )]
        [HttpGet]
        public IEnumerable<Order> GetOrdersByEmail ( string email ) {
            OrderData data = new OrderData();

            string sanitizedEmail = email.Replace( "-", "." );      //Convert from url-friendly email back to correct format
            var orders = data.GetOrdersByEmail( sanitizedEmail );

            try {               //Catch exceptions thrown by null User
                if ( orders[0] == null ) { return new List<Order>(); }
            } catch ( ArgumentOutOfRangeException e ) {
                Debug.WriteLine( e.Message );
                return new List<Order>();
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return new List<Order>();
            }
            return orders;
        }
    }
}