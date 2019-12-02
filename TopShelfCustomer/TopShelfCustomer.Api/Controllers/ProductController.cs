using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TopShelfCustomer.Api.Models;
using TopShelfCustomer.Api.Services;

namespace TopShelfCustomer.Api.Controllers {

    /// <summary>
    /// ProductController:
    /// 
    /// Controller for the Product collection.
    /// Contains functionality for all RESTful API calls
    /// such as: Get, Put, Post, and Delete.
    /// </summary>
    public class ProductController : ApiController {

        /// <summary>
        /// GetProductById:
        /// 
        /// Overload of the Get method.
        /// Fetches a specific Product from the database and returns it
        /// to the caller of this API method.
        /// Matches based off of the passed Product Id.
        /// </summary>
        /// <param name="id"> The Id to match </param>
        /// <returns> The first Product returned that matches the id argument </returns>
        [Route( "api/Product/GetProductById/{id:int}" )]
        [HttpGet]
        public Product Get ( int id ) {
            ProductData data = new ProductData();

            var product = data.GetProductById( id );
            try {               //Catch exceptions thrown by null Products
                if ( product[0] == null ) { return new Product(); }
            } catch ( ArgumentOutOfRangeException e ) {
                Debug.WriteLine( e.Message );
                return new Product();
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return new Product();
            }

            return product[0];      //Return first match
        }
    }
}
