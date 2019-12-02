using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TopShelfCustomer.Api.Models;

namespace TopShelfCustomer.Api.Controllers {

    /// <summary>
    /// UserController:
    /// 
    /// Controller for the User collection.
    /// Contains functionality for all RESTful API calls
    /// such as: Get, Put, Post, and Delete.
    /// </summary>
    public class UserController : ApiController {
        
        /// <summary>
        /// users: Re-usable list of Users to allow fetching from database.
        /// </summary>
        public List<User> users = new List<User>();
        /// <summary>
        /// user: Re-usable User to allow fetching from database.
        /// </summary>
        public User user = new User();

        /// <summary>
        /// Constructor
        /// </summary>
        public UserController () {
            users.Add( new User {
                Id = 1,
                FullName = "Jackson Dumas",
                EmailAddress = "tylerdumas3@hotmail.com", 
                PhoneNumber = "210-464-3176", 
                StreetAddress = "6676 UTSA Boulevard", 
                StoreName = "HEB DeZavala"
            });
            users.Add( new User {
                Id = 2,
                FullName = "Dylan Dumas",
                EmailAddress = "dylandumas@gmail.com",
                PhoneNumber = "210-289-7527",
                StreetAddress = "6699 YoMomma Avenue",
                StoreName = "HEB Bulverde and 1604"
            } );
        }

        /// <summary>
        /// GetAllUsers:
        /// 
        /// Gets the entire list of Users.
        /// FIXME: this will be removed in the future.
        /// </summary>
        /// <returns> The entire User list </returns>
        [Route( "api/User/GetAllUsers" )]
        [HttpGet]
        public IEnumerable<User> Get() {
            return users;
        }

        /// <summary>
        /// GetUserById:
        /// 
        /// Overload of the Get request method.
        /// Fetches a single user from the API with the
        /// matching Id property. Matches based off of the passed
        /// id argument.
        /// </summary>
        /// <param name="userId"> The id of the requested User </param>
        /// <returns> a User with a matching Id </returns>
        [Route( "api/User/GetUserById/{userId:int}")]
        [HttpGet]
        public User Get( int userId ) {
            return users.Where( x => x.Id == userId ).FirstOrDefault();
        }

        /// <summary>
        /// Post:
        /// 
        /// Takes a User object as an argument and
        /// adds it to the List of users. Adds
        /// append functionality to the API.
        /// </summary>
        /// <param name="value"> The User to add </param>
        [Route( "api/User/PostUser" )]
        [HttpPost]
        public void Post( [FromBody]User value ) {
            users.Add( value );
        }

        /// <summary>
        /// Put:
        /// 
        /// Takes a User object as an argument and updates an
        /// entry if it exists. If not, it appends to the list
        /// of Users.
        /// </summary>
        /// <param name="id"> The Id value of the User object </param>
        /// <param name="value"> The User to add </param>
        [Route( "api/User/PutUser" )]
        [HttpPut]
        public void Put( int id, [FromBody]User value ) {
            User temp = users.Where( x => x.Id == value.Id ).FirstOrDefault();
            if ( temp != null ) {
                users.Remove( temp );
                users.Add( value );
            } else {
                users.Add( value );
            }
        }

        /// <summary>
        /// Delete:
        /// 
        /// Deletes the User entry that matches the passed id.
        /// Matches based off of the Id property on the User.
        /// </summary>
        /// <param name="userId"> The Id value to match </param>
        [Route( "api/User/DeleteUser/{userId:int}" )]
        [HttpDelete]
        public void Delete( int userId ) {
            users.Remove( users.Where( x => x.Id == userId ).FirstOrDefault() );
        }
    }
}
