using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopShelfCustomer.Api.Models;

namespace TopShelfCustomer.Api.Services {

    /// <summary>
    /// StoreData:
    /// 
    /// Implementation of the SqlDataAccess class
    /// specific to the Store model class.
    /// Implements RESTful Api calls to communicate with the database
    /// and return the correct Store model objects.
    /// </summary>
    public class StoreData {

        /// <summary>
        /// GetAllProducts:
        /// 
        /// Returns all products in the Products
        /// database table.
        /// </summary>
        /// <returns> A List of all products in the Products table </returns>
        public List<Product> GetAllProducts () {
            SqlDataAccess data = new SqlDataAccess();

            var p = new object();
            var output = data.LoadData<Product, dynamic>( "dbo.spGetAllProducts", p, "TopShelfDbConnection" );
            return output;
        }

        /// <summary>
        /// GetStoreById:
        /// 
        /// Fetches the Store with an Id property that matches
        /// the "id" argument.
        /// </summary>
        /// <param name="id"> the Id property to match </param>
        /// <returns> A List of Stores with 1 element </returns>
        public List<Store> GetStoreById( int id ) {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };
            var output = sql.LoadData<Store, dynamic>( "dbo.spGetStoreById", p, "TopShelfDbConnection" );
            return output;
        }
    }
}