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
    /// StoreController:
    /// 
    /// Controller for the "Store" API endpoint.
    /// Manages the data transfer with the database and
    /// the callers of this API.
    /// </summary>
    public class StoreController : ApiController {

        /// <summary>
        /// GetAllProducts:
        /// 
        /// Overload of the Get request method.
        /// Fetches all Products from the database and returns them
        /// to the caller of this API method.
        /// Matches based off of the passed storeName argument.
        /// </summary>
        /// <returns> a List of Products from that Store </returns>
        [Route( "api/Store/GetAllProducts" )]
        [HttpGet]
        public IEnumerable<Product> Get () {
            StoreData data = new StoreData();

            var allProducts = data.GetAllProducts();        //Store return value of database fetch

            try {               //Catch exceptions thrown by null Products
                if ( allProducts[0] == null ) { return new List<Product>(); }
            } catch ( ArgumentOutOfRangeException e ) {
                Debug.WriteLine( e.Message );
                return new List<Product>();
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return new List<Product>();
            }
            return allProducts;
        }

        /// <summary>
        /// GetStoreById:
        /// 
        /// Overload for the Get request method.
        /// Returns a Store that matches the id argument.
        /// </summary>
        /// <param name="id"> The id to match to a Store </param>
        /// <returns> A Store with a matching Id property value </returns>
        [Route( "api/Store/GetStoreById/{id:int}" )]
        [HttpGet]
        public Store Get( int id ) {
            StoreData data = new StoreData();

            var store = data.GetStoreById( id );        //Store return value of database fetch

            try {               //Catch exceptions thrown by null Products
                if ( store[0] == null ) { return new Store(); }
            } catch ( ArgumentOutOfRangeException e ) {
                Debug.WriteLine( e.Message );
                return new Store();
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return new Store();
            }

            return store[0];        //Return first matching entry
        }
    }
}
