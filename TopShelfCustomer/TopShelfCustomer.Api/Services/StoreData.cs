using System.Collections.Generic;
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
    public sealed class StoreData {

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
        public List<Store> GetStoreById ( int id ) {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };
            var output = sql.LoadData<Store, dynamic>( "dbo.spGetStoreById", p, "TopShelfDbConnection" );
            return output;
        }

        /// <summary>
        /// GetStoresByZipCode:
        ///
        /// Fetches all Stores from the database with a
        /// matching ZipCode property.
        /// </summary>
        /// <param name="zipCode"> The ZipCode to match </param>
        /// <returns> A list of Stores </returns>
        public List<Store> GetStoresByZipCode ( int zipCode ) {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { ZipCode = zipCode };
            var output = sql.LoadData<Store, dynamic>( "dbo.spGetStoresByZipCode", p, "TopShelfDbConnection" );
            return output;
        }
    }
}