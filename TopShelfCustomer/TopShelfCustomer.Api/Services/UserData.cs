using System.Collections.Generic;
using TopShelfCustomer.Api.Models;

namespace TopShelfCustomer.Api.Services {

    /// <summary>
    /// UserData:
    /// 
    /// Implementation of the SqlDataAccess class
    /// specific to the User model class. Responsible for
    /// fetching and sending User data to and from the
    /// database.
    /// </summary>
    public class UserData {

        /// <summary>
        /// GetUserById:
        /// 
        /// Fetches Users with Id value of "id"
        /// from the database and returns it.
        /// </summary>
        /// <param name="id"> The Id value to search for </param>
        /// <returns> A list of Users with that Id value (1 element) </returns>
        public List<User> GetUserById( int id ) {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };        //Temporary property object
            var output = sql.LoadData<User, dynamic>( "dbo.spGetUserById", p, "TopShelfDbConnection" );       //Fetch the User(s)
            return output;
        }

        /// <summary>
        /// GetUserByEmail:
        /// 
        /// Fetches Users with EmailAddress of "email"
        /// from the database and returns it.
        /// </summary>
        /// <param name="email"> The email address without the extension </param>
        /// /// <param name="extension"> The email address extension </param>
        /// <returns> A List of Users with one element </returns>
        public List<User> GetUserByEmail( string email, string extension ) {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Email = email + extension };      //Temporary property object
            var output = sql.LoadData<User, dynamic>( "dbo.spGetUserByEmail", p, "TopShelfDbConnection" );      //Fetch the User(s)
            return output;
        }
    }
}