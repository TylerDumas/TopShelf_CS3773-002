using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopShelfCustomer.Api.Models;

namespace TopShelfCustomer.Api.Services {

    /// <summary>
    /// ProductData:
    /// 
    /// Implementation of the SqlDataAccess class
    /// specific to the Product model class.
    /// Implements RESTful Api calls to communicate with the database
    /// and return the correct Product model objects.
    /// </summary>
    public class ProductData {

        /// <summary>
        /// GetProductById:
        /// 
        /// 
        /// Fetches the Property with an Id property that matches
        /// the "id" argument.
        /// </summary>
        /// <param name="id"> the Id property to match </param>
        /// <returns> A List of Products with 1 element </returns>
        public List<Product> GetProductById( int id ) {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };        //Blank object to pass as parameter

            var output = sql.LoadData<Product, dynamic>( "dbo.spGetProductById", p, "TopShelfDbConnection" );           //Store return value of database fetch
            return output;
        }
    }
}