﻿using System;
using System.Diagnostics;
using System.Web.Http;
using TopShelfCustomer.Api.Models;
using TopShelfCustomer.Api.Services;

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
        /// GetUserById:
        /// 
        /// Overload of the Get request method.
        /// Fetches a single user from the database and returns it
        /// to the caller of this API method.
        /// Matches based off of the passed userId argument.
        /// </summary>
        /// <param name="userId"> The Id of the requested User </param>
        /// <returns> a User with a matching Id </returns>
        [Route( "api/User/GetUserById/{userId:int}")]
        [HttpGet]
        public User Get( int userId ) {
            UserData data = new UserData();     //Create new UserData object to interact with DB

            var user = data.GetUserById( userId );      //Get user from DB

            try {               //Catch exceptions thrown by null User
                if ( user[0] == null ) { return new User(); }
            }catch( ArgumentOutOfRangeException e ) {
                Debug.WriteLine( e.Message );
                return new User();
            }catch( Exception e ) {
                Debug.WriteLine( e.Message );
                return new User();
            }
            
            return user[0];
        }

        /// <summary>
        /// GetUserByEmail:
        /// 
        /// Overload of the Get request method.
        /// Fetches a single User from the database and returns it
        /// to the caller of this API method. Finds the user by their
        /// email address.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns> a User with the matching EmailAddress </returns>
        [Route( "api/User/GetUserByEmail/{emailAddress}" )]
        [HttpGet]
        public User Get( string emailAddress ) {
            UserData data = new UserData();     //Create new UserData object to interact with DB

            var user = data.GetUserByEmail( emailAddress );      //Get user from DB

            try {               //Catch exceptions thrown by null User
                if ( user[0] == null ) { return new User(); }
            } catch ( ArgumentOutOfRangeException e ) {
                Debug.WriteLine( e.Message );
                return new User();
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return new User();
            }

            return user[0];
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
            Debug.WriteLine( "User POST requested" );
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
            Debug.WriteLine( "User PUT requested" );
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
            Debug.WriteLine( "User DELETE requested" );
        }
    }
}
